CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

ALTER TABLE accounts
ADD COLUMN matchesWon int default 0;

UPDATE accounts SET rankedElo = 500;

SELECT id, name, elo, rankedElo, matchesWon FROM accounts;


CREATE TABLE IF NOT EXISTS matches(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  gameId INT NOT NULL,
  player1 VARCHAR(255) NOT NULL,
  player2 VARCHAR(255) NOT NULL,
  winnerId VARCHAR(255) NOT NULL,
  ranked TINYINT DEFAULT 0
) default charset utf8 COMMENT '';

CREATE TRIGGER matches_score_players
  AFTER INSERT on matches FOR EACH ROW
UPDATE accounts a SET
  a.matchesWon = a.matchesWon + IF(NEW.winnerId = a.id, 1, 0)
WHERE a.id = NEW.player1 OR a.id = NEW.player2;

DROP TRIGGER IF EXISTS matches_ranked_elo;
DELIMITER //
CREATE TRIGGER  matches_ranked_elo
  AFTER INSERT ON matches FOR EACH ROW
BEGIN
  CALL get_elo_change(NEW.player1, NEW.player2, NEW.id, @eloChange);
  UPDATE accounts a SET
    a.rankedElo = a.rankedElo + IF(NEW.winnerId = a.id, @eloChange, 0),
    a.rankedElo = a.rankedElo - IF(NEW.winnerId != a.id, @eloChange, 0)
  WHERE NEW.player1 = a.id OR NEW.player2 = a.id;
END//
DELIMITER ;


-- DROP PROCEDURE IF EXISTS get_elo_change;
DELIMITER //
CREATE PROCEDURE get_elo_change(
  IN player1 VARCHAR(255),
  IN player2 VARCHAR(255),
  IN matchId INT,
  OUT eloChange INT
)
BEGIN
  SELECT
    p1.rankedElo, p2.rankedElo
  INTO
    @elo1, @elo2
  FROM matches m
  LEFT JOIN accounts AS p1 ON m.player1 = p1.id
  LEFT JOIN accounts AS p2 ON m.player2 = p2.id
  WHERE m.id = matchId;

  SET @r1 = POWER(10, @elo1/400);
  SET @r2 = POWER(10, @elo2/400);
  SET @e1 = @r1/(@r1+@r2);
  SET eloChange = ABS((@elo1 + 32 * (1 - @e1)) - @elo1);
END//
DELIMITER ;




CALL get_elo_change(2400, 2000, @eloChange);
SELECT @eloChange;

INSERT INTO matches
(`gameId`,player1, player2, `winnerId`)
VALUES
(2, "60d3560eceb6bbdfae388576", "6234ac00abca50735a3c9205", "6234ac00abca50735a3c9205");

CREATE TABLE IF NOT EXISTS games(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title TEXT NOT NULL
) default charset utf8 COMMENT '';

INSERT INTO games
(title)
VALUES ("Jackie Chan Fists of Fire");

-- select * FROM games;
-- select * FROM matches;
SELECT 
  p1.name AS player1,
  p2.name AS player2,  
  w.name AS winner,
  g.title
FROM matches m
LEFT JOIN accounts AS p1 on m.player1 = p1.id
LEFT JOIN accounts AS p2 on m.player2 = p2.id
LEFT JOIN accounts AS w on m.winnerId = w.id
JOIN games g on m.gameId = g.id;

SELECT
  m.id,
  g.title AS game,
  a.name AS opponent,
  IF(m.player1 = '6234ac00abca50735a3c9205', true  , false) AS won
FROM matches m
JOIN games g ON m.gameId = g.id
JOIN accounts a ON IF(m.player1 = '6234ac00abca50735a3c9205', m.player2, m.player1) = a.id
WHERE m.player1 = '6234ac00abca50735a3c9205' OR m.player2 = '6234ac00abca50735a3c9205';

SELECT name, rankedElo FROM accounts;

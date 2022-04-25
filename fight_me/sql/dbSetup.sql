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

UPDATE accounts SET elo = 1000;

SELECT id, name, elo, rankedElo, matchesWon FROM accounts;




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

SELECT name, rankedElo, elo FROM accounts;

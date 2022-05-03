CREATE TABLE IF NOT EXISTS leagues(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  minElo INT NOT NULL,
  maxElo INT NOT NULL,
  icon VARCHAR(255),
  img VARCHAR(255)
) default charset utf8 COMMENT '';

INSERT INTO leagues
(name, minElo, maxElo)
VALUES
('Bronze', 0, 1149)('Silver', 1150, 1599)('Gold', 1600, 2099)('Diamond', 2100, 5000);

SELECT * FROM leagues;

CREATE TABLE IF NOT EXISTS playerLeagues(
id INT AUTO_INCREMENT PRIMARY KEY,
accountId VARCHAR(255) NOT NULL,
gameId INT NOT NULL,
elo INT NOT NULL DEFAULT 1200,
matchesPlayed INT NOT NULL DEFAULT 0,
rankDownSaves INT NOT NULL DEFAULT 0,
  FOREIGN KEY(accountId) REFERENCES accounts (id) ON DELETE CASCADE,
  FOREIGN KEY(gameId) REFERENCES games (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE playerleagues;

INSERT INTO playerLeagues
(accountId, gameId)
VALUES
('6216b36ebc31a249987812b1', 5);

/* GET PLAYER RANKS */
SELECT 
  g.*,
  l.name,
  pl.elo
FROM playerleagues pl
  JOIN games g ON pl.gameId = g.id
  JOIN leagues l ON pl.elo > l.minElo AND pl.elo < l.maxElo
WHERE pl.accountId = '6216b36ebc31a249987812b1';

/* GET GAME LEADERBOARD */
SELECT 
  a.name,
  pl.elo,
  pl.matchesPlayed
FROM playerleagues pl
  JOIN accounts a ON pl.accountId = a.id
  JOIN leagues l ON pl.elo > l.minElo AND pl.elo < l.maxElo
WHERE pl.gameId = 3
ORDER BY pl.elo DESC;

/* UPDATE PLAYER RANKS */
CREATE TABLE IF NOT EXISTS matches(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  gameId INT NOT NULL,
  player1 VARCHAR(255) NOT NULL,
  player2 VARCHAR(255) NOT NULL,
  winnerId VARCHAR(255) NOT NULL,
  ranked TINYINT DEFAULT 0
) default charset utf8 COMMENT '';

/* trigger for increasing gamesWon */
CREATE TRIGGER matches_score_players
  AFTER INSERT on matches FOR EACH ROW
UPDATE accounts a SET
  a.matchesWon = a.matchesWon + IF(NEW.winnerId = a.id, 1, 0)
WHERE a.id = NEW.player1 OR a.id = NEW.player2;

/* trigger for changing elo */
DROP TRIGGER IF EXISTS matches_ranked_elo;
DELIMITER //
CREATE TRIGGER  matches_ranked_elo
  AFTER INSERT ON matches FOR EACH ROW
BEGIN--                                 ranked CoK   casual CoK
  CALL get_elo_change(NEW.id, IF(NEW.ranked = 1, 20, 8), @globElo, @gameElo);
    IF NEW.ranked = 1 THEN
  UPDATE accounts a SET --updated ranked global
      a.rankedElo = a.rankedElo + IF(NEW.winnerId = a.id, @globElo, 0),
      a.rankedElo = a.rankedElo - IF(NEW.winnerId != a.id, @globElo, 0)
  WHERE NEW.player1 = a.id OR NEW.player2 = a.id;
  UPDATE playerLeagues pl SET -- update ranked for game
    pl.rankedMatches = pl.rankedMatches + 1,
    pl.rankedElo = pl.rankedElo + IF(NEW.winnerId = pl.accountId, @gameElo, 0),
    pl.rankedElo = pl.rankedElo - IF(NEW.winnerId != pl.accountId, @gameElo, 0)
  WHERE NEW.gameId = pl.gameId AND (NEW.player1 = pl.accountId OR NEW.player2 = pl.accountId);
    ELSE
  UPDATE accounts a SET -- update global casual
      a.elo = a.elo + IF(NEW.winnerId = a.id, @globElo, 0),
      a.elo = a.elo - IF(NEW.winnerId != a.id, @globElo, 0)
  WHERE NEW.player1 = a.id OR NEW.player2 = a.id;
  UPDATE playerLeagues pl SET -- update casual for game
    pl.matches = pl.matches + 1,
    pl.elo = pl.elo + IF(NEW.winnerId = pl.accountId, @gameElo, 0),
    pl.elo = pl.elo - IF(NEW.winnerId != pl.accountId, @gameElo, 0)
  WHERE NEW.gameId = pl.gameId AND (NEW.player1 = pl.accountId OR NEW.player2 = pl.accountId);
    END IF;
END//
DELIMITER ;

/* PROCEDUR FOR PLAYER RANK CHANGING FOR EACH GAME */
/* ANCHOR this procedure to update playerLeague data, stuck on update join */
DROP PROCEDURE matches_league_elo;
DELIMITER //
CREATE PROCEDURE  matches_league_elo(
  IN mId INT,
  IN eloChange INT
)
BEGIN

END//
DELIMITER ;
SELECT *
FROM playerleagues pl
JOIN matches m ON pl.gameId = m.gameId WHERE m.id = 63;

/* ELO calculation PROCEDURE */
DROP PROCEDURE IF EXISTS get_elo_change;
DELIMITER //
CREATE PROCEDURE get_elo_change(
  IN matchId INT,
  IN k INT,
  OUT globElo INT,
  OUT gameElo INT
)
BEGIN
    SELECT -- global elo change
      IF(m.ranked = 1, p1.rankedElo, p1.elo),IF(m.ranked = 1, p2.rankedElo, p2.elo)
    INTO
      @elo1, @elo2
    FROM matches m
    LEFT JOIN accounts AS p1 ON m.winnerId = p1.id
    LEFT JOIN accounts AS p2 ON p2.id = IF(m.winnerId = m.player1, m.player2, m.player1)
    WHERE m.id = matchId;
  SET @r1 = POWER(10, @elo1/400);
  SET @r2 = POWER(10, @elo2/400);
  SET @e1 = @r1/(@r1+@r2);
  SET globElo = ABS((@elo1 + (k * (1 - @e1))) - @elo1);

    SELECT -- game elo change
      IF(m.ranked = 1, p1.rankedElo, p1.elo),IF(m.ranked = 1, p2.rankedElo, p2.elo)
    INTO
      @elo1, @elo2
    FROM matches m
    LEFT JOIN playerLeagues AS p1 ON m.winnerId = p1.accountId
    LEFT JOIN playerLeagues AS p2 ON p2.accountId = IF(m.winnerId = m.player1, m.player2, m.player1)
    WHERE m.id = matchId;
  SET @r1 = POWER(10, @elo1/400);
  SET @r2 = POWER(10, @elo2/400);
  SET @e1 = @r1/(@r1+@r2);
  SET gameElo = ABS((@elo1 + (k * (1 - @e1))) - @elo1);
END//
DELIMITER ;




CALL get_elo_change(2400, 2000, @eloChange);
SELECT @eloChange;

UPDATE accounts SET rankedElo = 1000, elo = 1000;

/* PLAY GAME */
INSERT INTO matches
(`gameId`,player1, player2, `winnerId`, ranked)
VALUES
(5, "6216b36ebc31a249987812b1", "6234ac00abca50735a3c9205", "6216b36ebc31a249987812b1", 0);

-- INSERT INTO keeps(name, img, userId, description) VALUES("Bugs Bunny","http://www.iconarchive.com/show/looney-tunes-icons-by-sykonist/Bugs-Bunny-Whisper-icon.html","5b0eed56-ed24-47fe-b496-a404cd7fc815","description");



-- ALTER TABLE keeps MODIFY description VARCHAR(255) DEFAULT "";

-- DELETE FROM keeps;
-- INSERT INTO vaultkeeps(vaultId, keepId) VALUES (6,2)
-- SELECT * FROM keeps;
-- SELECT * FROM keeps WHERE isPrivate = 0
-- SELECT * FROM keeps WHERE userId = 	"5b0eed56-ed24-47fe-b496-a404cd7fc815";
-- SELECT * FROM vaults;
-- SELECT * FROM vaults WHERE userId = "5b0eed56-ed24-47fe-b496-a404cd7fc815";

-- DELETE FROM vaultkeeps WHERE id = 4 AND userId = "5b0eed56-ed24-47fe-b496-a404cd7fc815";
UPDATE keeps SET views = views+1 WHERE id = 11;
SELECT * FROM keeps;
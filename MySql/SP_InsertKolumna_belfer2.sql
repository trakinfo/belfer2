DELIMITER $$

DROP PROCEDURE IF EXISTS belfer2.InsertColumn $$
CREATE PROCEDURE belfer2.InsertColumn(IN IdObsada int)
BEGIN
  SET @j = 1, @typ = 'C';
  INSERT INTO kolumna (NrKolumny,IdObsada,Typ,Owner,User,ComputerIP) VALUES (0,IdObsada,'S','admin','admin','localhost');
  INSERT INTO kolumna (NrKolumny,IdObsada,Typ,Owner,User,ComputerIP) VALUES (0,IdObsada,'R','admin','admin','localhost');
  REPEAT
    SET @i=1;
    SET @term = CONCAT(@typ,@j);
    WHILE @i <= 10 DO
      INSERT INTO kolumna (NrKolumny,IdObsada,Typ,Owner,User,ComputerIP) VALUES (@i,IdObsada,@term,'admin','admin','localhost');
      SET @i = @i + 1;
    END WHILE;
    SET @j = @j + 1;
  UNTIL @j > 2 END REPEAT;
END $$

DROP PROCEDURE IF EXISTS belfer2.DeleteColumn $$
CREATE PROCEDURE belfer2.DeleteColumn(IN ID int)
BEGIN
  DELETE FROM kolumna WHERE IdObsada=ID;
END $$

DROP TRIGGER IF EXISTS belfer2.InsertColumn_AfterInsert $$
CREATE TRIGGER belfer2.InsertColumn_AfterInsert AFTER INSERT ON belfer2.obsada
FOR EACH ROW
BEGIN
   CALL belfer2.InsertColumn(NEW.ID);
END $$

DROP TRIGGER IF EXISTS belfer2.DeleteColumn_AfterDelete $$
CREATE TRIGGER belfer2.DeleteColumn_AfterDelete AFTER DELETE ON belfer2.obsada
FOR EACH ROW
BEGIN
   CALL belfer2.DeleteColumn(OLD.ID);
END $$

DELIMITER ;
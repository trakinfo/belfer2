DELIMITER $$

DROP PROCEDURE IF EXISTS `belfer`.`InsertKolumna` $$
CREATE PROCEDURE `belfer`.`InsertKolumna` (IN ID int, IN Typ varchar(2))
BEGIN
    DECLARE i int;
    DECLARE T char(1);
    SELECT CASE Typ WHEN 'C1' THEN 'S' WHEN 'C2' THEN 'R' END INTO T;
    INSERT INTO kolumna (NrKolumny,IdObsada,Typ,Owner,User,ComputerIP) VALUES (0,ID,T,'tomek','tomek','localhost');
    SET i=1;
    WHILE i <= 10 DO
        INSERT INTO kolumna (NrKolumny,IdObsada,Typ,Owner,User,ComputerIP) VALUES (i,ID,Typ,'tomek','tomek','localhost');
        SET i = i + 1;
    END WHILE;
END $$

DELIMITER ;
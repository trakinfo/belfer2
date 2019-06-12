DELIMITER $$
USE belfer2$$
DROP EVENT IF EXISTS ComplainAutoAccept$$
CREATE DEFINER=`root`@`localhost` EVENT IF NOT EXISTS ComplainAutoAccept
    ON SCHEDULE EVERY 1 DAY STARTS '2016-01-30 00:00:15'
    COMMENT 'Automatycznie akceptuje reklamacje.'
    DO
      BEGIN
        DECLARE vCurDate date;
        DECLARE vDayNumber tinyint;
        DECLARE vIP varchar(15);
        SELECT SUBSTRING_INDEX(USER(),'@',-1) INTO vIP;
  	    SELECT CURDATE() INTO vCurDate;
        SELECT o.Value FROM opcje o WHERE o.Name='AutoAcceptOffset' AND o.IdSchool='1' AND o.Type='G' INTO vDayNumber;
        UPDATE reklamacja SET Status=1,User='Automat_BD',ComputerIP=vIP,Version=NULL WHERE Status=0 AND DATEDIFF(vCurDate,NotifyDate)>=vDayNumber;
    END $$

DELIMITER ;


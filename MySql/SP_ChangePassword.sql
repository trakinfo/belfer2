DELIMITER $$
USE belfer2 $$
DROP PROCEDURE IF EXISTS `belfer2`.`ChangePassword` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ChangePassword`(IN Nick varchar(10),IN NewPwd binary(64),IN UserName varchar(10),IN HostIP varchar(15))
BEGIN
	UPDATE user SET Password=NewPwd,User=UserName,ComputerIP=HostIP,PasswordVersion=PasswordVersion+1 WHERE Login=Nick;
END $$

DELIMITER ;
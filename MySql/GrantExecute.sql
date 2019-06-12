DELIMITER $$
USE belfer2$$
CREATE user parent@localhost identified by 'password'$$
CREATE user belfer@localhost identified by 'password'$$
CREATE user belferssl@localhost identified by 'password'$$

GRANT SELECT ON * to parent@localhost$$
GRANT SELECT,INSERT,UPDATE,DELETE ON * to belfer@localhost$$
GRANT SELECT,INSERT,UPDATE,DELETE ON * to belferssl@localhost$$

GRANT EXECUTE ON PROCEDURE LogIn to 'belfer'@'%'$$
GRANT EXECUTE ON PROCEDURE LogIn to 'belferssl'@'%'$$
GRANT EXECUTE ON PROCEDURE LogIn to 'parent'@'192.168.0.6'$$

GRANT EXECUTE ON PROCEDURE LogOut to 'belfer'@'%'$$
GRANT EXECUTE ON PROCEDURE LogOut to 'belferssl'@'%'$$
GRANT EXECUTE ON PROCEDURE LogOut to 'parent'@'192.168.0.6'$$

GRANT EXECUTE ON PROCEDURE ChangePassword to 'belfer'@'%'$$
GRANT EXECUTE ON PROCEDURE ChangePassword to 'belferssl'@'%'$$
GRANT EXECUTE ON PROCEDURE ChangePassword to 'parent'@'192.168.0.6'$$

GRANT EXECUTE ON PROCEDURE InsertApplication to 'parent'@'192.168.0.6'$$
GRANT EXECUTE ON PROCEDURE InsertStudentRequest to 'parent'@'192.168.0.6'$$
GRANT EXECUTE ON PROCEDURE PasswordRequest to 'parent'@'192.168.0.6'$$

DELIMITER ;

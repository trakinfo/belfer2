Use belfer2;
charset utf8;

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Opcje.csv' INTO TABLE opcje
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Name,Value,Type,Description,IdSchool,StartDate,EndDate,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/harmonogram.csv' INTO TABLE harmonogram
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (IdSzkola,NrLekcji,StartTime,EndTime,Owner,User,ComputerIP);
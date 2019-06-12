Use belfer2;
charset utf8;

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/Woj.csv' INTO TABLE belfer2.wojewodztwo
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/Powiat.csv' INTO TABLE belfer2.powiat
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/Gmina.csv' INTO TABLE belfer2.gmina
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/TypyGmin.csv' INTO TABLE belfer2.gmina_typ
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Komentarz,Owner,User,ComputerIP);
  
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/TypyMiejsc.csv' INTO TABLE belfer2.miejsce_typ
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/simc.csv' INTO TABLE belfer2.simc
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (woj,pow,gmi,rodz_gmi,rm,mz,nazwa,sym,sympodst,stan_na);
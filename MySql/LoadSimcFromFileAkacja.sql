Use belfer2;
charset utf8;

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Woj.csv' INTO TABLE belfer2.wojewodztwo
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Powiat.csv' INTO TABLE belfer2.powiat
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Gmina.csv' INTO TABLE belfer2.gmina
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/TypyGmin.csv' INTO TABLE belfer2.gmina_typ
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Komentarz,Owner,User,ComputerIP);
  
LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/TypyMiejsc.csv' INTO TABLE belfer2.miejsce_typ
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Nazwa,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/simc.csv' INTO TABLE belfer2.simc
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (woj,pow,gmi,rodz_gmi,rm,mz,nazwa,sym,sympodst,stan_na);
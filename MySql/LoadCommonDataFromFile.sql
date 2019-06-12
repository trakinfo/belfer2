Use belfer2;
charset utf8;

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Klasa.csv' INTO TABLE klasa
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Skala_ocen.csv' INTO TABLE skala_ocen
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Ocena,Nazwa,Alias,Waga,Typ,PodTyp,SortOrder,Owner,User,ComputerIP);

LOAD DATA INFILE 'D:/.NET/VS2017/belfer2/MySql/Przedmiot.csv' INTO TABLE przedmiot
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Alias,Nazwa,Typ,Priorytet,Owner,User,ComputerIP);
  
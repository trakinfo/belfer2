Use belfer2;
charset utf8;

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/Klasa.csv' INTO TABLE klasa
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Kod,Owner,User,ComputerIP);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/Skala_ocen.csv' INTO TABLE skala_ocen
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Ocena,Nazwa,Alias,Waga,Typ,PodTyp,SortOrder,Owner,User,ComputerIP);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 5.7/Uploads/Przedmiot.csv' INTO TABLE przedmiot
  FIELDS TERMINATED BY ';'
  LINES TERMINATED BY '\r\n'
  IGNORE 1 LINES (Alias,Nazwa,Typ,Priorytet,Owner,User,ComputerIP);
  
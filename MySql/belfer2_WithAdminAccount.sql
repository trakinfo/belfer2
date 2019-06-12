-- MySQL dump 10.13  Distrib 5.5.24, for Win64 (x86)
--
-- Host: localhost    Database: belfer2
-- ------------------------------------------------------
-- Server version	5.5.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `belfer2`
--

/*!40000 DROP DATABASE IF EXISTS `belfer2`*/;

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `belfer2` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_polish_ci */;

USE `belfer2`;

--
-- Table structure for table `back_frekwencja`
--

DROP TABLE IF EXISTS `back_frekwencja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_frekwencja` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL,
  `IdLekcja` smallint(5) unsigned NOT NULL,
  `Typ` enum('u','n','s') COLLATE utf8_polish_ci NOT NULL DEFAULT 'u',
  `Data` date NOT NULL,
  `IdFrekwencja` int(10) unsigned NOT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `Owner` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_frekwencja`
--

LOCK TABLES `back_frekwencja` WRITE;
/*!40000 ALTER TABLE `back_frekwencja` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_frekwencja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_temat`
--

DROP TABLE IF EXISTS `back_temat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_temat` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nr` tinyint(3) unsigned DEFAULT NULL,
  `Tresc` varchar(100) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdLekcja` smallint(5) unsigned NOT NULL,
  `Data` date NOT NULL,
  `Status` tinyint(1) unsigned DEFAULT '1',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdTemat` int(10) unsigned NOT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_temat`
--

LOCK TABLES `back_temat` WRITE;
/*!40000 ALTER TABLE `back_temat` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_temat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_uczen`
--

DROP TABLE IF EXISTS `back_uczen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_uczen` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nazwisko` varchar(50) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Imie` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Imie2` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NrArkusza` int(10) unsigned DEFAULT NULL,
  `ImieOjca` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NazwiskoOjca` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ImieMatki` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NazwiskoMatki` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `DataUr` date DEFAULT NULL,
  `Pesel` varchar(11) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdMiejsceUr` int(10) unsigned DEFAULT NULL,
  `IdMiejsceZam` int(10) unsigned DEFAULT NULL,
  `Ulica` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NrDomu` varchar(5) COLLATE utf8_polish_ci DEFAULT NULL,
  `NrMieszkania` varchar(5) COLLATE utf8_polish_ci DEFAULT NULL,
  `Tel` varchar(9) COLLATE utf8_polish_ci DEFAULT NULL,
  `TelKom1` varchar(9) COLLATE utf8_polish_ci DEFAULT NULL,
  `TelKom2` varchar(9) COLLATE utf8_polish_ci DEFAULT NULL,
  `Man` tinyint(1) unsigned DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdUczen` int(10) unsigned NOT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_uczen`
--

LOCK TABLES `back_uczen` WRITE;
/*!40000 ALTER TABLE `back_uczen` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_uczen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_user`
--

DROP TABLE IF EXISTS `back_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_user` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Login` varchar(10) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Nazwisko` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Imie` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Password` BINARY(64) NOT NULL,
  `Role` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Status` BIT NOT NULL DEFAULT 1,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_user`
--

LOCK TABLES `back_user` WRITE;
/*!40000 ALTER TABLE `back_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_uwagi`
--

DROP TABLE IF EXISTS `back_uwagi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_uwagi` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL DEFAULT '0',
  `TrescUwagi` text COLLATE utf8_polish_ci NOT NULL,
  `TypUwagi` enum('p','n') COLLATE utf8_polish_ci NOT NULL DEFAULT 'n',
  `Autor` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Data` datetime NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdUprawnienie` int(10) unsigned NOT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_uwagi`
--

LOCK TABLES `back_uwagi` WRITE;
/*!40000 ALTER TABLE `back_uwagi` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_uwagi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_wynik`
--

DROP TABLE IF EXISTS `back_wynik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_wynik` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL DEFAULT '0',
  `IdOcena` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `IdKolumna` int(10) unsigned NOT NULL,
  `Data` datetime NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdWynik` int(10) unsigned NOT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_wynik`
--

LOCK TABLES `back_wynik` WRITE;
/*!40000 ALTER TABLE `back_wynik` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_wynik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `back_zagrozenia`
--

DROP TABLE IF EXISTS `back_zagrozenia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `back_zagrozenia` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdPrzydzial` int(10) unsigned NOT NULL,
  `IdPrzedmiot` tinyint(3) unsigned NOT NULL,
  `Semestr` enum('1','2') COLLATE utf8_polish_ci NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdWoj` int(10) unsigned NOT NULL,
  `Type` enum('D','U') COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `back_zagrozenia`
--

LOCK TABLES `back_zagrozenia` WRITE;
/*!40000 ALTER TABLE `back_zagrozenia` DISABLE KEYS */;
/*!40000 ALTER TABLE `back_zagrozenia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_field_types`
--

DROP TABLE IF EXISTS `cenzurka_field_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_field_types` (
  `Name` varchar(4) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `FriendlyName` varchar(45) NOT NULL,
  `IdFont` smallint(5) unsigned NOT NULL,
  `User` varchar(50) DEFAULT NULL,
  `ComputerIP` varchar(15) DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_field_types`
--

LOCK TABLES `cenzurka_field_types` WRITE;
/*!40000 ALTER TABLE `cenzurka_field_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_field_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_line_content`
--

DROP TABLE IF EXISTS `cenzurka_line_content`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_line_content` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `IdLine` smallint(5) unsigned NOT NULL,
  `Content` varchar(100) DEFAULT NULL,
  `PosX` float NOT NULL,
  `Width` float DEFAULT NULL,
  `Type` varchar(4) NOT NULL DEFAULT '',
  `IdFont` smallint(5) unsigned DEFAULT NULL,
  `User` varchar(50) DEFAULT NULL,
  `ComputerIP` varchar(15) DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `Index_2` (`IdLine`),
  KEY `FK_cenzurka_line_content_3` (`Type`),
  CONSTRAINT `FK_cenzurka_line_content_1` FOREIGN KEY (`IdLine`) REFERENCES `cenzurka_vertical_locations` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_cenzurka_line_content_3` FOREIGN KEY (`Type`) REFERENCES `cenzurka_field_types` (`Name`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_line_content`
--

LOCK TABLES `cenzurka_line_content` WRITE;
/*!40000 ALTER TABLE `cenzurka_line_content` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_line_content` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_margins`
--

DROP TABLE IF EXISTS `cenzurka_margins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_margins` (
  `LeftMargin` float unsigned NOT NULL DEFAULT '0',
  `RightMargin` float unsigned NOT NULL DEFAULT '0',
  `TopMargin` float unsigned NOT NULL DEFAULT '0',
  `BottomMargin` float unsigned NOT NULL DEFAULT '0',
  `Page` tinyint(3) unsigned NOT NULL,
  `IdSymbol` smallint(5) unsigned NOT NULL,
  `User` varchar(50) DEFAULT NULL,
  `ComputerIP` varchar(15) DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdSymbol`,`Page`),
  KEY `Index_2` (`IdSymbol`),
  CONSTRAINT `FK_cenzurka_margins_1` FOREIGN KEY (`IdSymbol`) REFERENCES `cenzurka_symbole` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_margins`
--

LOCK TABLES `cenzurka_margins` WRITE;
/*!40000 ALTER TABLE `cenzurka_margins` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_margins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_pasek`
--

DROP TABLE IF EXISTS `cenzurka_pasek`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_pasek` (
  `IdSzkola` smallint(5) unsigned NOT NULL,
  `PionKlas` enum('1','2','3','4','5','6') NOT NULL,
  `Avg` float NOT NULL,
  `IdOcena` tinyint(3) unsigned NOT NULL,
  `User` varchar(50) DEFAULT NULL,
  `ComputerIP` varchar(15) DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PionKlas`,`IdSzkola`),
  KEY `Index_3` (`IdOcena`),
  KEY `FK_cenzurka_pasek_szkola_idx` (`IdSzkola`),
  CONSTRAINT `FK_cenzurka_pasek_2` FOREIGN KEY (`IdOcena`) REFERENCES `skala_ocen` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_cenzurka_pasek_szkola` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_pasek`
--

LOCK TABLES `cenzurka_pasek` WRITE;
/*!40000 ALTER TABLE `cenzurka_pasek` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_pasek` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_przyporzadkowanie_szablonow`
--

DROP TABLE IF EXISTS `cenzurka_przyporzadkowanie_szablonow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_przyporzadkowanie_szablonow` (
  `IdTypSzkoly` tinyint(3) unsigned NOT NULL,
  `PionKlas` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `IdSymbol` smallint(5) unsigned NOT NULL DEFAULT '0',
  `User` varchar(50) DEFAULT NULL,
  `ComputerIP` varchar(15) DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PionKlas`,`IdSymbol`,`IdTypSzkoly`),
  KEY `FK_cenzurka_przyporzadkowanie_szablonow_2` (`IdSymbol`),
  KEY `FK_cenzurka_przyporzadkowanie_szablonow_1` (`IdTypSzkoly`),
  CONSTRAINT `FK_cenzurka_przyporzadkowanie_szablonow_1` FOREIGN KEY (`IdTypSzkoly`) REFERENCES `typy_szkol` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_cenzurka_przyporzadkowanie_szablonow_2` FOREIGN KEY (`IdSymbol`) REFERENCES `cenzurka_symbole` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_przyporzadkowanie_szablonow`
--

LOCK TABLES `cenzurka_przyporzadkowanie_szablonow` WRITE;
/*!40000 ALTER TABLE `cenzurka_przyporzadkowanie_szablonow` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_przyporzadkowanie_szablonow` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_symbole`
--

DROP TABLE IF EXISTS `cenzurka_symbole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_symbole` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `Symbol` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `Typ` enum('Z','W') COLLATE utf8_polish_ci NOT NULL,
  `Gilosz` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Przeznaczenie` varchar(200) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Index_2` (`Symbol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_symbole`
--

LOCK TABLES `cenzurka_symbole` WRITE;
/*!40000 ALTER TABLE `cenzurka_symbole` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_symbole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_vertical_locations`
--

DROP TABLE IF EXISTS `cenzurka_vertical_locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_vertical_locations` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `IdSymbol` smallint(5) unsigned NOT NULL,
  `PosY` float unsigned NOT NULL,
  `Page` tinyint(3) unsigned NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `Index_2` (`IdSymbol`),
  CONSTRAINT `FK_cenzurka_vertical_locations_1` FOREIGN KEY (`IdSymbol`) REFERENCES `cenzurka_symbole` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_vertical_locations`
--

LOCK TABLES `cenzurka_vertical_locations` WRITE;
/*!40000 ALTER TABLE `cenzurka_vertical_locations` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_vertical_locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cenzurka_wspolne_dane`
--

DROP TABLE IF EXISTS `cenzurka_wspolne_dane`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cenzurka_wspolne_dane` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `IdSzkola` smallint(5) unsigned NOT NULL,
  `SchoolName` varchar(100) COLLATE utf8_polish_ci DEFAULT NULL,
  `GimPrefix` varchar(45) COLLATE utf8_polish_ci DEFAULT '',
  `GimPrefix1` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `GimPostfix` varchar(45) COLLATE utf8_polish_ci DEFAULT '',
  `Nr` tinyint(3) unsigned NOT NULL,
  `Im` varchar(45) COLLATE utf8_polish_ci DEFAULT '',
  `Im2` varchar(45) COLLATE utf8_polish_ci DEFAULT '',
  `IdMiejscowosc` mediumint(8) unsigned DEFAULT NULL,
  `DataRP` date NOT NULL,
  `IdMiejscowosc2` mediumint(8) unsigned DEFAULT NULL,
  `DataKRS` date NOT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `idxMiejscowosc2` (`IdMiejscowosc2`),
  KEY `idxMiejscowosc` (`IdMiejscowosc`),
  KEY `fk_cenzurka_wspolne_dane_szkola_idx` (`IdSzkola`),
  CONSTRAINT `FK_IdMiejscowosc` FOREIGN KEY (`IdMiejscowosc`) REFERENCES `miejscowosc` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_IdMiejscowosc2` FOREIGN KEY (`IdMiejscowosc2`) REFERENCES `miejscowosc` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `fk_cenzurka_wspolne_dane_szkola` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cenzurka_wspolne_dane`
--

LOCK TABLES `cenzurka_wspolne_dane` WRITE;
/*!40000 ALTER TABLE `cenzurka_wspolne_dane` DISABLE KEYS */;
/*!40000 ALTER TABLE `cenzurka_wspolne_dane` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Login` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `AppType` enum('D','W') COLLATE utf8_polish_ci NOT NULL,
  `AppVer` varchar(7) COLLATE utf8_polish_ci DEFAULT NULL,
  `TimeIn` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `TimeOut` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frekwencja`
--

DROP TABLE IF EXISTS `frekwencja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `frekwencja` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL,
  `IdLekcja` smallint(5) unsigned NOT NULL,
  `Typ` enum('u','n','s','z','k','w') COLLATE utf8_polish_ci NOT NULL DEFAULT 'u' COMMENT 'u - usprawiedliwione, n - nieusprawiedliowione, s - spóźnienie, z - zwolniony (zawody), k - konkurs, w - wycieczka',
  `Data` date NOT NULL,
  `Owner` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` char(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` char(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxAbsencja` (`IdUczen`,`IdLekcja`,`Data`),
  KEY `idxIdUczen` (`IdUczen`),
  KEY `FK_Frekwencja_Lekcja_idx` (`IdLekcja`),
  CONSTRAINT `FK_Frekwencja_Lekcja` FOREIGN KEY (`IdLekcja`) REFERENCES `lekcja` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_frekwencja_1` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frekwencja`
--

LOCK TABLES `frekwencja` WRITE;
/*!40000 ALTER TABLE `frekwencja` DISABLE KEYS */;
/*!40000 ALTER TABLE `frekwencja` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `belfer2`.`frekwencja_before_delete`
BEFORE DELETE ON `belfer2`.`frekwencja`
FOR EACH ROW
BEGIN
DECLARE vUser varchar(50);

   
   SELECT USER() INTO vUser;
   
   
   INSERT INTO back_frekwencja
   ( ID,IdUczen,IdLekcja,Typ,Data,Owner,IdFrekwencja,Type,User,Version) VALUES ( NULL,OLD.IdUczen,OLD.IdLekcja,OLD.Typ,OLD.Data,OLD.Owner,OLD.ID,'D',vUser,NULL );
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `gmina`
--

DROP TABLE IF EXISTS `gmina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gmina` (
  `Kod` char(7) COLLATE utf8_polish_ci NOT NULL,
  `Nazwa` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Kod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gmina`
--

LOCK TABLES `gmina` WRITE;
/*!40000 ALTER TABLE `gmina` DISABLE KEYS */;
/*!40000 ALTER TABLE `gmina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gmina_typ`
--

DROP TABLE IF EXISTS `gmina_typ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gmina_typ` (
  `Kod` char(1) COLLATE utf8_polish_ci NOT NULL,
  `Nazwa` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `Komentarz` varchar(200) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Kod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gmina_typ`
--

LOCK TABLES `gmina_typ` WRITE;
/*!40000 ALTER TABLE `gmina_typ` DISABLE KEYS */;
/*!40000 ALTER TABLE `gmina_typ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupa`
--

DROP TABLE IF EXISTS `grupa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupa` (
  `ID` tinyint(1) unsigned NOT NULL,
  `Nr` tinyint(1) unsigned NOT NULL,
  `Nazwa` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `IdPrzedmiot` tinyint(3) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_grupa_przedmiot_idx` (`IdPrzedmiot`),
  CONSTRAINT `FK_grupa_przedmiot` FOREIGN KEY (`IdPrzedmiot`) REFERENCES `szkola_przedmiot` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupa`
--

LOCK TABLES `grupa` WRITE;
/*!40000 ALTER TABLE `grupa` DISABLE KEYS */;
/*!40000 ALTER TABLE `grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `harmonogram`
--

DROP TABLE IF EXISTS `harmonogram`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `harmonogram` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `IdSzkola` smallint(5) unsigned NOT NULL,
  `NrLekcji` tinyint(3) unsigned NOT NULL,
  `StartTime` time NOT NULL,
  `EndTime` time NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Index_2` (`StartTime`,`EndTime`,`IdSzkola`) USING BTREE,
  UNIQUE KEY `Index_4` (`NrLekcji`,`IdSzkola`),
  KEY `FK_godzina_lekcyjna_1` (`IdSzkola`),
  CONSTRAINT `FK_godzina_lekcyjna_1` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `harmonogram`
--

LOCK TABLES `harmonogram` WRITE;
/*!40000 ALTER TABLE `harmonogram` DISABLE KEYS */;
/*!40000 ALTER TABLE `harmonogram` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `indywidualny_program`
--

DROP TABLE IF EXISTS `indywidualny_program`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `indywidualny_program` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Tresc` text COLLATE utf8_polish_ci NOT NULL,
  `IdUczen` int(10) unsigned NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `idxIdUczen` (`IdUczen`),
  CONSTRAINT `FK_IdUczen` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `indywidualny_program`
--

LOCK TABLES `indywidualny_program` WRITE;
/*!40000 ALTER TABLE `indywidualny_program` DISABLE KEYS */;
/*!40000 ALTER TABLE `indywidualny_program` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klasa`
--

DROP TABLE IF EXISTS `klasa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `klasa` (
  `Kod` varchar(3) COLLATE utf8_polish_ci NOT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Kod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klasa`
--

LOCK TABLES `klasa` WRITE;
/*!40000 ALTER TABLE `klasa` DISABLE KEYS */;
/*!40000 ALTER TABLE `klasa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klasyfikacja`
--

DROP TABLE IF EXISTS `klasyfikacja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `klasyfikacja` (
  `IdObsada` int(10) unsigned NOT NULL,
  `Typ` enum('S','R') COLLATE utf8_polish_ci NOT NULL,
  `Status` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdObsada`,`Typ`),
  CONSTRAINT `FK_klasyfikacja_1` FOREIGN KEY (`IdObsada`) REFERENCES `obsada` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klasyfikacja`
--

LOCK TABLES `klasyfikacja` WRITE;
/*!40000 ALTER TABLE `klasyfikacja` DISABLE KEYS */;
/*!40000 ALTER TABLE `klasyfikacja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kolumna`
--

DROP TABLE IF EXISTS `kolumna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kolumna` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NrKolumny` tinyint(3) unsigned NOT NULL,
  `IdObsada` int(10) unsigned NOT NULL DEFAULT '0',
  `IdOpis` int(10) unsigned DEFAULT NULL,
  `Typ` enum('C1','C2','S','R') COLLATE utf8_polish_ci NOT NULL,
  `Waga` decimal(2,1) unsigned NOT NULL DEFAULT '1.0',
  `Poprawa` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Lock` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `fk_opiskolumny3_idx` (`NrKolumny`,`IdObsada`,`Typ`),
  KEY `fk_kolumna_obsada` (`IdObsada`),
  KEY `FK_OpisWyniku` (`IdOpis`),
  CONSTRAINT `FK_OpisWyniku` FOREIGN KEY (`IdOpis`) REFERENCES `opis_wyniku` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `FK_kolumna_2` FOREIGN KEY (`IdObsada`) REFERENCES `obsada` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kolumna`
--

LOCK TABLES `kolumna` WRITE;
/*!40000 ALTER TABLE `kolumna` DISABLE KEYS */;
/*!40000 ALTER TABLE `kolumna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lekcja`
--

DROP TABLE IF EXISTS `lekcja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lekcja` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `IdPlan` tinyint(3) unsigned NOT NULL,
  `IdObsada` int(10) unsigned NOT NULL,
  `IdGodzina` tinyint(3) unsigned NOT NULL,
  `IdGrupa` tinyint(1) unsigned DEFAULT NULL,
  `DzienTygodnia` enum('1','2','3','4','5','6','0') COLLATE utf8_polish_ci DEFAULT NULL COMMENT '1 - poniedziałek, 2 - wtorek, 3 - środa, 4 - czwartek, 5 - piątek, 6 - sobota, 0 - niedziela',
  `Sala` varchar(20) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxLekcja` (`IdGodzina`,`DzienTygodnia`,`IdObsada`,`IdPlan`),
  KEY `FK_rozklad_plan_idx` (`IdPlan`),
  KEY `FK_rozklad_obsada_idx` (`IdObsada`),
  KEY `FK_lekcja_3` (`IdGodzina`),
  KEY `FK_Grupa_idx` (`IdGrupa`),
  CONSTRAINT `FK_lekcja_3` FOREIGN KEY (`IdGodzina`) REFERENCES `harmonogram` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_rozklad_plan` FOREIGN KEY (`IdPlan`) REFERENCES `plan_lekcji` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_lekcja_obsada` FOREIGN KEY (`IdObsada`) REFERENCES `obsada` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_Grupa` FOREIGN KEY (`IdGrupa`) REFERENCES `grupa` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lekcja`
--

LOCK TABLES `lekcja` WRITE;
/*!40000 ALTER TABLE `lekcja` DISABLE KEYS */;
/*!40000 ALTER TABLE `lekcja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `miejsce_typ`
--

DROP TABLE IF EXISTS `miejsce_typ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `miejsce_typ` (
  `Kod` char(2) COLLATE utf8_polish_ci NOT NULL,
  `Nazwa` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Kod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miejsce_typ`
--

LOCK TABLES `miejsce_typ` WRITE;
/*!40000 ALTER TABLE `miejsce_typ` DISABLE KEYS */;
/*!40000 ALTER TABLE `miejsce_typ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `miejscowosc`
--

DROP TABLE IF EXISTS `miejscowosc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `miejscowosc` (
  `ID` mediumint(8) unsigned NOT NULL AUTO_INCREMENT,
  `Kod` CHAR(7) NULL,
  `Nazwa` varchar(100) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `NazwaMiejscownik` varchar(100) COLLATE utf8_polish_ci DEFAULT NULL,
  `Polska` bit(1) DEFAULT b'1',
  `Poczta` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `KodPocztowy` char(5) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_Kod_SIMC_idx` (`Kod`),
  CONSTRAINT `FK_Kod_SIMC` FOREIGN KEY (`Kod`) REFERENCES `simc` (`sym`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miejscowosc`
--

LOCK TABLES `miejscowosc` WRITE;
/*!40000 ALTER TABLE `miejscowosc` DISABLE KEYS */;
/*!40000 ALTER TABLE `miejscowosc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `min_lekcja`
--

DROP TABLE IF EXISTS `min_lekcja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `min_lekcja` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Klasa` int(10) unsigned NOT NULL,
  `Przedmiot` tinyint(3) unsigned NOT NULL,
  `RokSzkolny` char(9) COLLATE utf8_polish_ci NOT NULL,
  `Wartosc` tinyint(3) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `min_lekcja-szkola_klasa_idx` (`Klasa`),
  KEY `min_lekcja-szkola_przedmiot_idx` (`Przedmiot`),
  CONSTRAINT `min_lekcja-przedmiot` FOREIGN KEY (`Przedmiot`) REFERENCES `przedmiot` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `min_lekcja-szkola_klasa` FOREIGN KEY (`Klasa`) REFERENCES `szkola_klasa` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `min_lekcja`
--

LOCK TABLES `min_lekcja` WRITE;
/*!40000 ALTER TABLE `min_lekcja` DISABLE KEYS */;
/*!40000 ALTER TABLE `min_lekcja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nauczanie_indywidualne`
--

DROP TABLE IF EXISTS `nauczanie_indywidualne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nauczanie_indywidualne` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdPrzydzial` int(10) unsigned NOT NULL,
  `IdObsada` int(10) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PrzydzialObsadaUnique` (`IdPrzydzial`,`IdObsada`),
  KEY `Indywidual_przydzial_idx` (`IdPrzydzial`),
  KEY `Indywidual_obsada_idx` (`IdObsada`),
  CONSTRAINT `Indywidual_obsada` FOREIGN KEY (`IdObsada`) REFERENCES `obsada` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Indywidual_przydzial` FOREIGN KEY (`IdPrzydzial`) REFERENCES `przydzial` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nauczanie_indywidualne`
--

LOCK TABLES `nauczanie_indywidualne` WRITE;
/*!40000 ALTER TABLE `nauczanie_indywidualne` DISABLE KEYS */;
/*!40000 ALTER TABLE `nauczanie_indywidualne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `obsada`
--

DROP TABLE IF EXISTS `obsada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `obsada` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Klasa` int(10) unsigned NOT NULL,
  `Przedmiot` tinyint(3) unsigned NOT NULL,
  `Grupa` bit(1) NOT NULL DEFAULT b'0',
  `Kategoria` enum('o','n') COLLATE utf8_polish_ci NOT NULL DEFAULT 'o',
  `Srednia` bit(1) NOT NULL DEFAULT b'1',
  `Klasyfikacja` bit(1) NOT NULL DEFAULT b'1',
  `DataAktywacji` datetime NOT NULL,
  `DataDeaktywacji` datetime DEFAULT NULL,
  `LiczbaGodzin` decimal(3,1) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IsObsadaVirtual` (`Klasa`,`Przedmiot`),
  KEY `FK_obsada_szkola_przedmiot_idx` (`Przedmiot`),
  KEY `FK_obsada_szkola_klasa_idx` (`Klasa`),
  CONSTRAINT `FK_obsada_szkola_klasa` FOREIGN KEY (`Klasa`) REFERENCES `szkola_klasa` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_obsada_szkola_przedmiot` FOREIGN KEY (`Przedmiot`) REFERENCES `szkola_przedmiot` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `obsada`
--

LOCK TABLES `obsada` WRITE;
/*!40000 ALTER TABLE `obsada` DISABLE KEYS */;
/*!40000 ALTER TABLE `obsada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ocena_opisowa`
--

DROP TABLE IF EXISTS `ocena_opisowa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ocena_opisowa` (
  `IdWynik` int(10) unsigned NOT NULL,
  `Tresc` text COLLATE utf8_polish_ci,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdWynik`),
  CONSTRAINT `FKWynik` FOREIGN KEY (`IdWynik`) REFERENCES `wynik` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ocena_opisowa`
--

LOCK TABLES `ocena_opisowa` WRITE;
/*!40000 ALTER TABLE `ocena_opisowa` DISABLE KEYS */;
/*!40000 ALTER TABLE `ocena_opisowa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcje`
--

DROP TABLE IF EXISTS `opcje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opcje` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `Value` text COLLATE utf8_polish_ci NOT NULL,
  `Type` enum('G','C') COLLATE utf8_polish_ci NOT NULL COMMENT 'G - opcja dotycząca całego dziennika, C - opcja dotycząca tylko modułu wypisywania świadectw',
  `Description` text COLLATE utf8_polish_ci,
  `IdSchool` smallint(5) unsigned DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_opcje_1` (`IdSchool`),
  CONSTRAINT `FK_opcje_1` FOREIGN KEY (`IdSchool`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcje`
--

LOCK TABLES `opcje` WRITE;
/*!40000 ALTER TABLE `opcje` DISABLE KEYS */;
/*!40000 ALTER TABLE `opcje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opis_wyniku`
--

DROP TABLE IF EXISTS `opis_wyniku`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opis_wyniku` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nazwa` varchar(100) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `IdPrzedmiot` tinyint(3) unsigned NOT NULL,
  `KolorHex` char(7) COLLATE utf8_polish_ci DEFAULT '#000000',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxNazwa` (`Nazwa`,`IdPrzedmiot`),
  KEY `OpisPrzedmiot_idx` (`IdPrzedmiot`),
  CONSTRAINT `OpisPrzedmiot` FOREIGN KEY (`IdPrzedmiot`) REFERENCES `przedmiot` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opis_wyniku`
--

LOCK TABLES `opis_wyniku` WRITE;
/*!40000 ALTER TABLE `opis_wyniku` DISABLE KEYS */;
/*!40000 ALTER TABLE `opis_wyniku` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `osiagniecia`
--

DROP TABLE IF EXISTS `osiagniecia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `osiagniecia` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Tresc` text COLLATE utf8_polish_ci NOT NULL,
  `Priorytet` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Data` date NOT NULL,
  `IdUczen` int(10) unsigned NOT NULL,
  `choice` tinyint(1) DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `idxIdUczen` (`IdUczen`),
  CONSTRAINT `FK_osiagniecia_1` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osiagniecia`
--

LOCK TABLES `osiagniecia` WRITE;
/*!40000 ALTER TABLE `osiagniecia` DISABLE KEYS */;
/*!40000 ALTER TABLE `osiagniecia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plan_lekcji`
--

DROP TABLE IF EXISTS `plan_lekcji`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plan_lekcji` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `Nazwa` varchar(45) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `IdSzkola` smallint(5) unsigned NOT NULL DEFAULT '0',
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL,
  `Lock` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_plan_lekcji_1` (`IdSzkola`),
  CONSTRAINT `FK_plan_lekcji_1` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plan_lekcji`
--

LOCK TABLES `plan_lekcji` WRITE;
/*!40000 ALTER TABLE `plan_lekcji` DISABLE KEYS */;
/*!40000 ALTER TABLE `plan_lekcji` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poprawka`
--

DROP TABLE IF EXISTS `poprawka`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `poprawka` (
  `IdPrzydzial` int(10) unsigned NOT NULL,
  `IdObsada` int(10) unsigned NOT NULL,
  `Typ` enum('S','R') COLLATE utf8_polish_ci NOT NULL,
  `IdOcena` tinyint(3) unsigned DEFAULT NULL,
  `Data` datetime DEFAULT NULL,
  `Lock` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdPrzydzial`,`IdObsada`,`Typ`),
  KEY `FK_poprawka_2` (`IdObsada`),
  KEY `FK_poprawka_3` (`IdOcena`),
  CONSTRAINT `FK_poprawka_1` FOREIGN KEY (`IdPrzydzial`) REFERENCES `przydzial` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_poprawka_2` FOREIGN KEY (`IdObsada`) REFERENCES `obsada` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_poprawka_3` FOREIGN KEY (`IdOcena`) REFERENCES `skala_ocen` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poprawka`
--

LOCK TABLES `poprawka` WRITE;
/*!40000 ALTER TABLE `poprawka` DISABLE KEYS */;
/*!40000 ALTER TABLE `poprawka` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `powiat`
--

DROP TABLE IF EXISTS `powiat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `powiat` (
  `Kod` char(4) COLLATE utf8_polish_ci NOT NULL,
  `Nazwa` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Kod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `powiat`
--

LOCK TABLES `powiat` WRITE;
/*!40000 ALTER TABLE `powiat` DISABLE KEYS */;
/*!40000 ALTER TABLE `powiat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projekt`
--

DROP TABLE IF EXISTS `projekt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projekt` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Temat` tinytext COLLATE utf8_polish_ci NOT NULL,
  `IdNauczyciel` smallint(5) unsigned NOT NULL,
  `Status` tinyint(1) unsigned NOT NULL,
  `RokSzkolny` char(9) COLLATE utf8_polish_ci NOT NULL,
  `LiczbaUczniow` tinyint(3) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `ProjektNauczyciel_idx` (`IdNauczyciel`),
  CONSTRAINT `ProjektNauczyciel` FOREIGN KEY (`IdNauczyciel`) REFERENCES `szkola_nauczyciel` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projekt`
--

LOCK TABLES `projekt` WRITE;
/*!40000 ALTER TABLE `projekt` DISABLE KEYS */;
/*!40000 ALTER TABLE `projekt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `przedmiot`
--

DROP TABLE IF EXISTS `przedmiot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `przedmiot` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `Alias` varchar(50) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Nazwa` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Typ` enum('P','Z','F') COLLATE utf8_polish_ci NOT NULL COMMENT 'P - przedmiot, Z - zachowanie, F - fakultet',
  `Priorytet` tinyint(1) unsigned DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxAlias` (`Alias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `przedmiot`
--

LOCK TABLES `przedmiot` WRITE;
/*!40000 ALTER TABLE `przedmiot` DISABLE KEYS */;
/*!40000 ALTER TABLE `przedmiot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `przydzial`
--

DROP TABLE IF EXISTS `przydzial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `przydzial` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL,
  `IdKlasa` int(10) unsigned NOT NULL,
  `NrwDzienniku` tinyint(3) unsigned DEFAULT NULL,
  `Promocja` bit(1) NOT NULL DEFAULT b'0',
  `StatusAktywacji` bit(1) NOT NULL DEFAULT b'1',
  `DataAktywacji` datetime DEFAULT NULL,
  `DataDeaktywacji` datetime DEFAULT NULL,
  `MasterRecord` bit(1) NOT NULL DEFAULT b'1',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxIdUczenKlasaRokSzk` (`IdUczen`,`IdKlasa`),
  KEY `UczenKey_idx` (`IdUczen`),
  KEY `FK_przydzial_szkola_klasa_idx` (`IdKlasa`),
  CONSTRAINT `FK_przydzial_szkola_klasa` FOREIGN KEY (`IdKlasa`) REFERENCES `szkola_klasa` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `UczenKey` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `przydzial`
--

LOCK TABLES `przydzial` WRITE;
/*!40000 ALTER TABLE `przydzial` DISABLE KEYS */;
/*!40000 ALTER TABLE `przydzial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `przywilej`
--

DROP TABLE IF EXISTS `przywilej`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `przywilej` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdObsada` int(10) unsigned NOT NULL,
  `IdNauczyciel` smallint(5) unsigned NOT NULL,
  `Typ` bit(1) NOT NULL DEFAULT b'1',
  `Status` bit(1) NOT NULL DEFAULT b'1',
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `Wirtual_Obsada_idx` (`IdObsada`),
  KEY `Wirtual_Nauczyciel_idx` (`IdNauczyciel`),
  CONSTRAINT `Wirtual_Nauczyciel` FOREIGN KEY (`IdNauczyciel`) REFERENCES `szkola_nauczyciel` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Wirtual_Obsada` FOREIGN KEY (`IdObsada`) REFERENCES `obsada` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `przywilej`
--

LOCK TABLES `przywilej` WRITE;
/*!40000 ALTER TABLE `przywilej` DISABLE KEYS */;
/*!40000 ALTER TABLE `przywilej` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reklamacja`
--

DROP TABLE IF EXISTS `reklamacja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reklamacja` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL,
  `IdLekcja` int(10) unsigned NOT NULL,
  `Typ` enum('u','n','s') COLLATE utf8_polish_ci NOT NULL,
  `DataLekcji` date NOT NULL,
  `AbsenceOwner` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `AbsenceNotifier` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `NotifyDate` date NOT NULL,
  `Status` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Komentarz` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reklamacja`
--

LOCK TABLES `reklamacja` WRITE;
/*!40000 ALTER TABLE `reklamacja` DISABLE KEYS */;
/*!40000 ALTER TABLE `reklamacja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `simc`
--

DROP TABLE IF EXISTS `simc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `simc` (
  `woj` CHAR(2) NOT NULL,
  `pow` CHAR(2) NOT NULL,
  `gmi` CHAR(2) NOT NULL,
  `rodz_gmi` CHAR(1) NOT NULL,
  `rm` CHAR(2) NULL,
  `mz` CHAR(1) NULL,
  `nazwa` VARCHAR(56) NULL,
  `sym` CHAR(7) NOT NULL,
  `sympodst` CHAR(7) NOT NULL,
  `stan_na` date DEFAULT NULL,
  PRIMARY KEY (`sym`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `simc`
--

LOCK TABLES `simc` WRITE;
/*!40000 ALTER TABLE `simc` DISABLE KEYS */;
/*!40000 ALTER TABLE `simc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skala_ocen`
--

DROP TABLE IF EXISTS `skala_ocen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skala_ocen` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `IdSzkola` SMALLINT(5) UNSIGNED NULL,
  `Ocena` char(3) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Nazwa` varchar(20) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Alias` varchar(6) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Waga` decimal(3,2) NOT NULL,
  `Typ` enum('P','Z','PZ') COLLATE utf8_polish_ci NOT NULL DEFAULT 'P' COMMENT 'P - przedmiot; Z - Zachowanie; PZ - przedmiot i zachowanie',
  `PodTyp` enum('C','K','CK') COLLATE utf8_polish_ci NOT NULL DEFAULT 'C' COMMENT 'C - tylko cząstkowa; K - tylko końcowa; CK - cząstkowa i końcowa',
  `SortOrder` tinyint(1) unsigned DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  INDEX `Skala_Szkola_idx` (`IdSzkola` ASC),
  CONSTRAINT `Skala_Szkola`
    FOREIGN KEY (`IdSzkola`)
    REFERENCES `belfer2`.`szkola` (`ID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skala_ocen`
--

LOCK TABLES `skala_ocen` WRITE;
/*!40000 ALTER TABLE `skala_ocen` DISABLE KEYS */;
/*!40000 ALTER TABLE `skala_ocen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sklad_grupa`
--

DROP TABLE IF EXISTS `sklad_grupa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sklad_grupa` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdPrzydzial` int(10) unsigned NOT NULL,
  `IdGrupa` tinyint(1) unsigned NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `Grupa_Przydzial_idx` (`IdPrzydzial`),
  KEY `Grupa_grupa_idx` (`IdGrupa`),
  CONSTRAINT `Grupa_Przydzial` FOREIGN KEY (`IdPrzydzial`) REFERENCES `przydzial` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Grupa_grupa` FOREIGN KEY (`IdGrupa`) REFERENCES `grupa` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sklad_grupa`
--

LOCK TABLES `sklad_grupa` WRITE;
/*!40000 ALTER TABLE `sklad_grupa` DISABLE KEYS */;
/*!40000 ALTER TABLE `sklad_grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subwniosek`
--

DROP TABLE IF EXISTS `subwniosek`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subwniosek` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdWniosek` int(10) unsigned NOT NULL,
  `StudentName` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `StudentGivenName` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `StudentPesel` varchar(11) COLLATE utf8_polish_ci NOT NULL,
  `Status` tinyint(1) unsigned NOT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_Wniosek` (`IdWniosek`),
  CONSTRAINT `FK_Wniosek` FOREIGN KEY (`IdWniosek`) REFERENCES `wniosek` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subwniosek`
--

LOCK TABLES `subwniosek` WRITE;
/*!40000 ALTER TABLE `subwniosek` DISABLE KEYS */;
/*!40000 ALTER TABLE `subwniosek` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `szkola`
--

DROP TABLE IF EXISTS `szkola`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `szkola` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `IdTypSzkoly` tinyint(3) unsigned NOT NULL,
  `Nazwa` varchar(100) COLLATE utf8_polish_ci DEFAULT NULL,
  `Alias` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `NIP` varchar(10) COLLATE utf8_polish_ci DEFAULT NULL,
  `Ulica` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Nr` varchar(5) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdMiejscowosc` mediumint(8) unsigned DEFAULT NULL,
  `Telefon` varchar(10) COLLATE utf8_polish_ci DEFAULT NULL,
  `Fax` varchar(10) COLLATE utf8_polish_ci DEFAULT NULL,
  `Email` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `IsDefault` tinyint(1) DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxAlias` (`Alias`),
  UNIQUE KEY `idxNIP` (`NIP`),
  KEY `FK_szkola_typy_szkol_idx` (`IdTypSzkoly`),
  KEY `FK_szkola_miejscowosc_idx` (`IdMiejscowosc`),
  CONSTRAINT `FK_szkola_miejscowosc` FOREIGN KEY (`IdMiejscowosc`) REFERENCES `miejscowosc` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `FK_szkola_typy_szkol` FOREIGN KEY (`IdTypSzkoly`) REFERENCES `typy_szkol` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `szkola`
--

LOCK TABLES `szkola` WRITE;
/*!40000 ALTER TABLE `szkola` DISABLE KEYS */;
/*!40000 ALTER TABLE `szkola` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `szkola_klasa`
--

DROP TABLE IF EXISTS `szkola_klasa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `szkola_klasa` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdSzkola` smallint(5) unsigned NOT NULL,
  `KodKlasy` varchar(3) COLLATE utf8_polish_ci NOT NULL,
  `RokSzkolny` varchar(9) COLLATE utf8_polish_ci NOT NULL,
  `NazwaKlasy` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Virtual` bit(1) NOT NULL DEFAULT b'0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idx_unique_szkola_klasa_rok` (`IdSzkola`,`KodKlasy`,`RokSzkolny`),
  KEY `fk_szkola_klasa_klasa_idx` (`KodKlasy`),
  KEY `fk_szkolaklasa_szkola_idx` (`IdSzkola`),
  CONSTRAINT `fk_szkolaklasa_klasa` FOREIGN KEY (`KodKlasy`) REFERENCES `klasa` (`Kod`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_szkolaklasa_szkola` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `szkola_klasa`
--

LOCK TABLES `szkola_klasa` WRITE;
/*!40000 ALTER TABLE `szkola_klasa` DISABLE KEYS */;
/*!40000 ALTER TABLE `szkola_klasa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `szkola_nauczyciel`
--

DROP TABLE IF EXISTS `szkola_nauczyciel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `szkola_nauczyciel` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `IdSzkola` smallint(5) unsigned NOT NULL,
  `Nauczyciel` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `Status` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `Role` TINYINT(1) UNSIGNED NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_szkola_nauczyciel_szkola_idx` (`IdSzkola`),
  KEY `FK_sn_user_idx` (`Nauczyciel`),
  CONSTRAINT `FK_sn_user` FOREIGN KEY (`Nauczyciel`) REFERENCES `user` (`Login`) ON UPDATE CASCADE,
  CONSTRAINT `FK_szkola_nauczyciel_szkola` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `szkola_nauczyciel`
--

LOCK TABLES `szkola_nauczyciel` WRITE;
/*!40000 ALTER TABLE `szkola_nauczyciel` DISABLE KEYS */;
/*!40000 ALTER TABLE `szkola_nauczyciel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `szkola_przedmiot`
--

DROP TABLE IF EXISTS `szkola_przedmiot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `szkola_przedmiot` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `IdSzkola` smallint(5) unsigned NOT NULL,
  `IdPrzedmiot` tinyint(3) unsigned NOT NULL,
  `Priorytet` tinyint(1) unsigned DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxSzkolaPrzedmiotGrupa` (`IdSzkola`,`IdPrzedmiot`),
  KEY `FK_szkola_przedmiot_2` (`IdPrzedmiot`),
  KEY `FK_szkola_przedmiot_szkola_idx` (`IdSzkola`),
  CONSTRAINT `FK_SzkolaPrzedmiot_Szkola` FOREIGN KEY (`IdSzkola`) REFERENCES `szkola` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_szkola_przedmiot_2` FOREIGN KEY (`IdPrzedmiot`) REFERENCES `przedmiot` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `szkola_przedmiot`
--

LOCK TABLES `szkola_przedmiot` WRITE;
/*!40000 ALTER TABLE `szkola_przedmiot` DISABLE KEYS */;
/*!40000 ALTER TABLE `szkola_przedmiot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temat`
--

DROP TABLE IF EXISTS `temat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temat` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nr` tinyint(3) unsigned DEFAULT NULL,
  `Tresc` varchar(150) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdLekcja` smallint(5) unsigned NOT NULL,
  `Data` date NOT NULL,
  `Status` tinyint(1) unsigned DEFAULT '1',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_Temat_Lekcja_idx` (`IdLekcja`),
  CONSTRAINT `FK_Temat_Lekcja` FOREIGN KEY (`IdLekcja`) REFERENCES `lekcja` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temat`
--

LOCK TABLES `temat` WRITE;
/*!40000 ALTER TABLE `temat` DISABLE KEYS */;
/*!40000 ALTER TABLE `temat` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `belfer2`.`temat_before_delete`
BEFORE DELETE ON `belfer2`.`temat`
FOR EACH ROW
BEGIN
DECLARE vUser varchar(50);

   
   SELECT USER() INTO vUser;
   
   
   INSERT INTO back_temat
   (ID,Nr,Tresc,IdLekcja,Data,Status,Owner,IdTemat,Type,User,Version) VALUES ( NULL,OLD.Nr,OLD.Tresc,OLD.IdLekcja,OLD.Data,OLD.Status,OLD.Owner,OLD.ID,'D',vUser,NULL);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `terminarz`
--

DROP TABLE IF EXISTS `terminarz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `terminarz` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdLekcja` smallint(5) unsigned NOT NULL,
  `Info` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `Data` date NOT NULL,
  `Status` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `TerminLekcja_idx` (`IdLekcja`),
  CONSTRAINT `TerminLekcja` FOREIGN KEY (`IdLekcja`) REFERENCES `lekcja` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terminarz`
--

LOCK TABLES `terminarz` WRITE;
/*!40000 ALTER TABLE `terminarz` DISABLE KEYS */;
/*!40000 ALTER TABLE `terminarz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typy_szkol`
--

DROP TABLE IF EXISTS `typy_szkol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `typy_szkol` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `Typ` varchar(45) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Opis` varchar(100) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typy_szkol`
--

LOCK TABLES `typy_szkol` WRITE;
/*!40000 ALTER TABLE `typy_szkol` DISABLE KEYS */;
/*!40000 ALTER TABLE `typy_szkol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uczen`
--

DROP TABLE IF EXISTS `uczen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uczen` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nazwisko` varchar(50) COLLATE utf8_polish_ci NOT NULL DEFAULT '',
  `Imie` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Imie2` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NrArkusza` int(10) unsigned DEFAULT NULL,
  `ImieOjca` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NazwiskoOjca` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ImieMatki` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NazwiskoMatki` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `DataUr` date DEFAULT NULL,
  `Pesel` varchar(11) COLLATE utf8_polish_ci DEFAULT NULL,
  `IdMiejsceUr` mediumint(8) unsigned DEFAULT NULL,
  `IdMiejsceZam` mediumint(8) unsigned DEFAULT NULL,
  `Ulica` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `NrDomu` varchar(5) COLLATE utf8_polish_ci DEFAULT NULL,
  `NrMieszkania` varchar(5) COLLATE utf8_polish_ci DEFAULT NULL,
  `Tel` varchar(9) COLLATE utf8_polish_ci DEFAULT NULL,
  `TelKom1` varchar(9) COLLATE utf8_polish_ci DEFAULT NULL,
  `TelKom2` varchar(9) COLLATE utf8_polish_ci DEFAULT NULL,
  `Man` tinyint(1) unsigned DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxNrArkusza` (`NrArkusza`),
  KEY `idxMiejsceUr` (`IdMiejsceUr`),
  KEY `FK_uczen_4_idx` (`IdMiejsceZam`),
  CONSTRAINT `FK_uczen_3` FOREIGN KEY (`IdMiejsceUr`) REFERENCES `miejscowosc` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_uczen_4` FOREIGN KEY (`IdMiejsceZam`) REFERENCES `miejscowosc` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uczen`
--

LOCK TABLES `uczen` WRITE;
/*!40000 ALTER TABLE `uczen` DISABLE KEYS */;
/*!40000 ALTER TABLE `uczen` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `belfer2`.`uczen_before_delete`
BEFORE DELETE ON `belfer2`.`uczen`
FOR EACH ROW
BEGIN
DECLARE vUser varchar(50);

   
   SELECT USER() INTO vUser;
   
   
   INSERT INTO back_uczen
   (ID,Nazwisko,Imie,Imie2,NrArkusza,ImieOjca,ImieMatki,NazwiskoMatki,DataUr,Pesel,IdMiejsceUr,IdMiejsceZam,Ulica,NrDomu,NrMieszkania,Tel,TelKom1,TelKom2,Man,Owner,IdUczen,Type,User,Version) VALUES 
   (NULL,OLD.Nazwisko,OLD.Imie,OLD.Imie2,OLD.NrArkusza,OLD.ImieOjca,OLD.ImieMatki,OLD.NazwiskoMatki,OLD.DataUr,OLD.Pesel,OLD.IdMiejsceUr,OLD.IdMiejsceZam,OLD.Ulica,OLD.NrDomu,OLD.NrMieszkania,OLD.Tel,OLD.TelKom1,OLD.TelKom2,OLD.Man,OLD.Owner,OLD.ID,'D',vUser,NULL);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `uprawnienie`
--

DROP TABLE IF EXISTS `uprawnienie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uprawnienie` (
  `UserLogin` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `IdUczen` int(10) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserLogin`,`IdUczen`),
  KEY `UserKey_idx` (`UserLogin`),
  KEY `StudentKey_idx` (`IdUczen`),
  CONSTRAINT `Uprawnienie_UczenKey` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `UserKey` FOREIGN KEY (`UserLogin`) REFERENCES `user` (`Login`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uprawnienie`
--

LOCK TABLES `uprawnienie` WRITE;
/*!40000 ALTER TABLE `uprawnienie` DISABLE KEYS */;
/*!40000 ALTER TABLE `uprawnienie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `Login` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Imie` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Sex` BIT NOT NULL DEFAULT 1,
  `Faximile` blob,
  `email` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Password` BINARY(64) NOT NULL,
  `Role` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Status` BIT NOT NULL DEFAULT 1,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('admin','Konto','wbudowane',1,NULL,NULL,'GyzhtimO+DfxHUDE3bu9SxpRohHAliJP7AuitbIlFX9XViJsCrSTaWiCIDAv2gTW',8,1,'Admin','Admin','localhost',NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `belfer2`.`user_before_update`
BEFORE UPDATE ON `belfer2`.`user`
FOR EACH ROW
BEGIN
DECLARE vUser varchar(50);

   
   SELECT USER() INTO vUser;
   
   
   INSERT INTO back_user
   ( ID,Login,Nazwisko,Imie,Password,Role,Status,Owner,Type,User,Version) VALUES ( NULL,OLD.Login,OLD.Nazwisko,OLD.Imie,OLD.Password,OLD.Role,OLD.Status,OLD.Owner,'U',vUser,NULL );
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `uwagi`
--

DROP TABLE IF EXISTS `uwagi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uwagi` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL DEFAULT '0',
  `TrescUwagi` text COLLATE utf8_polish_ci NOT NULL,
  `TypUwagi` enum('p','n') COLLATE utf8_polish_ci NOT NULL DEFAULT 'n',
  `Autor` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Data` datetime NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `idxUczen` (`IdUczen`),
  CONSTRAINT `FK_uwagi_1` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uwagi`
--

LOCK TABLES `uwagi` WRITE;
/*!40000 ALTER TABLE `uwagi` DISABLE KEYS */;
/*!40000 ALTER TABLE `uwagi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uzasadnienie`
--

DROP TABLE IF EXISTS `uzasadnienie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uzasadnienie` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdWynik` int(10) unsigned NOT NULL,
  `Tresc` text COLLATE utf8_polish_ci,
  `Status` tinyint(1) unsigned DEFAULT '0' COMMENT '0 - wprowadzone, 1- przekazane,2 - odrzucone, 3 - zatwierdzone',
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IdWynik_UNIQUE` (`IdWynik`),
  CONSTRAINT `UzasadnienieWynik` FOREIGN KEY (`IdWynik`) REFERENCES `wynik` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uzasadnienie`
--

LOCK TABLES `uzasadnienie` WRITE;
/*!40000 ALTER TABLE `uzasadnienie` DISABLE KEYS */;
/*!40000 ALTER TABLE `uzasadnienie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wniosek`
--

DROP TABLE IF EXISTS `wniosek`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wniosek` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ParentName` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `ParentGivenName` varchar(45) COLLATE utf8_polish_ci NOT NULL,
  `ParentEmail` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ParentLogin` varchar(10) COLLATE utf8_polish_ci DEFAULT NULL,
  `ParentIP` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `ApplyDate` datetime NOT NULL,
  `ApplyType` enum('NA','AP','RP') COLLATE utf8_polish_ci NOT NULL COMMENT 'NA - nowe konto, AP - dodaj  ucznia, RP - odzyskaj haslo',
  `Status` tinyint(1) unsigned NOT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wniosek`
--

LOCK TABLES `wniosek` WRITE;
/*!40000 ALTER TABLE `wniosek` DISABLE KEYS */;
/*!40000 ALTER TABLE `wniosek` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wojewodztwo`
--

DROP TABLE IF EXISTS `wojewodztwo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wojewodztwo` (
  `Kod` char(2) COLLATE utf8_polish_ci NOT NULL,
  `Nazwa` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Alias` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Kod`),
  UNIQUE KEY `idxNazwa` (`Nazwa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wojewodztwo`
--

LOCK TABLES `wojewodztwo` WRITE;
/*!40000 ALTER TABLE `wojewodztwo` DISABLE KEYS */;
/*!40000 ALTER TABLE `wojewodztwo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wykluczenie`
--

DROP TABLE IF EXISTS `wykluczenie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wykluczenie` (
  `IdPrzydzial` int(10) unsigned NOT NULL,
  `IdPrzywilej` int(10) unsigned NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdPrzydzial`,`IdPrzywilej`),
  KEY `FK_Przywilej_idx` (`IdPrzywilej`),
  KEY `FK_Przydzial_idx` (`IdPrzydzial`),
  CONSTRAINT `FK_Wyklucz_Przydzial` FOREIGN KEY (`IdPrzydzial`) REFERENCES `przydzial` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Wyklucz_Przywilej` FOREIGN KEY (`IdPrzywilej`) REFERENCES `przywilej` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wykluczenie`
--

LOCK TABLES `wykluczenie` WRITE;
/*!40000 ALTER TABLE `wykluczenie` DISABLE KEYS */;
/*!40000 ALTER TABLE `wykluczenie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wynik`
--

DROP TABLE IF EXISTS `wynik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wynik` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdUczen` int(10) unsigned NOT NULL,
  `IdOcena` tinyint(3) unsigned NOT NULL,
  `IdKolumna` int(10) unsigned NOT NULL,
  `Data` datetime NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxUczenKolumna` (`IdUczen`,`IdKolumna`),
  KEY `idxOcena` (`IdOcena`),
  KEY `idxUczen` (`IdUczen`),
  KEY `idxPrzedmiot` (`IdKolumna`),
  CONSTRAINT `FK_wyniki_1` FOREIGN KEY (`IdKolumna`) REFERENCES `kolumna` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_wyniki_3` FOREIGN KEY (`IdOcena`) REFERENCES `skala_ocen` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_wyniki_4` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wynik`
--

LOCK TABLES `wynik` WRITE;
/*!40000 ALTER TABLE `wynik` DISABLE KEYS */;
/*!40000 ALTER TABLE `wynik` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `belfer2`.`wynik_before_delete`
BEFORE DELETE ON `belfer2`.`wynik`
FOR EACH ROW
BEGIN
DECLARE vUser varchar(50);

   
   SELECT USER() INTO vUser;
   
   
   INSERT INTO back_wynik
   ( ID,IdUczen,IdOcena,IdKolumna,Data,Owner,IdWynik,Type,User,Version) VALUES ( NULL,OLD.IdUczen,OLD.IdOcena,OLD.IdKolumna,OLD.Data,OLD.Owner,OLD.ID,'D',vUser,NULL);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `zagrozenia`
--

DROP TABLE IF EXISTS `zagrozenia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zagrozenia` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdPrzydzial` int(10) unsigned NOT NULL,
  `IdPrzedmiot` tinyint(3) unsigned NOT NULL,
  `Semestr` enum('1','2') COLLATE utf8_polish_ci NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idxWarning` (`IdPrzydzial`,`IdPrzedmiot`,`Semestr`),
  KEY `FK_zagrozenia_1_idx` (`IdPrzydzial`),
  KEY `FK_zagrozenia_2_idx` (`IdPrzedmiot`),
  CONSTRAINT `FK_zagrozenia_1` FOREIGN KEY (`IdPrzydzial`) REFERENCES `przydzial` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_zagrozenia_2` FOREIGN KEY (`IdPrzedmiot`) REFERENCES `przedmiot` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zagrozenia`
--

LOCK TABLES `zagrozenia` WRITE;
/*!40000 ALTER TABLE `zagrozenia` DISABLE KEYS */;
/*!40000 ALTER TABLE `zagrozenia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zastepstwo`
--

DROP TABLE IF EXISTS `zastepstwo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zastepstwo` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdLekcja` smallint(5) unsigned NOT NULL,
  `IdNauczyciel` smallint(5) unsigned DEFAULT NULL,
  `IdPrzedmiot` tinyint(3) unsigned DEFAULT NULL,
  `IdGrupa` tinyint(1) unsigned DEFAULT NULL,
  `Data` date NOT NULL,
  `Status` tinyint(1) unsigned DEFAULT NULL,
  `Sala` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `fkZastepstwoNauczyciel_idx` (`IdNauczyciel`),
  KEY `fkZastepstwoPrzedmiot_idx` (`IdPrzedmiot`),
  KEY `fkZastepstwoLekcja_idx` (`IdLekcja`),
  KEY `fkZastepstwoGrupa_idx` (`IdGrupa`),
  CONSTRAINT `fkZastepstwoLekcja` FOREIGN KEY (`IdLekcja`) REFERENCES `lekcja` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fkZastepstwoNauczyciel` FOREIGN KEY (`IdNauczyciel`) REFERENCES `szkola_nauczyciel` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `fkZastepstwoPrzedmiot` FOREIGN KEY (`IdPrzedmiot`) REFERENCES `szkola_przedmiot` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `fkZastepstwoGrupa` FOREIGN KEY (`IdGrupa`) REFERENCES `grupa` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zastepstwo`
--

LOCK TABLES `zastepstwo` WRITE;
/*!40000 ALTER TABLE `zastepstwo` DISABLE KEYS */;
/*!40000 ALTER TABLE `zastepstwo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zespol_projekt`
--

DROP TABLE IF EXISTS `zespol_projekt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zespol_projekt` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdProjekt` int(10) unsigned NOT NULL,
  `IdUczen` int(10) unsigned NOT NULL,
  `Owner` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `User` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `ComputerIP` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `Version` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `ZespolProjekt_idx` (`IdProjekt`),
  KEY `ZespolUczen_idx` (`IdUczen`),
  CONSTRAINT `ZespolProjekt` FOREIGN KEY (`IdProjekt`) REFERENCES `projekt` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ZespolUczen` FOREIGN KEY (`IdUczen`) REFERENCES `uczen` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zespol_projekt`
--

LOCK TABLES `zespol_projekt` WRITE;
/*!40000 ALTER TABLE `zespol_projekt` DISABLE KEYS */;
/*!40000 ALTER TABLE `zespol_projekt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'belfer2'
--

--
-- Dumping routines for database 'belfer2'
--
/*!50003 DROP PROCEDURE IF EXISTS `ChangePassword` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `ChangePassword`(IN Nick varchar(10),IN NewPwd blob)
BEGIN
	UPDATE user SET Password=NewPwd WHERE Login=Nick;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertApplication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `InsertApplication`(IN ParentName varchar(45),IN ParentGivenName varchar(45),IN ParentEmail varchar(45),
IN ParentLogin varchar(10),IN AppType varchar(2),IN ParentIP varchar(15),OUT IdApplication int)
BEGIN
 	DECLARE vDate datetime;
  	SELECT NOW() INTO vDate;
	INSERT INTO wniosek VALUES(NULL,ParentName,ParentGivenName,ParentEmail,ParentLogin,ParentIP,vDate,AppType,1,NULL,NULL,NULL);
	SET IdApplication=LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertStudentRequest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `InsertStudentRequest`(IN IdApplication int,IN StudentName varchar(45),IN StudentGivenName varchar(45),
IN StudentPesel varchar(11))
BEGIN
	INSERT INTO subwniosek VALUES(NULL,IdApplication,StudentName,StudentGivenName,StudentPesel,0,NULL,NULL,NULL);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `LogIn` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `LogIn`(IN Nick varchar(10),IN IP varchar(15),IN LoginStatus tinyint(1),IN AppType enum('D','W'),IN AppVer varchar(7),OUT IdEvent int)
BEGIN
	INSERT INTO event VALUES(NULL,Nick,IP,LoginStatus,AppType,AppVer,NULL,NULL);
	SET IdEvent=LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `LogOut` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `LogOut`(IN IdRecord int)
BEGIN
	UPDATE event SET TimeOut=Now() WHERE ID=IdRecord;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PasswordRequest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `PasswordRequest`(IN ParentName varchar(45),IN ParentGivenName varchar(45),IN ParentLogin varchar(10),
IN ParentIP varchar(15),OUT IdApplication int)
BEGIN
	DECLARE vDate datetime;
  	SELECT NOW() INTO vDate;
	INSERT INTO wniosek VALUES(NULL,ParentName,ParentGivenName,NULL,ParentLogin,ParentIP,vDate,'RP',1,NULL,NULL,NULL);
	SET IdApplication=LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-04-20  8:57:47

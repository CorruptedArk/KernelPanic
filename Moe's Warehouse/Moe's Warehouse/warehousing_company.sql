-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: warehousing_company
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `Username` varchar(30) NOT NULL,
  `Password` varchar(25) NOT NULL,
  `EmailAddr` varchar(50) NOT NULL,
  PRIMARY KEY (`Username`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES ('Harry','Potter','hp@hogwarts.edu');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `Street` varchar(20) NOT NULL,
  `City` varchar(20) NOT NULL,
  `State` varchar(2) NOT NULL,
  `ZipCode` int(9) NOT NULL,
  `WareHouseSEQ` int(5) NOT NULL,
  `CUSTOMERcol` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`,`CUSTOMERcol`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer order`
--

DROP TABLE IF EXISTS `customer order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer order` (
  `OrderNum` varchar(6) NOT NULL,
  `ID` int(5) unsigned zerofill NOT NULL,
  `CustomerShipName` varchar(30) NOT NULL,
  `CustShipStreet` varchar(20) NOT NULL,
  `CustShipState` varchar(2) NOT NULL,
  `CustShipZip` int(9) unsigned zerofill NOT NULL,
  `ItemID` int(5) NOT NULL,
  `ReqQty` int(5) unsigned zerofill NOT NULL,
  `NumOfItems` int(3) unsigned zerofill NOT NULL,
  PRIMARY KEY (`OrderNum`),
  UNIQUE KEY `ID_UNIQUE` (`OrderNum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer order`
--

LOCK TABLES `customer order` WRITE;
/*!40000 ALTER TABLE `customer order` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item` (
  `ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Description` varchar(30) DEFAULT NULL,
  `Price` decimal(7,2) NOT NULL,
  `Quantity` int(5) NOT NULL,
  `Vendor Code` int(2) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendor`
--

DROP TABLE IF EXISTS `vendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendor` (
  `ID` int(2) unsigned zerofill NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Addr` varchar(45) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendor`
--

LOCK TABLES `vendor` WRITE;
/*!40000 ALTER TABLE `vendor` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendor order`
--

DROP TABLE IF EXISTS `vendor order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendor order` (
  `VendorID` int(2) unsigned zerofill NOT NULL,
  `ItemID` int(5) unsigned zerofill DEFAULT NULL,
  `ReorderQty` int(5) unsigned zerofill DEFAULT NULL,
  PRIMARY KEY (`VendorID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendor order`
--

LOCK TABLES `vendor order` WRITE;
/*!40000 ALTER TABLE `vendor order` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendor order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendor shipment`
--

DROP TABLE IF EXISTS `vendor shipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendor shipment` (
  `VendorID` int(2) unsigned zerofill NOT NULL,
  `ItemID` int(5) unsigned zerofill NOT NULL,
  `QtyRecv` int(6) unsigned zerofill NOT NULL,
  `DateReq` date NOT NULL,
  `DateRecv` date DEFAULT NULL,
  PRIMARY KEY (`VendorID`),
  UNIQUE KEY `VendorID_UNIQUE` (`VendorID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendor shipment`
--

LOCK TABLES `vendor shipment` WRITE;
/*!40000 ALTER TABLE `vendor shipment` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendor shipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouse`
--

DROP TABLE IF EXISTS `warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `warehouse` (
  `ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `Street` varchar(20) NOT NULL,
  `City` varchar(20) NOT NULL,
  `State` varchar(2) NOT NULL,
  `ZipCode` int(9) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouse`
--

LOCK TABLES `warehouse` WRITE;
/*!40000 ALTER TABLE `warehouse` DISABLE KEYS */;
/*!40000 ALTER TABLE `warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouse location`
--

DROP TABLE IF EXISTS `warehouse location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `warehouse location` (
  `WarehouseID` int(5) unsigned zerofill NOT NULL,
  `LocationID` int(3) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Capacity` int(5) unsigned zerofill NOT NULL,
  PRIMARY KEY (`LocationID`),
  UNIQUE KEY `ID_UNIQUE` (`WarehouseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouse location`
--

LOCK TABLES `warehouse location` WRITE;
/*!40000 ALTER TABLE `warehouse location` DISABLE KEYS */;
/*!40000 ALTER TABLE `warehouse location` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-19 14:22:41

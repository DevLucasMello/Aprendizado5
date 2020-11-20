CREATE DATABASE  IF NOT EXISTS `estacionamento` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `estacionamento`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: estacionamento
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.26-MariaDB

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
-- Table structure for table `cargo`
--

DROP TABLE IF EXISTS `cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cargo` (
  `id_cargo` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(20) NOT NULL,
  PRIMARY KEY (`id_cargo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
/*!40000 ALTER TABLE `cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `controle`
--

DROP TABLE IF EXISTS `controle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `controle` (
  `id_Controle` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCliente` varchar(80) NOT NULL,
  `dataHoraEntrada` varchar(30) NOT NULL,
  `dataHoraSaida` varchar(30) NOT NULL,
  `valorTotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_Controle`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `controle`
--

LOCK TABLES `controle` WRITE;
/*!40000 ALTER TABLE `controle` DISABLE KEYS */;
/*!40000 ALTER TABLE `controle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `endereco` (
  `id_endereco` int(11) NOT NULL AUTO_INCREMENT,
  `cep` int(11) NOT NULL,
  `rua` varchar(100) NOT NULL,
  `numero` int(11) NOT NULL,
  `complemento` varchar(30) NOT NULL,
  `cidade` varchar(50) NOT NULL,
  `uf` varchar(2) NOT NULL,
  `estado` varchar(50) NOT NULL,
  `pais` varchar(90) NOT NULL,
  PRIMARY KEY (`id_endereco`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endereco`
--

LOCK TABLES `endereco` WRITE;
/*!40000 ALTER TABLE `endereco` DISABLE KEYS */;
INSERT INTO `endereco` VALUES (1,8234,'Rua Jeribatuba',231,'Casa 01','São Paulo','SP','São Paulo','Brasil'),(2,8234,'Rua Jeribatuba',31,'Casa 02','São Paulo','SP','Diadema','Brasil'),(3,8235,'Rua Vitoria',2,'Casa 03','São Paulo','SP','Suzano','Brasil'),(4,8223,'Rua Paula',45,'Fundos','São Paulo','SP','Ferraz de Vasconcelos','Brasil'),(5,8267,'Av. Treze',12,'Fundos','São Paulo','SP','Santo Andre','Brasil'),(6,8290,'Rua Gigante Acordou',0,'Casa 04','São Paulo','SP','São Paulo','Brasil'),(7,8234,'Rua Brasil',10,'Casa 06','São Paulo','SP','São Paulo','Brasil'),(8,2234,'Linha Amarela',400,'Apto 12, 605','São Paulo','SP','São Paulo','Brasil'),(9,2235,'Rua Alvado Mendonça',550,'Casa 20','São Paulo','SP','São Paulo','Brasil'),(10,8236,'Travessa Paulo Alvarenga',31,'','São Bernardo do Campo','SP','São Paulo','Brasil');
/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `funcionario` (
  `id_funcionario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `dataNascimento` datetime NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `salario` double NOT NULL,
  PRIMARY KEY (`id_funcionario`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES (1,'Gabriela Lima','1997-05-17 00:00:00','(11) 98787-1212',5000),(2,'Allan Sobral','1980-05-17 00:00:00','(11) 98777-1212',5600),(3,'Aurelio Barbosa','1999-02-18 00:00:00','(11) 98777-1212',5780),(4,'Maria do Carmo','1965-04-15 00:00:00','(11) 98787-1222',6000),(5,'Aline Sandra','1997-02-13 00:00:00','(11) 98785-1522',8000),(6,'Derek Lais','1997-05-12 00:00:00','(11) 98787-1212',9000),(7,'Neyla Torraca','1997-05-17 00:00:00','(11) 98787-1212',15000),(8,'Carmem de Azevedo','1989-12-19 00:00:00','(11) 98787-1212',1200),(9,'Senor Abravanel','1945-12-18 00:00:00','(11) 98787-1212',13000),(10,'Corinthiano de Mendonça','1910-05-02 00:00:00','(11) 98787-1212',7000);
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mensalista`
--

DROP TABLE IF EXISTS `mensalista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mensalista` (
  `CPF` bigint(20) NOT NULL,
  `nome` varchar(80) NOT NULL,
  `celular` varchar(15) NOT NULL,
  `dataDePagamento` datetime NOT NULL,
  `valorMensal` double NOT NULL,
  PRIMARY KEY (`CPF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mensalista`
--

LOCK TABLES `mensalista` WRITE;
/*!40000 ALTER TABLE `mensalista` DISABLE KEYS */;
INSERT INTO `mensalista` VALUES (12345678910,'Allan Sobral','(11)98192-7329','0000-00-00 00:00:00',250),(12345678911,'Gabriela Lima','(11)95630-1212','0000-00-00 00:00:00',350),(12345678912,'Miguel Graciote','(11)98193-7429','0000-00-00 00:00:00',250),(12345678914,'Derek Lais','(11)98898-7329','0000-00-00 00:00:00',250),(12345678915,'Lais Derek','(11)91992-7329','0000-00-00 00:00:00',250),(12345678920,'Allan Sobral','(11)98192-7329','0000-00-00 00:00:00',250);
/*!40000 ALTER TABLE `mensalista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veiculo`
--

DROP TABLE IF EXISTS `veiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `veiculo` (
  `placa` varchar(10) NOT NULL,
  `tipo` varchar(30) NOT NULL,
  `modelo` varchar(50) NOT NULL,
  `cor` varchar(40) NOT NULL,
  PRIMARY KEY (`placa`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiculo`
--

LOCK TABLES `veiculo` WRITE;
/*!40000 ALTER TABLE `veiculo` DISABLE KEYS */;
INSERT INTO `veiculo` VALUES ('AGM3322','Moto','CG 150','Amarela'),('EZC1233','Carro','Ford Ka','Branco'),('FGH3321','Carro','Golf','Laranja'),('FGM3321','Carro','Fusca','Azul'),('FYK9090','Carro','Mercedes-Benz','Prata'),('GGM3321','Moto','PCX','Verde'),('LLO0990','Carro','Polo','Vermelho'),('MFM1221','Carro','Prisma','Azul'),('OGM3221','Moto','Hornet','Preta'),('WZA1212','Carro','UP','Preto');
/*!40000 ALTER TABLE `veiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'estacionamento'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-17 22:09:06

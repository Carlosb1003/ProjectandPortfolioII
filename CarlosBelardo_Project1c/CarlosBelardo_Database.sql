# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.7.25)
# Database: TW_Tracker
# Generation Time: 2019-07-26 04:23:53 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table activity
# ------------------------------------------------------------

DROP TABLE IF EXISTS `activity`;

CREATE TABLE `activity` (
  `activityId` int(11) NOT NULL,
  `activity` varchar(45) NOT NULL,
  PRIMARY KEY (`activityId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `activity` WRITE;
/*!40000 ALTER TABLE `activity` DISABLE KEYS */;

INSERT INTO `activity` (`activityId`, `activity`)
VALUES
	(1,'Run'),
	(2,'Walk'),
	(3,'Cycle'),
	(4,'Swim'),
	(5,'squash'),
	(6,'rugby'),
	(7,'hockey'),
	(8,'basketball'),
	(9,'boxing'),
	(10,'weight lifting'),
	(11,'atheletics'),
	(12,'climbing'),
	(13,'skiiing'),
	(14,'Rollar skating'),
	(15,'Tennis'),
	(16,'Badminton'),
	(17,'Netball'),
	(18,'Martial arts'),
	(19,'rowing'),
	(20,'table tennis'),
	(21,'football'),
	(22,'volleyball'),
	(23,'weight training'),
	(24,'jogging'),
	(25,'ice skating'),
	(26,'cricket'),
	(27,'gymnastics'),
	(28,'aerobics'),
	(29,'hiking'),
	(30,'horse riding'),
	(31,'canoeing'),
	(32,'shooting'),
	(33,'golf'),
	(34,'yoga'),
	(35,'social dancing'),
	(36,'bowling'),
	(37,'fishing'),
	(38,'motor sports'),
	(39,'archery'),
	(40,'baseball'),
	(41,'soccer'),
	(42,'wrestling'),
	(43,'softball'),
	(44,'skateboarding'),
	(45,'snowboarding'),
	(46,'figure skating'),
	(47,'pole vault'),
	(48,'boccie'),
	(49,'curling'),
	(50,'lacrosse'),
	(51,'raquet ball'),
	(52,'hand ball'),
	(53,'water polo'),
	(54,'bull fighting'),
	(55,'polo'),
	(56,'sledding'),
	(57,'surfing'),
	(58,'billiards'),
	(59,'jai alai'),
	(60,'handball'),
	(61,'dodgeball'),
	(62,'cheerleading'),
	(63,'fencing'),
	(64,'crossfit');

/*!40000 ALTER TABLE `activity` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Date
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Date`;

CREATE TABLE `Date` (
  `dateID` int(11) NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`dateID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Date` WRITE;
/*!40000 ALTER TABLE `Date` DISABLE KEYS */;

INSERT INTO `Date` (`dateID`, `date`)
VALUES
	(1,'2019-07-08'),
	(2,'2019-07-09'),
	(3,'2019-07-10'),
	(4,'2019-07-11'),
	(5,'2019-07-12'),
	(6,'2019-07-13'),
	(7,'2019-07-14'),
	(8,'2019-07-15'),
	(9,'2019-07-16'),
	(10,'2019-07-17'),
	(11,'2019-07-18'),
	(12,'2019-07-19'),
	(13,'2019-07-20'),
	(14,'2019-07-21'),
	(15,'2019-07-22'),
	(16,'2019-07-23'),
	(17,'2019-07-24'),
	(18,'2019-07-25'),
	(19,'2019-07-26'),
	(20,'2019-07-27'),
	(21,'2019-07-28'),
	(22,'2019-07-29'),
	(23,'2019-07-30'),
	(24,'2019-07-31'),
	(25,'2019-08-01'),
	(26,'2019-08-02'),
	(27,'2019-08-03'),
	(28,'2019-08-04'),
	(29,'2019-08-05'),
	(30,'2019-08-06'),
	(31,'2019-08-07'),
	(32,'2019-08-08'),
	(33,'2019-08-09'),
	(34,'2019-08-10'),
	(35,'2019-08-11'),
	(36,'2019-08-12'),
	(37,'2019-08-13'),
	(38,'2019-08-14'),
	(39,'2019-08-15'),
	(40,'2019-08-16'),
	(41,'2019-08-17'),
	(42,'2019-08-18'),
	(43,'2019-08-19'),
	(44,'2019-08-20'),
	(45,'2019-08-21'),
	(46,'2019-08-22'),
	(47,'2019-08-23'),
	(48,'2019-08-24'),
	(49,'2019-08-25'),
	(50,'2019-08-26'),
	(51,'2019-08-27'),
	(52,'2019-08-28'),
	(53,'2019-08-29'),
	(54,'2019-08-30'),
	(55,'2019-08-31'),
	(56,'2019-09-01'),
	(57,'2019-09-02'),
	(58,'2019-09-03'),
	(59,'2019-09-04'),
	(60,'2019-09-05'),
	(61,'2019-09-06'),
	(62,'2019-09-07'),
	(63,'2019-09-08'),
	(64,'2019-09-09'),
	(65,'2019-09-10'),
	(66,'2019-09-11'),
	(67,'2019-09-12'),
	(68,'2019-09-13'),
	(69,'2019-09-14'),
	(70,'2019-09-15'),
	(71,'2019-09-16'),
	(72,'2019-09-17'),
	(73,'2019-09-18'),
	(74,'2019-09-19'),
	(75,'2019-09-20'),
	(76,'2019-09-21'),
	(77,'2019-09-22'),
	(78,'2019-09-23'),
	(79,'2019-09-24'),
	(80,'2019-09-25'),
	(81,'2019-09-26'),
	(82,'2019-09-27'),
	(83,'2019-09-28'),
	(84,'2019-09-29'),
	(85,'2019-09-30'),
	(86,'2019-10-01'),
	(87,'2019-10-02'),
	(88,'2019-10-03'),
	(89,'2019-10-04'),
	(90,'2019-10-05'),
	(91,'2019-10-06'),
	(92,'2019-10-07'),
	(93,'2019-10-08'),
	(94,'2019-10-09'),
	(95,'2019-10-10'),
	(96,'2019-10-11'),
	(97,'2019-10-12'),
	(98,'2019-10-13'),
	(99,'2019-10-14'),
	(100,'2019-10-15'),
	(101,'2019-10-16'),
	(102,'2019-10-17'),
	(103,'2019-10-18'),
	(104,'2019-10-19'),
	(105,'2019-10-20'),
	(106,'2019-10-21'),
	(107,'2019-10-22'),
	(108,'2019-10-23'),
	(109,'2019-10-24'),
	(110,'2019-10-25'),
	(111,'2019-10-26'),
	(112,'2019-10-27'),
	(113,'2019-10-28'),
	(114,'2019-10-29'),
	(115,'2019-10-30'),
	(116,'2019-10-31'),
	(117,'2019-11-01'),
	(118,'2019-11-02'),
	(119,'2019-11-03'),
	(120,'2019-11-04'),
	(121,'2019-11-05'),
	(122,'2019-11-06'),
	(123,'2019-11-07'),
	(124,'2019-11-08'),
	(125,'2019-11-09'),
	(126,'2019-11-10'),
	(127,'2019-11-11'),
	(128,'2019-11-12'),
	(129,'2019-11-13'),
	(130,'2019-11-14'),
	(131,'2019-11-15'),
	(132,'2019-11-16'),
	(133,'2019-11-17'),
	(134,'2019-11-18'),
	(135,'2019-11-19'),
	(136,'2019-11-20'),
	(137,'2019-11-21'),
	(138,'2019-11-22'),
	(139,'2019-11-23'),
	(140,'2019-11-24'),
	(141,'2019-11-25'),
	(142,'2019-11-26'),
	(143,'2019-11-27'),
	(144,'2019-11-28'),
	(145,'2019-11-29'),
	(146,'2019-11-30'),
	(147,'2019-12-01'),
	(148,'2019-12-02'),
	(149,'2019-12-03'),
	(150,'2019-12-04'),
	(151,'2019-12-05'),
	(152,'2019-12-06'),
	(153,'2019-12-07'),
	(154,'2019-12-08'),
	(155,'2019-12-09'),
	(156,'2019-12-10'),
	(157,'2019-12-11'),
	(158,'2019-12-12'),
	(159,'2019-12-13'),
	(160,'2019-12-14'),
	(161,'2019-12-15'),
	(162,'2019-12-16'),
	(163,'2019-12-17'),
	(164,'2019-12-18'),
	(165,'2019-12-19'),
	(166,'2019-12-20'),
	(167,'2019-12-21'),
	(168,'2019-12-22'),
	(169,'2019-12-23'),
	(170,'2019-12-24'),
	(171,'2019-12-25'),
	(172,'2019-12-26'),
	(173,'2019-12-27'),
	(174,'2019-12-28'),
	(175,'2019-12-29'),
	(176,'2019-12-30'),
	(177,'2019-12-31'),
	(178,'2020-01-01'),
	(179,'2020-01-02'),
	(180,'2020-01-03'),
	(181,'2020-01-04'),
	(182,'2020-01-05'),
	(183,'2020-01-06'),
	(184,'2020-01-07'),
	(185,'2020-01-08'),
	(186,'2020-01-09'),
	(187,'2020-01-10'),
	(188,'2020-01-11'),
	(189,'2020-01-12'),
	(190,'2020-01-13'),
	(191,'2020-01-14'),
	(192,'2020-01-15'),
	(193,'2020-01-16'),
	(194,'2020-01-17'),
	(195,'2020-01-18'),
	(196,'2020-01-19'),
	(197,'2020-01-20'),
	(198,'2020-01-21'),
	(199,'2020-01-22'),
	(200,'2020-01-23'),
	(201,'2020-01-24'),
	(202,'2020-01-25'),
	(203,'2020-01-26'),
	(204,'2020-01-27'),
	(205,'2020-01-28'),
	(206,'2020-01-29'),
	(207,'2020-01-30'),
	(208,'2020-01-31'),
	(209,'2020-02-01'),
	(210,'2020-02-02'),
	(211,'2020-02-03'),
	(212,'2020-02-04'),
	(213,'2020-02-05'),
	(214,'2020-02-06'),
	(215,'2020-02-07'),
	(216,'2020-02-08'),
	(217,'2020-02-09'),
	(218,'2020-02-10'),
	(219,'2020-02-11'),
	(220,'2020-02-12'),
	(221,'2020-02-13'),
	(222,'2020-02-14'),
	(223,'2020-02-15'),
	(224,'2020-02-16'),
	(225,'2020-02-17'),
	(226,'2020-02-18'),
	(227,'2020-02-19'),
	(228,'2020-02-20'),
	(229,'2020-02-21'),
	(230,'2020-02-22'),
	(231,'2020-02-23'),
	(232,'2020-02-24'),
	(233,'2020-02-25'),
	(234,'2020-02-26'),
	(235,'2020-02-27'),
	(236,'2020-02-28'),
	(237,'2020-02-29'),
	(238,'2020-03-01'),
	(239,'2020-03-02'),
	(240,'2020-03-03'),
	(241,'2020-03-04'),
	(242,'2020-03-05'),
	(243,'2020-03-06'),
	(244,'2020-03-07'),
	(245,'2020-03-08'),
	(246,'2020-03-09'),
	(247,'2020-03-10'),
	(248,'2020-03-11'),
	(249,'2020-03-12'),
	(250,'2020-03-13'),
	(251,'2020-03-14'),
	(252,'2020-03-15'),
	(253,'2020-03-16'),
	(254,'2020-03-17'),
	(255,'2020-03-18'),
	(256,'2020-03-19'),
	(257,'2020-03-20'),
	(258,'2020-03-21'),
	(259,'2020-03-22'),
	(260,'2020-03-23'),
	(261,'2020-03-24'),
	(262,'2020-03-25'),
	(263,'2020-03-26'),
	(264,'2020-03-27'),
	(265,'2020-03-28'),
	(266,'2020-03-29'),
	(267,'2020-03-30'),
	(268,'2020-03-31'),
	(269,'2020-04-01'),
	(270,'2020-04-02'),
	(271,'2020-04-03'),
	(272,'2020-04-04'),
	(273,'2020-04-05'),
	(274,'2020-04-06'),
	(275,'2020-04-07'),
	(276,'2020-04-08'),
	(277,'2020-04-09'),
	(278,'2020-04-10'),
	(279,'2020-04-11'),
	(280,'2020-04-12'),
	(281,'2020-04-13'),
	(282,'2020-04-14'),
	(283,'2020-04-15'),
	(284,'2020-04-16'),
	(285,'2020-04-17'),
	(286,'2020-04-18'),
	(287,'2020-04-19'),
	(288,'2020-04-20'),
	(289,'2020-04-21'),
	(290,'2020-04-22'),
	(291,'2020-04-23'),
	(292,'2020-04-24'),
	(293,'2020-04-25'),
	(294,'2020-04-26'),
	(295,'2020-04-27'),
	(296,'2020-04-28'),
	(297,'2020-04-29'),
	(298,'2020-04-30'),
	(299,'2020-05-01'),
	(300,'2020-05-02'),
	(301,'2020-05-03'),
	(302,'2020-05-04'),
	(303,'2020-05-05'),
	(304,'2020-05-06'),
	(305,'2020-05-07'),
	(306,'2020-05-08'),
	(307,'2020-05-09'),
	(308,'2020-05-10'),
	(309,'2020-05-11'),
	(310,'2020-05-12'),
	(311,'2020-05-13'),
	(312,'2020-05-14'),
	(313,'2020-05-15'),
	(314,'2020-05-16'),
	(315,'2020-05-17'),
	(316,'2020-05-18'),
	(317,'2020-05-19'),
	(318,'2020-05-20'),
	(319,'2020-05-21'),
	(320,'2020-05-22'),
	(321,'2020-05-23'),
	(322,'2020-05-24'),
	(323,'2020-05-25'),
	(324,'2020-05-26'),
	(325,'2020-05-27'),
	(326,'2020-05-28'),
	(327,'2020-05-29'),
	(328,'2020-05-30'),
	(329,'2020-05-31'),
	(330,'2020-06-01'),
	(331,'2020-06-02'),
	(332,'2020-06-03'),
	(333,'2020-06-04'),
	(334,'2020-06-05'),
	(335,'2020-06-06'),
	(336,'2020-06-07'),
	(337,'2020-06-08'),
	(338,'2020-06-09'),
	(339,'2020-06-10'),
	(340,'2020-06-11'),
	(341,'2020-06-12'),
	(342,'2020-06-13'),
	(343,'2020-06-14'),
	(344,'2020-06-15'),
	(345,'2020-06-16'),
	(346,'2020-06-17'),
	(347,'2020-06-18'),
	(348,'2020-06-19'),
	(349,'2020-06-20'),
	(350,'2020-06-21'),
	(351,'2020-06-22'),
	(352,'2020-06-23'),
	(353,'2020-06-24'),
	(354,'2020-06-25'),
	(355,'2020-06-26'),
	(356,'2020-06-27'),
	(357,'2020-06-28'),
	(358,'2020-06-29'),
	(359,'2020-06-30'),
	(360,'2020-07-01'),
	(361,'2020-07-02'),
	(362,'2020-07-03'),
	(363,'2020-07-04'),
	(364,'2020-07-05'),
	(365,'2020-07-06'),
	(366,'2020-07-07'),
	(367,'2020-07-08'),
	(368,'2020-07-09'),
	(369,'2020-07-10'),
	(370,'2020-07-11'),
	(371,'2020-07-12'),
	(372,'2020-07-13'),
	(373,'2020-07-14'),
	(374,'2020-07-15'),
	(375,'2020-07-16'),
	(376,'2020-07-17'),
	(377,'2020-07-18'),
	(378,'2020-07-19'),
	(379,'2020-07-20'),
	(380,'2020-07-21'),
	(381,'2020-07-22'),
	(382,'2020-07-23'),
	(383,'2020-07-24'),
	(384,'2020-07-25'),
	(385,'2020-07-26'),
	(386,'2020-07-27'),
	(387,'2020-07-28'),
	(388,'2020-07-29'),
	(389,'2020-07-30'),
	(390,'2020-07-31'),
	(391,'2020-08-01'),
	(392,'2020-08-02'),
	(393,'2020-08-03'),
	(394,'2020-08-04');

/*!40000 ALTER TABLE `Date` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Distance
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Distance`;

CREATE TABLE `Distance` (
  `distanceId` int(11) NOT NULL,
  `distance_in_miles` double NOT NULL,
  PRIMARY KEY (`distanceId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Distance` WRITE;
/*!40000 ALTER TABLE `Distance` DISABLE KEYS */;

INSERT INTO `Distance` (`distanceId`, `distance_in_miles`)
VALUES
	(0,0),
	(1,0.25),
	(2,0.5),
	(3,0.75),
	(4,1),
	(5,1.25),
	(6,1.5),
	(7,1.75),
	(8,2),
	(9,2.25),
	(10,2.5),
	(11,2.75),
	(12,3),
	(13,3.25),
	(14,3.5),
	(15,3.75),
	(16,4),
	(17,4.25),
	(18,4.5),
	(19,4.75),
	(20,5),
	(21,5.25),
	(22,5.5),
	(23,5.75),
	(24,6),
	(25,6.25),
	(26,6.5),
	(27,6.75),
	(28,7),
	(29,7.25),
	(30,7.5),
	(31,7.75),
	(32,8),
	(33,8.25),
	(34,8.5),
	(35,8.75),
	(36,9),
	(37,9.25),
	(38,9.5),
	(39,9.75),
	(40,10),
	(41,10.25),
	(42,10.5),
	(43,10.75),
	(44,11),
	(45,11.25),
	(46,11.5),
	(47,11.75),
	(48,12),
	(49,12.25),
	(50,12.5),
	(51,12.75),
	(52,13),
	(53,13.25),
	(54,13.5),
	(55,13.75),
	(56,14),
	(57,14.25),
	(58,14.5),
	(59,14.75),
	(60,15),
	(61,15.25),
	(62,15.5),
	(63,15.75),
	(64,16),
	(65,16.25),
	(66,16.5),
	(67,16.75),
	(68,17),
	(69,17.25),
	(70,17.5),
	(71,17.75),
	(72,18),
	(73,18.25),
	(74,18.5),
	(75,18.75),
	(76,19),
	(77,19.25),
	(78,19.5),
	(79,19.75),
	(80,20),
	(81,20.25),
	(82,20.5),
	(83,20.75),
	(84,21),
	(85,21.25),
	(86,21.5),
	(87,21.75),
	(88,22),
	(89,22.25),
	(90,22.5),
	(91,22.75),
	(92,23),
	(93,23.25),
	(94,23.5),
	(95,23.75),
	(96,24),
	(97,24.25),
	(98,24.5),
	(99,24.75),
	(100,25),
	(101,25.25),
	(102,25.5),
	(103,25.75),
	(104,26),
	(105,26.25),
	(106,26.5),
	(107,26.75),
	(108,27),
	(109,27.25),
	(110,27.5),
	(111,27.75),
	(112,28),
	(113,28.25),
	(114,28.5),
	(115,28.75),
	(116,29),
	(117,29.25),
	(118,29.5),
	(119,29.75),
	(120,30),
	(121,30.25),
	(122,30.5),
	(123,30.75),
	(124,31),
	(125,31.25),
	(126,31.5),
	(127,31.75),
	(128,32),
	(129,32.25),
	(130,32.5),
	(131,32.75),
	(132,33),
	(133,33.25),
	(134,33.5),
	(135,33.75),
	(136,34),
	(137,34.25),
	(138,34.5),
	(139,34.75),
	(140,35),
	(141,35.25),
	(142,35.5),
	(143,35.75),
	(144,36),
	(145,36.25),
	(146,36.5),
	(147,36.75),
	(148,37),
	(149,37.25),
	(150,37.5),
	(151,37.75),
	(152,38),
	(153,38.25),
	(154,38.5),
	(155,38.75),
	(156,39),
	(157,39.25),
	(158,39.5),
	(159,39.75),
	(160,40),
	(161,40.25),
	(162,40.5),
	(163,40.75),
	(164,41),
	(165,41.25),
	(166,41.5),
	(167,41.75),
	(168,42),
	(169,42.25),
	(170,42.5),
	(171,42.75),
	(172,43),
	(173,43.25),
	(174,43.5),
	(175,43.75),
	(176,44),
	(177,44.25),
	(178,44.5),
	(179,44.75),
	(180,45),
	(181,45.25),
	(182,45.5),
	(183,45.75),
	(184,46),
	(185,46.25),
	(186,46.5),
	(187,46.75),
	(188,47),
	(189,47.25),
	(190,47.5),
	(191,47.75),
	(192,48),
	(193,48.25),
	(194,48.5),
	(195,48.75),
	(196,49),
	(197,49.25),
	(198,49.5),
	(199,49.75),
	(200,50),
	(201,50.25),
	(202,50.5),
	(203,50.75),
	(204,51),
	(205,51.25),
	(206,51.5),
	(207,51.75),
	(208,52),
	(209,52.25),
	(210,52.5),
	(211,52.75),
	(212,53),
	(213,53.25),
	(214,53.5),
	(215,53.75),
	(216,54),
	(217,54.25),
	(218,54.5),
	(219,54.75),
	(220,55),
	(221,55.25),
	(222,55.5),
	(223,55.75),
	(224,56),
	(225,56.25),
	(226,56.5),
	(227,56.75),
	(228,57),
	(229,57.25),
	(230,57.5),
	(231,57.75),
	(232,58),
	(233,58.25),
	(234,58.5),
	(235,58.75),
	(236,59),
	(237,59.25),
	(238,59.5),
	(239,59.75),
	(240,60),
	(241,60.25),
	(242,60.5),
	(243,60.75),
	(244,61),
	(245,61.25),
	(246,61.5),
	(247,61.75),
	(248,62),
	(249,62.25),
	(250,62.5),
	(251,62.75),
	(252,63),
	(253,63.25),
	(254,63.5),
	(255,63.75),
	(256,64),
	(257,64.25),
	(258,64.5),
	(259,64.75),
	(260,65),
	(261,65.25),
	(262,65.5),
	(263,65.75),
	(264,66),
	(265,66.25),
	(266,66.5),
	(267,66.75),
	(268,67),
	(269,67.25),
	(270,67.5),
	(271,67.75),
	(272,68),
	(273,68.25),
	(274,68.5),
	(275,68.75),
	(276,69),
	(277,69.25),
	(278,69.5),
	(279,69.75),
	(280,70),
	(281,70.25),
	(282,70.5),
	(283,70.75),
	(284,71),
	(285,71.25),
	(286,71.5),
	(287,71.75),
	(288,72),
	(289,72.25),
	(290,72.5),
	(291,72.75),
	(292,73),
	(293,73.25),
	(294,73.5),
	(295,73.75),
	(296,74),
	(297,74.25),
	(298,74.5),
	(299,74.75),
	(300,75),
	(301,75.25),
	(302,75.5),
	(303,75.75),
	(304,76),
	(305,76.25),
	(306,76.5),
	(307,76.75),
	(308,77),
	(309,77.25),
	(310,77.5),
	(311,77.75),
	(312,78),
	(313,78.25),
	(314,78.5),
	(315,78.75),
	(316,79),
	(317,79.25),
	(318,79.5),
	(319,79.75),
	(320,80),
	(321,80.25),
	(322,80.5),
	(323,80.75),
	(324,81),
	(325,81.25),
	(326,81.5),
	(327,81.75),
	(328,82),
	(329,82.25),
	(330,82.5),
	(331,82.75),
	(332,83),
	(333,83.25),
	(334,83.5),
	(335,83.75),
	(336,84),
	(337,84.25),
	(338,84.5),
	(339,84.75),
	(340,85),
	(341,85.25),
	(342,85.5),
	(343,85.75),
	(344,86),
	(345,86.25),
	(346,86.5),
	(347,86.75),
	(348,87),
	(349,87.25),
	(350,87.5),
	(351,87.75),
	(352,88),
	(353,88.25),
	(354,88.5),
	(355,88.75),
	(356,89),
	(357,89.25),
	(358,89.5),
	(359,89.75),
	(360,90),
	(361,90.25),
	(362,90.5),
	(363,90.75),
	(364,91),
	(365,91.25),
	(366,91.5),
	(367,91.75),
	(368,92),
	(369,92.25),
	(370,92.5),
	(371,92.75),
	(372,93),
	(373,93.25),
	(374,93.5),
	(375,93.75),
	(376,94),
	(377,94.25),
	(378,94.5),
	(379,94.75),
	(380,95),
	(381,95.25),
	(382,95.5),
	(383,95.75),
	(384,96),
	(385,96.25),
	(386,96.5),
	(387,96.75),
	(388,97),
	(389,97.25),
	(390,97.5),
	(391,97.75),
	(392,98),
	(393,98.25),
	(394,98.5),
	(395,98.75),
	(396,99),
	(397,99.25),
	(398,99.5),
	(399,99.75),
	(400,100),
	(401,100.25),
	(402,100.5),
	(403,100.75),
	(404,101),
	(405,101.25),
	(406,101.5),
	(407,101.75),
	(408,102),
	(409,102.25),
	(410,102.5),
	(411,102.75),
	(412,103),
	(413,103.25),
	(414,103.5),
	(415,103.75),
	(416,104),
	(417,104.25),
	(418,104.5),
	(419,104.75),
	(420,105),
	(421,105.25),
	(422,105.5),
	(423,105.75),
	(424,106),
	(425,106.25),
	(426,106.5),
	(427,106.75),
	(428,107),
	(429,107.25),
	(430,107.5),
	(431,107.75),
	(432,108),
	(433,108.25),
	(434,108.5),
	(435,108.75),
	(436,109),
	(437,109.25),
	(438,109.5),
	(439,109.75),
	(440,110),
	(441,110.25),
	(442,110.5),
	(443,110.75),
	(444,111),
	(445,111.25),
	(446,111.5),
	(447,111.75),
	(448,112);

/*!40000 ALTER TABLE `Distance` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table time
# ------------------------------------------------------------

DROP TABLE IF EXISTS `time`;

CREATE TABLE `time` (
  `timeId` int(11) NOT NULL,
  `time_in_hours` double NOT NULL,
  PRIMARY KEY (`timeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `time` WRITE;
/*!40000 ALTER TABLE `time` DISABLE KEYS */;

INSERT INTO `time` (`timeId`, `time_in_hours`)
VALUES
	(1,0.25),
	(2,0.5),
	(3,0.75),
	(4,1),
	(5,1.25),
	(6,1.5),
	(7,1.75),
	(8,2),
	(9,2.25),
	(10,2.5),
	(11,2.75),
	(12,3),
	(13,3.25),
	(14,3.5),
	(15,3.75),
	(16,4),
	(17,4.25),
	(18,4.5),
	(19,4.75),
	(20,5),
	(21,5.25),
	(22,5.5),
	(23,5.75),
	(24,6),
	(25,6.25),
	(26,6.5),
	(27,6.75),
	(28,7),
	(29,7.25),
	(30,7.5),
	(31,7.75),
	(32,8),
	(33,8.25),
	(34,8.5),
	(35,8.75),
	(36,9),
	(37,9.25),
	(38,9.5),
	(39,9.75),
	(40,10),
	(41,10.25),
	(42,10.5),
	(43,10.75),
	(44,11),
	(45,11.25),
	(46,11.5),
	(47,11.75),
	(48,12),
	(49,12.25),
	(50,12.5),
	(51,12.75),
	(52,13),
	(53,13.25),
	(54,13.5),
	(55,13.75),
	(56,14),
	(57,14.25),
	(58,14.5),
	(59,14.75),
	(60,15),
	(61,15.25),
	(62,15.5),
	(63,15.75),
	(64,16),
	(65,16.25),
	(66,16.5),
	(67,16.75),
	(68,17),
	(69,17.25),
	(70,17.5),
	(71,17.75),
	(72,18),
	(73,18.25),
	(74,18.5),
	(75,18.75),
	(76,19),
	(77,19.25),
	(78,19.5),
	(79,19.75),
	(80,20),
	(81,20.25),
	(82,20.5),
	(83,20.75),
	(84,21),
	(85,21.25),
	(86,21.5),
	(87,21.75),
	(88,22),
	(89,22.25),
	(90,22.5),
	(91,22.75),
	(92,23),
	(93,23.25),
	(94,23.5),
	(95,23.75),
	(96,24);

/*!40000 ALTER TABLE `time` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Tracker
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Tracker`;

CREATE TABLE `Tracker` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) NOT NULL,
  `dateid` int(11) DEFAULT NULL,
  `activityid` int(11) DEFAULT NULL,
  `timeid` int(11) DEFAULT NULL,
  `distanceid` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `activity` (`activityid`),
  KEY `date` (`dateid`),
  KEY `distance` (`distanceid`),
  KEY `time` (`timeid`),
  KEY `userid_idx` (`userId`),
  CONSTRAINT `activity` FOREIGN KEY (`activityid`) REFERENCES `activity` (`activityId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `date` FOREIGN KEY (`dateid`) REFERENCES `Date` (`dateID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `distance` FOREIGN KEY (`distanceid`) REFERENCES `Distance` (`distanceId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `time` FOREIGN KEY (`timeid`) REFERENCES `time` (`timeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Tracker` WRITE;
/*!40000 ALTER TABLE `Tracker` DISABLE KEYS */;

INSERT INTO `Tracker` (`Id`, `userId`, `dateid`, `activityid`, `timeid`, `distanceid`)
VALUES
	(1,1,1,1,1,1),
	(3,202,3,54,1,0),
	(4,1,2,23,23,32),
	(5,12,12,12,12,12);

/*!40000 ALTER TABLE `Tracker` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table users
# ------------------------------------------------------------

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `Age` int(11) NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;

INSERT INTO `users` (`userId`, `firstName`, `lastName`, `Age`)
VALUES
	(1,'Carlos','Belardo',28),
	(2,'Milo','Minyard',26),
	(3,'Jasper','Holmgren',40),
	(4,'Asher','Coopersmith',42),
	(5,'Atticus','Dabato',22),
	(6,'Silas','Jipson',30),
	(7,'Theodore','Strife',40),
	(8,'Jack','Gotshall',19),
	(9,'Finn','Boeckx',16),
	(10,'Aarav','Pestone',33),
	(11,'Felix','Greeno',24),
	(12,'Henry','Hebden',24),
	(13,'Wyatt','Boshnack',24),
	(14,'Aryan','Gallishaw',41),
	(15,'Oscar','Lefebvre',36),
	(16,'Oliver','Laney',37),
	(17,'Leo','Mesenbrink',20),
	(18,'Julian','Fausto',27),
	(19,'Levi','Plitt',46),
	(20,'Ethan','Perrine',16),
	(21,'Bodhi','Whitham',47),
	(22,'Arthur','Fehrle',28),
	(23,'Louis','Balitas',27),
	(24,'James','Marchal',46),
	(25,'Ezra','Tirona',18),
	(26,'Soren','Lazenson',49),
	(27,'Charles','Duplessy',44),
	(28,'Charlie','Metos',27),
	(29,'Jude','Studebaker',35),
	(30,'Liam','Crisler',37),
	(31,'Theo','Dabe',36),
	(32,'Aaron','Conwell',34),
	(33,'Axel','Vanevery',46),
	(34,'Eli','Beeson',37),
	(35,'Emmett','Sica',36),
	(36,'Harry','Degroote',23),
	(37,'Cassius','Berulie',25),
	(38,'Kai','Rakers',24),
	(39,'Thomas','Cianfrani',28),
	(40,'Caleb','Rannels',47),
	(41,'Sebastian','Miron',42),
	(42,'Declan','Cruiz',46),
	(43,'Atlas','Mullens',37),
	(44,'Jayden','Search',45),
	(45,'William','Oslund',31),
	(46,'Benjamin','Varillas',46),
	(47,'Miles','Hainsey',17),
	(48,'Arlo','Debolt',37),
	(49,'Lucas','Harriet',43),
	(50,'Elio','Rumphol',28),
	(51,'Elijah','Class',41),
	(52,'Isla','Mckernin',48),
	(53,'Olivia','Gallarello',25),
	(54,'Posie','Enderson',16),
	(55,'Aurora','Schikora',16),
	(56,'Cora','Riordan',38),
	(57,'Ada','Vitaniemi',32),
	(58,'Maeve','Leviton',18),
	(59,'Amara','Reck',24),
	(60,'Charlotte','Duck',37),
	(61,'Amelia','Brandenberg',23),
	(62,'Ophelia','Schoppert',38),
	(63,'Ava','Olofson',44),
	(64,'Rose','Schoening',24),
	(65,'Genevieve','Orms',30),
	(66,'Luna','Nehmer',19),
	(67,'Elenor','Maestos',17),
	(68,'Elodie','Criton',16),
	(69,'Lucy','Desfosses',22),
	(70,'Frey','Epperley',48),
	(71,'Anna','Jones',45),
	(72,'Astrid','Farrior',49),
	(73,'Evelyn','Gissel',19),
	(74,'Eloise','Dunston',20),
	(75,'Violet','Simuel',30),
	(76,'Alice','Neuburger',42),
	(77,'Adelaide','Blanda',22),
	(78,'Iris','Franpton',44),
	(79,'Adah','Detterich',16),
	(80,'Thea','Kruger',28),
	(81,'Ivy','Tutor',26),
	(82,'Jane','Zagrodnik',18),
	(83,'Nora','Vancott',46),
	(84,'Adeline','Lucker',18),
	(85,'Aurelia','Benejan',28),
	(86,'Elizabeth','Digges',27),
	(87,'Hazel','Goodier',17),
	(88,'Maisie','Tranum',32),
	(89,'Elsie','Shamsiddeen',32),
	(90,'Esme','Shivley',20),
	(91,'Chloe','Goosen',26),
	(92,'Imogen','Barabin',35),
	(93,'Eliza','Mcburnie',47),
	(94,'Penelope','Culley',27),
	(95,'Mia','Sobenes',18),
	(96,'Julia','Elmendorf',46),
	(97,'Maya','Wurth',40),
	(98,'Clara','Durie',32),
	(99,'Emilia','Seymer',36),
	(100,'Phoebe','Hershaw',48),
	(101,'Isabella','Every',26),
	(102,'Colt','Kadar',27),
	(103,'Abel','Boyko',22),
	(104,'Conner','Viscarra',34),
	(105,'Rose','Wiatrak',34),
	(106,'Camryn','Trank',46),
	(107,'Axel','Ericsson',20),
	(108,'Josephine','Yori',39),
	(109,'Conner','Metge',41),
	(110,'Addyson','Fulsom',35),
	(111,'Delilah','Freil',20),
	(112,'Thomas','Imbriale',29),
	(113,'Leilani','Onnen',17),
	(114,'Danielle','Jahns',16),
	(115,'Felix','Magoon',20),
	(116,'Luna','Holding',48),
	(117,'Devin','Marcum',38),
	(118,'Genesis','Miyasaki',24),
	(119,'Izaiah','Kapa',36),
	(120,'Dustin','Broadie',28),
	(121,'Katherine','Bulkeley',49),
	(122,'Justin','Dousay',26),
	(123,'Harmony','Hite',35),
	(124,'Guadalupe','Mazor',23),
	(125,'Emiliano','Pavelich',45),
	(126,'Harmony','Saia',32),
	(127,'Brooklyn','Provow',36),
	(128,'Layla','Pletz',17),
	(129,'Edgar','Ork',31),
	(130,'Serenity','Friedmann',17),
	(131,'Vivian','Hurney',48),
	(132,'Malia','Ginsberg',42),
	(133,'Maximus','Canellas',36),
	(134,'Faith','Hardridge',38),
	(135,'Paige','Abdi',16),
	(136,'Johnny','Pipe',26),
	(137,'Caden','Coonrad',21),
	(138,'Richard','Ancira',26),
	(139,'Julie','Ingles',38),
	(140,'Corbin','Yang',23),
	(141,'Wyatt','Wickemeyer',38),
	(142,'Rachel','Cosma',17),
	(143,'Leo','Sales',46),
	(144,'Luke','Defee',46),
	(145,'Janiya','Headman',32),
	(146,'Izaiah','Leonetti',27),
	(147,'Caitlin','Escalona',27),
	(148,'Sean','Crimin',37),
	(149,'Carly','Aharoni',20),
	(150,'Aubree','Tischler',44),
	(151,'Drew','Guida',41),
	(152,'Skyler','Hefler',46),
	(153,'Alina','Burgh',26),
	(154,'Emely','Irie',39),
	(155,'Paisley','Cordiero',27),
	(156,'Elise','Duntley',48),
	(157,'Adrianna','Heintzman',36),
	(158,'Gabriela','Mcmarlin',47),
	(159,'Dillon','Amolsch',31),
	(160,'Julie','Hafford',19),
	(161,'Carter','Rucks',32),
	(162,'Ian','Rolfsen',33),
	(163,'Landon','Prusak',43),
	(164,'Jasmine','Pullin',47),
	(165,'Kaiden','Strenke',45),
	(166,'Hadley','Stratakos',35),
	(167,'Travis','Milkovich',32),
	(168,'Santiago','Foerschler',47),
	(169,'Colin','Katzen',44),
	(170,'Grayson','Younglas',42),
	(171,'Dane','Bunger',28),
	(172,'Oliver','Cortinas',36),
	(173,'Lexi','Hulshoff',31),
	(174,'Sean','Dwane',48),
	(175,'Devin','Behnken',45),
	(176,'Erin','Ureno',45),
	(177,'Layla','Pennell',34),
	(178,'Tony','Poxon',35),
	(179,'Emanuel','Krock',29),
	(180,'Giselle','Stigers',17),
	(181,'Amaya','Glascock',32),
	(182,'Madelynn','Spiliakos',41),
	(183,'Madilyn','Meroney',17),
	(184,'Rocco','Heebsh',34),
	(185,'Keegan','Sparano',22),
	(186,'Brooke','Vierthaler',43),
	(187,'Nyla','Kasen',21),
	(188,'Braxton','Fecat',44),
	(189,'Angelica','Borroto',40),
	(190,'Gianna','Rabbitt',39),
	(191,'Gavin','Askiew',24),
	(192,'Alayna','Stukel',49),
	(193,'Kimberly','Gentzler',44),
	(194,'Ashley','Cools',34),
	(195,'Breanna','Kinzle',33),
	(196,'Carolina','Hejny',42),
	(197,'Brett','Janikowski',42),
	(198,'Layla','Weidig',32),
	(199,'Arturo','Rioz',25),
	(200,'Analia','Boera',28),
	(201,'Ismael','Goeman',38),
	(202,'Michael','Harrison',50),
	(203,'Ub','Iwerks',120);

/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
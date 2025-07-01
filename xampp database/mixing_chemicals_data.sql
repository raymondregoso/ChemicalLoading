-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 29, 2016 at 02:26 PM
-- Server version: 5.1.41
-- PHP Version: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `send_report_output`
--

-- --------------------------------------------------------

--
-- Table structure for table `mixing_chemicals_data`
--

CREATE TABLE IF NOT EXISTS `mixing_chemicals_data` (
  `ITEM_CODE` varchar(333) NOT NULL,
  `WEIGHT_PALLET` float NOT NULL,
  `WEIGHT_BAG` float NOT NULL,
  `BAGS_PALLET` float NOT NULL,
  `REQUIREMENT` float NOT NULL,
  `MAX_LOAD_BAG` float NOT NULL,
  `EQUIV_HRS` float NOT NULL,
  `SYS_DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `EMP_NO` varchar(333) NOT NULL,
  `UPDATED_DATE` date NOT NULL,
  `UOM` varchar(333) NOT NULL,
  `PLANT` varchar(333) NOT NULL,
  `MAX_SCAN` float NOT NULL,
  `MCD_ID` varchar(100) NOT NULL,
  `ADDED_BY` varchar(10) NOT NULL,
  PRIMARY KEY (`MCD_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `mixing_chemicals_data`
--

INSERT INTO `mixing_chemicals_data` (`ITEM_CODE`, `WEIGHT_PALLET`, `WEIGHT_BAG`, `BAGS_PALLET`, `REQUIREMENT`, `MAX_LOAD_BAG`, `EQUIV_HRS`, `SYS_DATE`, `EMP_NO`, `UPDATED_DATE`, `UOM`, `PLANT`, `MAX_SCAN`, `MCD_ID`, `ADDED_BY`) VALUES
('F3332', 1000, 25, 40, 288.49, 3, 16.64, '2016-02-06 18:24:05', '', '0000-00-00', 'Kgs', 'West', 2, 'MCD_nIAfn20160206182353', 'YPH-0065'),
('F4055', 900, 20, 45, 1700, 29, 8.01, '2016-02-06 19:45:45', '', '0000-00-00', 'Kgs', 'West', 10, 'MCD_x20Jq20160206194533', 'YPH-0065'),
('F3370', 400, 20, 20, 25.18, 2, 38.13, '2016-02-06 19:47:34', '', '0000-00-00', 'Kgs', 'West', 10, 'MCD_17qX320160206194722', 'YPH-0065'),
('F4062', 700, 25, 28, 903.6, 25, 16.6, '2016-02-06 19:48:30', '', '0000-00-00', 'Kgs', 'West', 25, 'MCD_XEGaX20160206194818', 'YPH-0065');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 29, 2016 at 02:27 PM
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
-- Table structure for table `tscby0001t`
--

CREATE TABLE IF NOT EXISTS `tscby0001t` (
  `EMP_NUMBER` varchar(333) NOT NULL,
  `LAST_NAME` varchar(333) NOT NULL,
  `FIRST_NAME` varchar(333) NOT NULL,
  `MID_NAME` varchar(333) NOT NULL,
  `DATE_HIRED` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ORG_UNIT_CODE` varchar(333) NOT NULL,
  `ORG_SECTION_CODE` varchar(333) NOT NULL,
  `process_id` varchar(333) NOT NULL,
  `Emp_status` varchar(333) NOT NULL,
  `EMP_RANK` varchar(333) NOT NULL,
  `Emp_Password` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`EMP_NUMBER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tscby0001t`
--

INSERT INTO `tscby0001t` (`EMP_NUMBER`, `LAST_NAME`, `FIRST_NAME`, `MID_NAME`, `DATE_HIRED`, `ORG_UNIT_CODE`, `ORG_SECTION_CODE`, `process_id`, `Emp_status`, `EMP_RANK`, `Emp_Password`) VALUES
('YPH-0065', 'Tolentino', 'Albert John', 'Gonzales', '2015-12-17 09:37:40', 'M1', 'MS', 'M1010', 'A', 'NV', '123'),
('YPH-3627', 'Yutuc', 'Jayrone', 'Bati', '2015-12-17 09:37:51', 'M1', 'MS', 'M1010', 'A', 'TM', '123');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

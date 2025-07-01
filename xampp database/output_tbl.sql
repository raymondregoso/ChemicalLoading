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
-- Table structure for table `output_tbl`
--

CREATE TABLE IF NOT EXISTS `output_tbl` (
  `MACHINE_NAME` varchar(333) NOT NULL,
  `IDNUM` varchar(333) NOT NULL,
  `FULLNAME` varchar(333) NOT NULL,
  `STARTSCAN` varchar(333) NOT NULL,
  `STOPSCAN` varchar(333) NOT NULL,
  `STARTDATESCAN` varchar(333) NOT NULL,
  `MATERIAL_NO` varchar(333) NOT NULL,
  `LOADBAGS` varchar(333) NOT NULL,
  `LOADPERKG` varchar(333) NOT NULL,
  `ACCOUNTABILITY` varchar(333) NOT NULL,
  `TAG_NO` varchar(333) NOT NULL,
  `WEIGHT` varchar(333) NOT NULL,
  `EXPIRED_DATE` varchar(333) NOT NULL,
  `SYS_DATE_TIME` varchar(100) NOT NULL,
  `REM_WT_PALLET` varchar(333) NOT NULL,
  `REM_BAG_PALLET` varchar(333) NOT NULL,
  `TOT_ACT_WT` varchar(333) NOT NULL,
  `TOTALBAGPERPALLET` varchar(333) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `output_tbl`
--

INSERT INTO `output_tbl` (`MACHINE_NAME`, `IDNUM`, `FULLNAME`, `STARTSCAN`, `STOPSCAN`, `STARTDATESCAN`, `MATERIAL_NO`, `LOADBAGS`, `LOADPERKG`, `ACCOUNTABILITY`, `TAG_NO`, `WEIGHT`, `EXPIRED_DATE`, `SYS_DATE_TIME`, `REM_WT_PALLET`, `REM_BAG_PALLET`, `TOT_ACT_WT`, `TOTALBAGPERPALLET`) VALUES
('WCL6', 'YPH-0065', 'Albert John', '7:02:44 PM', '7:02:55 PM', '02-06-2016', 'F3332', '2', '25', '', 'CUFCS1MR', '1000', '20160602', '2/6/2016 7:02:50 PM', '950', '38', '50', '40'),
('WCL6', 'YPH-3621', 'Ramon', '7:03:38 PM', '7:03:46 PM', '02-06-2016', 'F3332', '1', '25', '', 'CUFCS1MR', '1000', '20160602', '2/6/2016 7:03:42 PM', '925', '37', '25', '40'),
('WCL6', 'YPH-3621', 'Ramon', '7:08:43 PM', '3:43:46 PM', '02-06-2016', 'F3332', '3', '25', 'Albert John', 'CUFCS1MR', '1000', '20160602', '2/6/2016 7:08:43 PM', '850', '34', '75', '40'),
('WCL6', 'YPH-3621', 'Ramon', '7:50:07 PM', '4:07:17 PM', '02-06-2016', 'F4062', '6', '25', '', 'CUFCS3JE', '0700', '20161210', '2/6/2016 7:50:07 PM', '550', '22', '150', '28'),
('WCL6', 'YPH-3621', 'Ramon', '7:50:30 PM', '4:06:58 PM', '02-06-2016', 'F4055', '5', '20', '', 'CUFCS1PA', '0900', '20160604', '2/6/2016 7:50:30 PM', '800', '40', '100', '45'),
('WCL6', 'YPH-3621', 'Ramon', '7:57:44 PM', '7:57:50 PM', '02-06-2016', 'F3370', '2', '20', '', 'CUFBS5CK', '0400', '20161124', '2/6/2016 7:57:45 PM', '360', '18', '40', '20'),
('WCL6', 'YPH-3621', 'Ramon', '8:48:34 PM', '8:48:40 PM', '02-06-2016', 'F3370', '2', '20', '', 'CUFBS5CK', '0400', '20161124', '2/6/2016 8:48:34 PM', '320', '16', '40', '20'),
('WCL6', 'YPH-0065', 'Albert John', '3:43:37 PM', '', '02-23-2016', 'F3332', '2', '25', 'Albert John', 'CUFCS1MR', '1000', '20160602', '2/23/2016 3:43:37 PM', '800', '32', '50', '40'),
('WCL6', 'YPH-3621', 'Ramon', '3:44:59 PM', '', '02-23-2016', 'F4055', '3', '20', '', 'CUFCS1PA', '0900', '20160604', '2/23/2016 3:44:59 PM', '740', '37', '60', '45'),
('WCL6', 'YPH-3621', 'Ramon', '3:47:12 PM', '', '02-23-2016', 'F4062', '2', '25', '', 'CUFCS3JE', '0700', '20161210', '2/23/2016 3:47:12 PM', '500', '20', '50', '28'),
('WCL6', 'YPH-3621', 'Ramon', '3:47:50 PM', '3:47:54 PM', '02-23-2016', 'F4055', '2', '20', '', 'CUFCS6AT', '0900', '20160616', '2/23/2016 3:47:50 PM', '860', '43', '40', '45'),
('WCL6', 'YPH-0065', 'Albert John', '4:06:47 PM', '', '02-23-2016', 'F4055', '2', '20', '', 'CUFCS1PA', '0900', '20160604', '2/23/2016 4:06:47 PM', '760', '38', '40', '45'),
('WCL6', 'YPH-3621', 'Ramon', '4:07:13 PM', '', '02-23-2016', 'F4062', '3', '25', '', 'CUFCS3JE', '0700', '20161210', '2/23/2016 4:07:13 PM', '475', '19', '75', '28');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

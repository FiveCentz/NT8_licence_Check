-- Basic table structure for this project
SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;

DROP TABLE IF EXISTS `fc_nt_indicators`;
CREATE TABLE `fc_nt_indicators` (
  `id_nt_ind` int(11) NOT NULL AUTO_INCREMENT,
  `MACHINE_ID` varchar(36) DEFAULT NULL COMMENT 'NT MACHINE_ID',
  `expires_on` timestamp NULL DEFAULT '2024-05-31 08:09:18',
  `LIFE_LONG` int(1) DEFAULT 0,
  `created` timestamp NULL DEFAULT current_timestamp(),
  `updated` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `UserName` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id_nt_ind`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

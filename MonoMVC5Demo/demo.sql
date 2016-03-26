/*
Navicat MariaDB Data Transfer

Source Server         : mariaDb
Source Server Version : 50544
Source Host           : gool.ss22219.cn:3306
Source Database       : demo

Target Server Type    : MariaDB
Target Server Version : 50544
File Encoding         : 65001

Date: 2016-03-24 17:33:22
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Create malshinon database
CREATE DATABASE IF NOT EXISTS malshinon_db
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE malshinon_db;

-- Create people table
CREATE TABLE people(
id INT PRIMARY KEY AUTO_INCREMENT,
firstName VARCHAR(100),
lastName VARCHAR(100),
secretCode VARCHAR(100) UNIQUE,
role ENUM('manager', 'reporter', 'target', 'both', 'potential_agent'),
reportsCount INT DEFAULT 0,
mantionsCount INT DEFAULT 0
);

-- Create intel reports table
CREATE TABLE intel_reports(
id INT PRIMARY KEY AUTO_INCREMENT,
reporterId INT,
targetId INT,
text TEXT,
timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY(reporterId) REFERENCES people(id),
FOREIGN KEY(targetId) REFERENCES people(id)
);
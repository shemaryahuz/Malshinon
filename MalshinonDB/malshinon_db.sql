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
type ENUM('reporter', 'target', 'both', 'potential_agent'),
reportsAmount INT DEFAULT 0,
mantionsAmount INT DEFAULT 0
);

-- Create intel reports table
CREATE TABLE intel_reports(
id INT PRIMARY KEY AUTO_INCREMENT,
reporterId INT,
FOREIGN KEY(reporterId) REFERENCES people(id),
targetId INT,
FOREIGN KEY(targetId) REFERENCES people(id),
text TEXT,
timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
);
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

-- Insert 30 people (1 manager, rest reporters and targets)
INSERT INTO people (firstName, lastName, secretCode, role, reportsCount, mantionsCount) VALUES
('David', 'Mitchell', 'ALPHA001', 'manager', 0, 0),
('Sarah', 'Johnson', 'REP001', 'reporter', 3, 0),
('Michael', 'Chen', 'REP002', 'reporter', 2, 1),
('Emma', 'Williams', 'REP003', 'reporter', 1, 0),
('James', 'Brown', 'REP004', 'reporter', 2, 2),
('Lisa', 'Davis', 'REP005', 'reporter', 1, 0),
('Robert', 'Miller', 'REP006', 'reporter', 3, 1),
('Maria', 'Garcia', 'REP007', 'reporter', 2, 0),
('John', 'Wilson', 'REP008', 'reporter', 1, 1),
('Anna', 'Moore', 'REP009', 'reporter', 2, 0),
('Thomas', 'Taylor', 'REP010', 'reporter', 1, 0),
('Jessica', 'Anderson', 'TGT001', 'target', 0, 2),
('Daniel', 'Jackson', 'TGT002', 'target', 0, 3),
('Rachel', 'White', 'TGT003', 'target', 0, 1),
('Kevin', 'Harris', 'TGT004', 'target', 0, 2),
('Amanda', 'Martin', 'TGT005', 'target', 0, 1),
('Christopher', 'Thompson', 'TGT006', 'target', 0, 2),
('Nicole', 'Garcia', 'TGT007', 'target', 0, 1),
('Matthew', 'Martinez', 'TGT008', 'target', 0, 1),
('Stephanie', 'Robinson', 'TGT009', 'target', 0, 2),
('Andrew', 'Clark', 'TGT010', 'target', 0, 1),
('Jennifer', 'Rodriguez', 'TGT011', 'target', 0, 1),
('Joshua', 'Lewis', 'TGT012', 'target', 0, 2),
('Ashley', 'Lee', 'TGT013', 'target', 0, 1),
('Ryan', 'Walker', 'TGT014', 'target', 0, 1),
('Megan', 'Hall', 'TGT015', 'target', 0, 2),
('Brandon', 'Allen', 'TGT016', 'target', 0, 1),
('Samantha', 'Young', 'TGT017', 'target', 0, 1),
('Tyler', 'Hernandez', 'TGT018', 'target', 0, 1),
('Lauren', 'King', 'TGT019', 'target', 0, 1);

-- Insert 30 intel reports
INSERT INTO intel_reports (reporterId, targetId, text) VALUES
(2, 12, 'Target observed meeting with unknown individuals at downtown café. Conversation appeared intense and lasted approximately 45 minutes.'),
(2, 13, 'Subject has been frequenting the library regularly, spending time in the computer section. Suspicious online activity suspected.'),
(2, 14, 'Target changed daily routine significantly. Now takes different route to work and varies departure times.'),
(3, 15, 'Observed target making multiple phone calls from public payphone. Calls lasted 3-5 minutes each.'),
(3, 16, 'Subject has new associate - tall man with distinctive scar on left cheek. Meeting locations vary but pattern emerging.'),
(4, 17, 'Target purchased large quantity of electronics from multiple stores. Items include burner phones and radio equipment.'),
(5, 18, 'Subject behavior increasingly erratic. Checking surroundings frequently and appears paranoid about being followed.'),
(5, 19, 'Target has been visiting storage facility on weekends. Always carries large duffel bag upon leaving.'),
(6, 20, 'Observed target in heated argument with landlord. Overheard mention of "package delivery" and "timeline changes".'),
(6, 21, 'Subject has established contact with foreign national. Meetings occur at various restaurants in ethnic district.'),
(6, 22, 'Target received mysterious package via courier service. Package appeared heavy and was handled with extreme care.'),
(7, 23, 'Subject has been conducting surveillance on government building. Uses different vantage points but pattern is clear.'),
(7, 24, 'Target made inquiries about boat rentals at marina. Specifically interested in vessels capable of night operations.'),
(8, 25, 'Observed target practicing lock picking in abandoned warehouse. Skills appear advanced, suggesting prior training.'),
(9, 26, 'Subject has been mapping security camera locations throughout financial district. Uses tablet to record positions.'),
(9, 27, 'Target established safe house in residential area. Location shows signs of recent fortification and surveillance equipment.'),
(10, 28, 'Subject behavior indicates awareness of surveillance. Employs counter-surveillance techniques during daily activities.'),
(11, 29, 'Target has been researching explosive compounds online. Browser history shows visits to chemistry and military sites.'),
(2, 30, 'Observed target meeting with previously identified associate. Exchange of documents occurred during brief encounter.'),
(3, 12, 'Subject has changed communication patterns. Now uses encrypted messaging apps and varies communication times.'),
(4, 13, 'Target purchased survival gear including camping equipment, water purification tablets, and emergency rations.'),
(5, 14, 'Subject has been conducting reconnaissance on transportation hubs. Focuses on security measures and escape routes.'),
(6, 15, 'Target established multiple bank accounts under different aliases. Financial activity suggests funding for operation.'),
(7, 16, 'Observed target practicing with firearms at remote location. Training appears professional and systematic.'),
(8, 17, 'Subject has been studying building blueprints obtained from city planning office. Focus on utility access points.'),
(9, 18, 'Target demonstrated knowledge of electronic surveillance equipment. Able to detect and disable monitoring devices.'),
(10, 19, 'Subject behavior suggests preparation for extended absence. Has been settling affairs and making arrangements.'),
(11, 20, 'Target has been recruiting additional personnel. Meetings occur in secure locations with operational security measures.'),
(2, 21, 'Observed target conducting dry runs of planned route. Timing and logistics appear carefully rehearsed.'),
(3, 22, 'Subject has established emergency protocols including safe words and contingency meeting points.');
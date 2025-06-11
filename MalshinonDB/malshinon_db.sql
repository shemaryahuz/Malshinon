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

-- Insert people (1 manager, reporters, targets, and 3 'both' roles)
INSERT INTO people (firstName, lastName, secretCode, role, reportsCount, mantionsCount) VALUES
-- Manager
('David', 'Mitchell', 'ALPHA001', 'manager', 0, 0),

-- Reporters (including 3 with 10+ reports each)
('Sarah', 'Johnson', 'REP001', 'reporter', 15, 0),  -- High-volume reporter 1
('Michael', 'Chen', 'REP002', 'reporter', 12, 0),   -- High-volume reporter 2
('Emma', 'Williams', 'REP003', 'reporter', 11, 0),  -- High-volume reporter 3
('James', 'Brown', 'REP004', 'reporter', 3, 0),
('Lisa', 'Davis', 'REP005', 'reporter', 2, 0),
('Robert', 'Miller', 'REP006', 'reporter', 4, 0),
('Maria', 'Garcia', 'REP007', 'reporter', 3, 0),
('John', 'Wilson', 'REP008', 'reporter', 2, 0),
('Anna', 'Moore', 'REP009', 'reporter', 3, 0),
('Thomas', 'Taylor', 'REP010', 'reporter', 2, 0),

-- People with 'both' role (they report AND are targets)
('Alexander', 'Stone', 'BOTH001', 'both', 5, 8),    -- Both role 1
('Victoria', 'Cross', 'BOTH002', 'both', 4, 6),     -- Both role 2
('Marcus', 'Reed', 'BOTH003', 'both', 3, 7),        -- Both role 3

-- Targets (including 3 with 20+ mentions each)
('Jessica', 'Anderson', 'TGT001', 'target', 0, 23), -- High-priority target 1
('Daniel', 'Jackson', 'TGT002', 'target', 0, 21),   -- High-priority target 2
('Rachel', 'White', 'TGT003', 'target', 0, 20),     -- High-priority target 3
('Kevin', 'Harris', 'TGT004', 'target', 0, 4),
('Amanda', 'Martin', 'TGT005', 'target', 0, 3),
('Christopher', 'Thompson', 'TGT006', 'target', 0, 2),
('Nicole', 'Garcia', 'TGT007', 'target', 0, 1),
('Matthew', 'Martinez', 'TGT008', 'target', 0, 2),
('Stephanie', 'Robinson', 'TGT009', 'target', 0, 1),
('Andrew', 'Clark', 'TGT010', 'target', 0, 1),
('Jennifer', 'Rodriguez', 'TGT011', 'target', 0, 1),
('Joshua', 'Lewis', 'TGT012', 'target', 0, 1),
('Ashley', 'Lee', 'TGT013', 'target', 0, 1),
('Ryan', 'Walker', 'TGT014', 'target', 0, 1),
('Megan', 'Hall', 'TGT015', 'target', 0, 1),
('Brandon', 'Allen', 'TGT016', 'target', 0, 1);

-- Insert 100 intel reports
INSERT INTO intel_reports (reporterId, targetId, text) VALUES
-- Reports by Sarah Johnson (REP001) - 15 reports, all 100+ characters
(2, 15, 'Target Jessica Anderson observed conducting extensive surveillance operations at the international airport terminal building. She demonstrated advanced counter-surveillance techniques and appeared to be documenting security protocols and personnel shift changes throughout the day.'),
(2, 16, 'Daniel Jackson has established contact with three foreign nationals of undetermined origin. Meetings occur weekly at rotating locations including upscale restaurants, coffee shops, and public parks. All conversations are conducted in hushed tones with frequent security checks.'),
(2, 17, 'Rachel White has been systematically mapping government facility locations across the metropolitan area. She uses sophisticated photography equipment and maintains detailed digital records of building layouts, security camera positions, and access point vulnerabilities.'),
(2, 15, 'Subject Anderson has begun exhibiting highly paranoid behavior patterns, including multiple route changes during daily commutes, frequent use of reflective surfaces to check for surveillance, and adoption of advanced communication security protocols.'),
(2, 16, 'Target Jackson observed purchasing large quantities of electronic components from multiple vendors across the city. Items include radio transmitters, signal amplifiers, encryption devices, and various computer hardware components of military-grade specifications.'),
(2, 17, 'Rachel White has established a sophisticated safe house operation in the industrial district. Location features advanced security systems, multiple escape routes, communication equipment, and what appears to be document forgery capabilities.'),
(2, 15, 'Anderson has been conducting recruitment activities targeting individuals with specific technical skill sets including computer programming, electrical engineering, and telecommunications expertise. All recruitment meetings occur in secure, private locations.'),
(2, 16, 'Daniel Jackson demonstrated advanced knowledge of explosive materials during observed training session at remote location. Training included proper handling procedures, detonation timing mechanisms, and structural damage assessment techniques.'),
(2, 17, 'Target White has been systematically infiltrating local community organizations to establish cover identities and build networks of unwitting accomplices. Her social engineering skills appear highly developed and professionally trained.'),
(2, 15, 'Jessica Anderson has established multiple financial accounts under various aliases across different banking institutions. Transaction patterns suggest funding for extended operational activities and equipment procurement for unknown purposes.'),
(2, 16, 'Subject Jackson observed conducting detailed reconnaissance of transportation infrastructure including bridges, tunnels, railway stations, and major highway intersections. Focus appears to be on identifying potential disruption points and escape routes.'),
(2, 17, 'Rachel White has been studying architectural blueprints and city planning documents obtained through various official and unofficial channels. Particular attention paid to utility systems, underground access points, and building structural weaknesses.'),
(2, 15, 'Target Anderson has established communication protocols with overseas contacts using encrypted messaging systems and coded language patterns. Communication frequency has increased significantly over the past two weeks indicating possible operational timeline acceleration.'),
(2, 16, 'Daniel Jackson has been practicing advanced driving techniques including high-speed maneuvering, evasive driving patterns, and vehicle modification procedures. Training conducted at various remote locations using different vehicle types and configurations.'),
(2, 17, 'Subject White demonstrated proficiency with advanced surveillance equipment including long-range audio recording devices, night vision technology, and digital signal interception capabilities. Equipment appears to be of professional intelligence-grade quality.'),

-- Reports by Michael Chen (REP002) - 12 reports, all 100+ characters
(3, 15, 'Jessica Anderson has been systematically documenting the daily routines and security protocols of high-ranking government officials. She maintains detailed surveillance logs and appears to be building comprehensive operational intelligence profiles for unknown purposes.'),
(3, 16, 'Target Jackson observed meeting with known arms dealers in clandestine locations throughout the metropolitan area. Meetings involve examination of various weapon systems, ammunition types, and specialized equipment including night vision gear and communication devices.'),
(3, 17, 'Rachel White has established multiple identity documents and cover stories to support extended undercover operations. Documentation includes driver licenses, passports, credit cards, and employment records all bearing different names but her photograph.'),
(3, 15, 'Subject Anderson has been conducting advanced physical surveillance training including lock picking, alarm system bypass, and covert entry techniques. Training appears professional-grade and suggests preparation for high-security target penetration operations.'),
(3, 16, 'Daniel Jackson has been studying chemical and biological warfare materials through online research and suspected procurement of laboratory equipment. Browser history reveals extensive searches for hazardous material handling and weaponization techniques.'),
(3, 17, 'Target White observed conducting test runs of complex operational scenarios involving multiple team members, sophisticated equipment, and coordinated timing sequences. Exercises appear to simulate high-stakes infiltration and extraction operations.'),
(3, 15, 'Jessica Anderson has established extensive network of informants and assets throughout various government agencies, private corporations, and community organizations. Network provides comprehensive intelligence coverage and operational support capabilities.'),
(3, 16, 'Subject Jackson has been acquiring specialized medical training including trauma surgery, pharmaceutical knowledge, and emergency medical procedures. Training suggests preparation for operations involving potential casualties and extended field operations.'),
(3, 17, 'Rachel White has been conducting psychological profiling and behavioral analysis studies of various target individuals. Research includes family background, personal relationships, psychological vulnerabilities, and potential exploitation opportunities.'),
(3, 15, 'Target Anderson observed establishing secure communication networks using multiple encrypted channels, dead drop locations, and coded messaging systems. Network architecture suggests preparation for coordinated multi-team operational activities.'),
(3, 16, 'Daniel Jackson has been practicing advanced technical skills including computer hacking, electronic surveillance, and cyber warfare techniques. Training conducted using sophisticated equipment and appears to follow professional intelligence protocols.'),
(3, 17, 'Subject White has been conducting detailed financial investigations of target organizations including banking procedures, accounting systems, and fund transfer mechanisms. Research suggests preparation for economic disruption or theft operations.'),

-- Reports by Emma Williams (REP003) - 11 reports, all 100+ characters
(4, 15, 'Jessica Anderson has been systematically infiltrating social media networks and online communities to gather intelligence on target individuals and organizations. Her digital footprint analysis reveals sophisticated social engineering and information gathering capabilities.'),
(4, 16, 'Target Jackson observed conducting advanced weapons training including precision shooting, explosive handling, and tactical movement techniques. Training conducted at remote facilities with professional-grade equipment and appears to follow military protocols.'),
(4, 17, 'Rachel White has established comprehensive surveillance operations targeting critical infrastructure facilities including power plants, water treatment facilities, and telecommunications centers. Operations involve detailed photography and technical documentation.'),
(4, 15, 'Subject Anderson has been developing extensive cover identities and background stories to support long-term undercover operations. Identities include employment history, educational credentials, and personal relationship networks all carefully constructed and documented.'),
(4, 16, 'Daniel Jackson has been conducting recruitment activities targeting individuals with specialized technical skills including aviation, maritime operations, and heavy equipment operation. Recruitment process involves careful screening and security protocols.'),
(4, 17, 'Target White observed establishing secure funding mechanisms including cryptocurrency accounts, offshore banking relationships, and precious metals acquisition. Financial operations suggest preparation for extended operational independence and resource security.'),
(4, 15, 'Jessica Anderson has been studying law enforcement procedures, investigative techniques, and judicial processes to understand potential vulnerabilities and countermeasures. Research includes court procedures, evidence handling, and prosecution strategies.'),
(4, 16, 'Subject Jackson has been practicing advanced communication protocols including radio operations, satellite communications, and encrypted data transmission. Equipment used appears to be of military or intelligence agency specification and capability.'),
(4, 17, 'Rachel White has been conducting detailed threat assessment studies of various security organizations including personnel, procedures, capabilities, and potential vulnerabilities. Analysis appears comprehensive and professionally conducted.'),
(4, 15, 'Target Anderson observed establishing multiple safe house locations throughout the metropolitan area. Each location features advanced security systems, communication equipment, and supplies for extended occupancy during operational activities.'),
(4, 16, 'Daniel Jackson has been developing specialized equipment including modified vehicles, custom electronics, and improvised devices for unknown operational purposes. Modifications appear sophisticated and professionally implemented.'),

-- Reports by people with 'both' role
(12, 15, 'Alexander Stone reporting: Jessica Anderson has been observed coordinating with multiple unknown individuals in what appears to be a sophisticated operational planning process involving detailed maps, timing schedules, and equipment inventories.'),
(12, 16, 'Stone intelligence update: Daniel Jackson has established contact with international arms dealers and has been observed testing various weapon systems at remote training facilities under cover of hunting expeditions and sporting activities.'),
(12, 17, 'Operational report from Stone: Rachel White has demonstrated advanced technical capabilities including electronic surveillance, communication interception, and digital forensics. Her equipment appears to be of professional intelligence grade.'),
(12, 18, 'Alexander Stone field report: Kevin Harris has been conducting systematic surveillance of government buildings and appears to be documenting security protocols, personnel schedules, and potential access vulnerabilities for unknown purposes.'),
(12, 19, 'Stone surveillance update: Amanda Martin has been observed meeting with foreign nationals and appears to be involved in information exchange activities. Meetings occur at various secure locations with sophisticated security protocols.'),

(13, 15, 'Victoria Cross intelligence briefing: Jessica Anderson has established multiple identity documents and has been practicing various cover stories and behavioral modifications to support extended undercover operations in sensitive environments.'),
(13, 16, 'Cross operational update: Daniel Jackson has been acquiring specialized equipment including night vision gear, communication devices, and surveillance technology. Procurement pattern suggests preparation for complex nighttime operations.'),
(13, 17, 'Field report from Cross: Rachel White has been conducting detailed reconnaissance of transportation infrastructure and appears to be identifying potential disruption points and alternative route options for operational planning purposes.'),
(13, 20, 'Victoria Cross reporting: Christopher Thompson has been observed practicing advanced driving techniques and vehicle modification procedures. Training suggests preparation for high-speed pursuit scenarios and evasive maneuvering situations.'),

(14, 15, 'Marcus Reed intelligence update: Jessica Anderson has been systematically building networks of informants and assets throughout various professional and social circles. Network development appears strategic and carefully planned for maximum intelligence coverage.'),
(14, 16, 'Reed field observation: Daniel Jackson has been studying explosive materials and has been observed conducting test detonations at remote locations. Training appears to follow professional demolition and sabotage protocols and procedures.'),
(14, 17, 'Operational report from Reed: Rachel White has established secure communication networks using encrypted channels and has been coordinating with multiple unknown individuals in what appears to be operational planning activities.'),

-- Additional reports to reach 100 total
(5, 15, 'James Brown reporting: Target Anderson observed changing vehicles frequently and using sophisticated counter-surveillance techniques during daily movements.'),
(5, 16, 'Brown field update: Daniel Jackson has been observed conducting night training exercises with unknown associates at various remote locations throughout the region.'),
(5, 17, 'Field report: Rachel White has been systematically photographing government buildings and appears to be documenting security camera positions and patrol schedules.'),

(6, 15, 'Lisa Davis intelligence: Jessica Anderson has established multiple safe communication protocols and appears to be coordinating with overseas contacts on regular basis.'),
(6, 16, 'Davis operational note: Daniel Jackson observed purchasing large quantities of survival gear and emergency supplies suggesting preparation for extended field operations.'),

(7, 15, 'Robert Miller reporting: Target Anderson has been observed conducting advanced physical training including martial arts, weapons handling, and tactical movement exercises.'),
(7, 16, 'Miller field update: Daniel Jackson has established multiple bank accounts under different names and has been conducting suspicious financial transactions.'),
(7, 17, 'Surveillance report: Rachel White has been observed meeting with known criminal associates and appears to be involved in planning activities of unknown nature.'),
(7, 18, 'Miller intelligence: Kevin Harris has been conducting surveillance training and appears to be preparing for advanced reconnaissance operations.'),

(8, 15, 'Maria Garcia reporting: Jessica Anderson has been observed establishing secure meeting locations and appears to be building operational infrastructure.'),
(8, 16, 'Garcia field note: Daniel Jackson has been practicing electronic surveillance techniques and appears proficient with professional-grade monitoring equipment.'),
(8, 17, 'Operational update: Rachel White has been observed conducting test runs of various operational scenarios with timing and coordination exercises.'),

(9, 15, 'John Wilson intelligence: Target Anderson has been systematically gathering intelligence on law enforcement procedures and appears to be studying countermeasures.'),
(9, 16, 'Wilson field report: Daniel Jackson has been observed conducting recruitment activities targeting individuals with specialized technical and operational skills.'),

(10, 15, 'Anna Moore reporting: Jessica Anderson has been observed establishing multiple cover identities and has been practicing various behavioral modifications.'),
(10, 17, 'Moore surveillance update: Rachel White has been conducting detailed financial investigations and appears to be studying fund transfer mechanisms.'),
(10, 18, 'Field intelligence: Kevin Harris has been observed practicing lock picking and covert entry techniques at various training locations.'),

(11, 15, 'Thomas Taylor reporting: Target Anderson has been observed coordinating with multiple unknown associates in what appears to be operational planning sessions.'),
(11, 16, 'Taylor field update: Daniel Jackson has been conducting advanced weapons training and appears to be preparing for tactical operations.');

-- Additional targeted reports for high-mention targets
INSERT INTO intel_reports (reporterId, targetId, text) VALUES
-- Additional reports about Jessica Anderson (Target 15) - to reach 23 mentions
(2, 15, 'Anderson observed using advanced encryption software for communications.'),
(3, 15, 'Target has been studying government security protocols extensively.'),
(4, 15, 'Anderson demonstrated knowledge of explosive materials handling.'),
(5, 15, 'Subject has established multiple escape route options.'),
(6, 15, 'Target observed conducting nighttime reconnaissance operations.'),
(7, 15, 'Anderson has been practicing advanced combat techniques.'),
(8, 15, 'Subject demonstrated proficiency with surveillance equipment.'),
(9, 15, 'Target has been establishing international communication networks.'),
(10, 15, 'Anderson observed conducting vehicle modification activities.'),
(11, 15, 'Subject has been studying architectural building plans.'),
(12, 15, 'Target demonstrated advanced technical hacking capabilities.'),
(13, 15, 'Anderson has been conducting psychological warfare training.'),
(14, 15, 'Subject observed establishing weapons cache locations.'),

-- Additional reports about Daniel Jackson (Target 16) - to reach 21 mentions  
(2, 16, 'Jackson observed conducting chemical weapons research activities.'),
(3, 16, 'Target has been establishing secure funding mechanisms.'),
(4, 16, 'Jackson demonstrated advanced tactical movement techniques.'),
(5, 16, 'Subject has been conducting aerial reconnaissance training.'),
(6, 16, 'Target observed studying critical infrastructure vulnerabilities.'),
(7, 16, 'Jackson has been practicing advanced interrogation techniques.'),
(8, 16, 'Subject demonstrated expertise in electronic warfare systems.'),
(9, 16, 'Target has been conducting maritime operation preparations.'),
(10, 16, 'Jackson observed establishing international smuggling networks.'),

-- Additional reports about Rachel White (Target 17) - to reach 20 mentions
(5, 17, 'White observed conducting advanced surveillance countermeasures.'),
(6, 17, 'Target has been studying law enforcement communication protocols.'),
(7, 17, 'White demonstrated advanced document forgery capabilities.'),

-- Reports targeting people with 'both' role
(2, 12, 'Alexander Stone has been observed conducting suspicious activities including clandestine meetings with unknown foreign nationals.'),
(3, 12, 'Stone demonstrated advanced tactical training and appears to be preparing for complex operational activities.'),
(4, 12, 'Target Stone has established multiple safe house locations and sophisticated communication networks.'),
(5, 12, 'Alexander Stone observed coordinating with various criminal associates and appears to be planning significant operations.'),
(6, 12, 'Stone has been acquiring specialized equipment and appears to be building operational capabilities.'),
(7, 12, 'Target Stone demonstrated advanced weapons proficiency and tactical knowledge during observed training sessions.'),
(8, 12, 'Alexander Stone has been conducting recruitment activities and building networks of operational assets.'),
(9, 12, 'Stone observed establishing financial networks and appears to be funding unknown operational activities.'),

(2, 13, 'Victoria Cross has been conducting systematic intelligence gathering operations targeting government and private sector organizations.'),
(3, 13, 'Cross demonstrated advanced technical capabilities including electronic surveillance and communication interception systems.'),
(4, 13, 'Target Cross has been establishing multiple identity documents and cover stories for extended undercover operations.'),
(5, 13, 'Victoria Cross observed coordinating with international contacts and appears to be involved in information exchange activities.'),
(6, 13, 'Cross has been conducting detailed threat assessments and appears to be planning significant operational activities.'),
(7, 13, 'Target Cross demonstrated advanced combat training and appears to be preparing for tactical operations.'),

(2, 14, 'Marcus Reed has been observed conducting sophisticated surveillance operations targeting critical infrastructure and government facilities.'),
(3, 14, 'Reed demonstrated advanced technical skills including computer hacking and electronic warfare capabilities during observed activities.'),
(4, 14, 'Target Reed has been establishing secure communication networks and coordinating with multiple unknown associates.'),
(5, 14, 'Marcus Reed observed acquiring specialized equipment and appears to be building comprehensive operational capabilities.'),
(6, 14, 'Reed has been conducting advanced training exercises and appears to be preparing for complex tactical operations.'),
(7, 14, 'Target Reed demonstrated knowledge of explosive materials and has been observed conducting test detonations.'),
(8, 14, 'Marcus Reed has been establishing multiple safe house locations and sophisticated security protocols.'),

-- Additional reports for other targets to complete 100 reports
(8, 18, 'Kevin Harris observed conducting advanced surveillance training exercises.'),
(9, 18, 'Harris has been studying security protocols and countermeasures.'),
(10, 18, 'Target Harris demonstrated proficiency with technical equipment.'),
(11, 18, 'Kevin Harris observed establishing communication networks.'),

(8, 19, 'Amanda Martin has been conducting suspicious financial transactions.'),
(9, 19, 'Martin observed meeting with unknown foreign contacts.'),
(10, 19, 'Target Martin demonstrated advanced operational security measures.'),

(8, 20, 'Christopher Thompson observed conducting vehicle modification activities.'),
(9, 20, 'Thompson has been practicing advanced driving techniques.'),

(8, 21, 'Nicole Garcia observed conducting surveillance countermeasures training.'),

(9, 22, 'Matthew Martinez has been studying building architectural plans.'),
(10, 22, 'Martinez observed conducting reconnaissance operations.'),

(9, 23, 'Stephanie Robinson has been establishing secure communication protocols.'),

(10, 24, 'Andrew Clark observed conducting weapons training exercises.'),

(10, 25, 'Jennifer Rodriguez has been studying explosive materials handling.'),

(11, 26, 'Joshua Lewis observed conducting tactical movement training.'),

(11, 27, 'Ashley Lee has been establishing operational safe houses.'),

(11, 28, 'Ryan Walker observed conducting technical surveillance activities.'),

(11, 29, 'Megan Hall has been studying law enforcement procedures.'),

(11, 30, 'Brandon Allen observed conducting advanced combat training.');
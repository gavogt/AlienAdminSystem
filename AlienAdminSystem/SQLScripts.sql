CREATE TABLE AtmosphereTypes (
    AtmosphereTypeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE AlienGroups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(100) NOT NULL
);

CREATE TABLE dbo.FacilityType (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Type NVARCHAR(100) NOT NULL
);

SET IDENTITY_INSERT AlienGroups ON;

INSERT INTO AlienGroups (GroupID, GroupName) VALUES (1, 'Zorgons');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (2, 'Xenons');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (3, 'Galactic Science Consortium');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (4, 'Cosmic Cultural Ambassadors');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (5, 'Plutonians');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (6, 'Martians');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (7, 'Intergalactic Arts & Traditions Forum');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (8, 'Venusians');
INSERT INTO AlienGroups (GroupID, GroupName) VALUES (9, 'Interstellar Research Alliance');

SET IDENTITY_INSERT AlienGroups OFF;

INSERT INTO AtmosphereTypes (Name) VALUES ('Oxygen-rich');
INSERT INTO AtmosphereTypes (Name) VALUES ('Nitrogen-rich');
INSERT INTO AtmosphereTypes (Name) VALUES ('Carbon Dioxide-rich');

INSERT INTO FacilityType (Type) VALUES ('Embassy');
INSERT INTO FacilityType (Type) VALUES ('Research Lab');
INSERT INTO FacilityType (Type) VALUES ('Quarantine Zone');



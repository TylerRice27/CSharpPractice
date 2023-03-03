CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS cities(
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT "city id primary key",
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Updated',
        name VARCHAR(255) COMMENT 'City Name',
        img VARCHAR(1000) COMMENT 'City image',
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) DEFAULT charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS teams(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT "Team Id primary key",
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Updated',
        name VARCHAR(500) COMMENT 'Team Name',
        img VARCHAR(500) COMMENT 'Team Image',
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) DEFAULT charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS heros(
        id INT NOT NULL AUTO_INCREMENT PRIMARY key COMMENT "Hero Id Primary Key",
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT "Time Created",
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Updated',
        name VARCHAR(500) COMMENT 'Hero Name',
        img VARCHAR(2000) COMMENT 'Hero Image',
        bio VARCHAR(500) COMMENT 'Hero Bio',
        creatorId VARCHAR(255) NOT NULL,
        cityId INT NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        Foreign Key (cityId) REFERENCES cities(id) ON DELETE CASCADE
    ) DEFAULT charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS villains(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT "Villian Id Primary Key",
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT "Time Created",
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT "Time Updated",
        name VARCHAR(500) COMMENT "Villian Name",
        img VARCHAR(2000) COMMENT "Villian Img",
        bio VARCHAR(500) COMMENT "Villian Bio",
        creatorId VARCHAR(255) NOT NULL,
        cityId INT NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        Foreign Key (cityId) REFERENCES cities(id) ON DELETE CASCADE
    ) DEFAULT charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS teamups(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT "Teamup Id and Many to Many Realtionship",
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT "Time Created",
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Updated',
        heroId INT,
        teamId INT NOT NULL,
        villianId INT,
        FOREIGN KEY (heroId) REFERENCES heros(id) ON DELETE CASCADE,
        FOREIGN KEY (teamId) REFERENCES teams(id) ON DELETE CASCADE,
        /* Need to add villian table and added a many to many realtionship */
    )
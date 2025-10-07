IF db_id('College1en') IS NULL CREATE DATABASE College1en;
GO

USE College1en


CREATE TABLE Programs (
    ProgId VARCHAR(5) NOT NULL PRIMARY KEY,
    ProgName VARCHAR(50) NOT NULL
);

CREATE TABLE Courses (
    CId VARCHAR(7) NOT NULL PRIMARY KEY,
    CName VARCHAR(50) NOT NULL,
    ProgId VARCHAR(5) NOT NULL
);

CREATE TABLE Students (
    StId VARCHAR(10) NOT NULL PRIMARY KEY,
    StName VARCHAR(50) NOT NULL,
    ProgId VARCHAR(5) NOT NULL
);

CREATE TABLE Enrollments (
    StId VARCHAR(10) NOT NULL,
    CId VARCHAR(7) NOT NULL,
    FinalGrade INT,
    PRIMARY KEY (StId, CId)
);

ALTER TABLE Courses
ADD CONSTRAINT FK_Courses_Programs
FOREIGN KEY (ProgId) REFERENCES Programs(ProgId)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Students
ADD CONSTRAINT FK_Students_Programs
FOREIGN KEY (ProgId) REFERENCES Programs(ProgId)
ON DELETE NO ACTION
ON UPDATE CASCADE;

ALTER TABLE Enrollments
ADD CONSTRAINT FK_Enrollments_Students
FOREIGN KEY (StId) REFERENCES Students(StId)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Enrollments
ADD CONSTRAINT FK_Enrollments_Courses
FOREIGN KEY (CId) REFERENCES Courses(CId)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

INSERT INTO Programs (ProgId, ProgName) VALUES
('P1001', 'Computer Science'),
('P2002', 'Electrical Engineering'),
('P3001', 'English Literature'),
('P4005', 'Fashion Marketing');


INSERT INTO Courses (CId, CName, ProgId) VALUES
('C110001', 'Introduction to C#', 'P1001'),
('C220002', 'Energy Systems', 'P2002'),
('C310009', 'Introduction to College English', 'P3001'),
('C450002', 'Fashion and Culture', 'P4005');

INSERT INTO Students (StId, StName, ProgId) VALUES
('S202100001', 'Elon Musk', 'P1001'),
('S202200002', 'Thomas Edison', 'P2002'),
('S201900002', 'William Shakespeare', 'P3001'),
('S202400002', 'Tom Ford', 'P4005');

INSERT INTO Enrollments (StId, CId, FinalGrade) VALUES
('S202100001', 'C110001', 85),
('S202200002', 'C220002', 90),
('S201900002', 'C310009', 98),
('S202400002', 'C450002', 79);

SELECT * FROM Programs
SELECT * FROM Courses
SELECT * FROM Students
SELECT * FROM Enrollments
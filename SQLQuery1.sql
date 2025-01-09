-- إنشاء قاعدة البيانات
CREATE DATABASE ClinicManagementDB;
GO

-- استخدام قاعدة البيانات
USE ClinicManagementDB;
GO

-- جدول المستخدمين
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL -- مثال: Patient, Doctor, Admin
);
GO

-- جدول الأطباء
CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL
);
GO

-- جدول المواعيد
CREATE TABLE Appointments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DoctorId INT NOT NULL,
    UserId INT NOT NULL,
    [Date] DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL, -- مثال: Confirmed, Canceled
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- إدخال بيانات افتراضية (اختياري)
INSERT INTO Users (Name, Email, Password, Role) VALUES 
('Admin User', 'admin@clinic.com', 'hashed_password', 'Admin'),
('John Doe', 'john.doe@example.com', 'hashed_password', 'Patient');

INSERT INTO Doctors (Name, Specialization) VALUES 
('Dr. Smith', 'Cardiology'),
('Dr. Brown', 'Dermatology');

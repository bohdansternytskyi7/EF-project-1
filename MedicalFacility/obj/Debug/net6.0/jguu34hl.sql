IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Doctors] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Doctors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Medicaments] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [Type] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Medicaments] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Patients] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Prescription_Medicaments] (
    [IdMedicament] int NOT NULL,
    [IdPrescription] int NOT NULL,
    [Dose] int NULL,
    [Description] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Prescription_Medicaments] PRIMARY KEY ([IdMedicament], [IdPrescription])
);
GO

CREATE TABLE [Prescriptions] (
    [Id] int NOT NULL IDENTITY,
    [IdPatient] int NOT NULL,
    [IdDoctor] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Prescriptions] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231215195501_Added Models', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE INDEX [IX_Prescriptions_IdDoctor] ON [Prescriptions] ([IdDoctor]);
GO

CREATE INDEX [IX_Prescriptions_IdPatient] ON [Prescriptions] ([IdPatient]);
GO

ALTER TABLE [Prescriptions] ADD CONSTRAINT [FK_Prescriptions_Doctors_IdDoctor] FOREIGN KEY ([IdDoctor]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Prescriptions] ADD CONSTRAINT [FK_Prescriptions_Patients_IdPatient] FOREIGN KEY ([IdPatient]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231218175610_ExtendPrescriptionModel', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctors]'))
    SET IDENTITY_INSERT [Doctors] ON;
INSERT INTO [Doctors] ([Id], [Email], [FirstName], [LastName])
VALUES (1, N'charlie@gmail.com', N'Charlie', N'Davis'),
(2, N'bob@gmail.com', N'Bob', N'Johnson'),
(3, N'grace@gmail.com', N'Grace', N'Miller');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctors]'))
    SET IDENTITY_INSERT [Doctors] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicaments]'))
    SET IDENTITY_INSERT [Medicaments] ON;
INSERT INTO [Medicaments] ([Id], [Description], [Name], [Type])
VALUES (1, N'Aspirin is a common over-the-counter medication that is used to reduce pain, fever, and inflammation.', N'Aspirin', N'Analgesic'),
(2, N'Ibuprofen is a nonsteroidal anti-inflammatory drug (NSAID) commonly used to relieve pain, reduce fever, and alleviate inflammation.', N'Ibuprofen', N'NSAID'),
(3, N'Simvastatin is a statin medication used to lower cholesterol levels in the blood. It works by inhibiting the production of cholesterol in the liver.', N'Simvastatin', N'Statin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicaments]'))
    SET IDENTITY_INSERT [Medicaments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Birthdate', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patients]'))
    SET IDENTITY_INSERT [Patients] ON;
INSERT INTO [Patients] ([Id], [Birthdate], [FirstName], [LastName])
VALUES (1, '1980-01-01T00:00:00.0000000', N'John', N'Doe'),
(2, '1985-05-15T00:00:00.0000000', N'Jane', N'Smith'),
(3, '2000-12-06T00:00:00.0000000', N'Matt', N'Hofman');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Birthdate', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patients]'))
    SET IDENTITY_INSERT [Patients] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'IdPrescription', N'Description', N'Dose') AND [object_id] = OBJECT_ID(N'[Prescription_Medicaments]'))
    SET IDENTITY_INSERT [Prescription_Medicaments] ON;
INSERT INTO [Prescription_Medicaments] ([IdMedicament], [IdPrescription], [Description], [Dose])
VALUES (1, 2, N'Description', 5),
(2, 4, N'Description', 15),
(3, 1, N'Description', 12),
(3, 3, N'Description', 10);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'IdPrescription', N'Description', N'Dose') AND [object_id] = OBJECT_ID(N'[Prescription_Medicaments]'))
    SET IDENTITY_INSERT [Prescription_Medicaments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescriptions]'))
    SET IDENTITY_INSERT [Prescriptions] ON;
INSERT INTO [Prescriptions] ([Id], [Date], [DueDate], [IdDoctor], [IdPatient])
VALUES (1, '2023-12-20T22:04:34.2338673+01:00', '2023-12-23T22:04:34.2338698+01:00', 1, 2),
(2, '2023-11-05T00:00:00.0000000', '2023-12-30T00:00:00.0000000', 1, 3),
(3, '2023-12-24T22:04:34.2338703+01:00', '2024-01-02T22:04:34.2338704+01:00', 2, 1),
(4, '2023-12-02T00:00:00.0000000', '2023-02-15T00:00:00.0000000', 3, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescriptions]'))
    SET IDENTITY_INSERT [Prescriptions] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231218210434_InsertValues', N'7.0.0');
GO

COMMIT;
GO


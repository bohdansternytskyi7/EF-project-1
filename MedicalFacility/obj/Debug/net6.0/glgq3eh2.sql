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


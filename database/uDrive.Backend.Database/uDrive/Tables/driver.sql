CREATE TABLE [uDrive].[driver] (
  [id] NVARCHAR(450) NOT NULL,
  [idDrivinglicense] NVARCHAR(450) NOT NULL,
  [idPerson] NVARCHAR(450) NOT NULL,
  CONSTRAINT [PK_driver]  PRIMARY KEY CLUSTERED ([id] ASC))
GO
ALTER TABLE [uDrive].[driver] ADD CONSTRAINT [FK_Driver_DrivingLicence] FOREIGN KEY ([idDrivinglicense]) REFERENCES [uDrive].[drivingLicence] ([id])
GO
ALTER TABLE [uDrive].[driver] ADD CONSTRAINT [FK_Driver_Person] FOREIGN KEY ([idPerson]) REFERENCES [uDrive].[person] ([id])
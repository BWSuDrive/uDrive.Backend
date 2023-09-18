CREATE TABLE [uDrive].[drivingLicence] (
  [id] NVARCHAR(450) NOT NULL,
  [expireDate] DATE NOT NULL,
  [licenceClass] NVARCHAR(20) NOT NULL,
  CONSTRAINT [PK_drivingLicence]  PRIMARY KEY CLUSTERED ([id] ASC))
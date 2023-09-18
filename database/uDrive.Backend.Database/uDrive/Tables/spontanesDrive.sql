CREATE TABLE [uDrive].[spontanesDrive] (
  [id] NVARCHAR(450) NOT NULL,
  [date] DATETIME,
  [idDrivingScheduleOverwrite] NVARCHAR(450) NOT NULL,
  CONSTRAINT [PK_spontanesDrive]  PRIMARY KEY CLUSTERED ([id] ASC))
GO
ALTER TABLE [uDrive].[spontanesDrive] ADD CONSTRAINT [FK_DrivingSchedule_SpontanesDrive] FOREIGN KEY ([idDrivingScheduleOverwrite]) REFERENCES [uDrive].[drivingSchedule] ([id])
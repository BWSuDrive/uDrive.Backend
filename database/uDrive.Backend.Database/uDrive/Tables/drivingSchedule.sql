CREATE TABLE [uDrive].[drivingSchedule] (
  [id] NVARCHAR(450) NOT NULL,
  [start] DATETIME NOT NULL,
  [arrival] DATETIME NOT NULL,
  [idWeekday] NVARCHAR(450) NOT NULL,
  CONSTRAINT [PK_drivingSchedule]  PRIMARY KEY CLUSTERED ([id] ASC))
GO
ALTER TABLE [uDrive].[drivingSchedule] ADD CONSTRAINT [FK_Weekday_DrivingSchedule] FOREIGN KEY ([idWeekday]) REFERENCES [uDrive].[weekday] ([id])
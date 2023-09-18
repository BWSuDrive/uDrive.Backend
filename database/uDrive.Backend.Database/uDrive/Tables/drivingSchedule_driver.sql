CREATE TABLE [uDrive].[drivingSchedule_driver] (
  [drivingSchedule_id] NVARCHAR(450),
  [driver_id] NVARCHAR(450),
  PRIMARY KEY ([drivingSchedule_id], [driver_id])
);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([drivingSchedule_id]) REFERENCES [uDrive].[drivingSchedule] ([id]);
GO
ALTER TABLE [uDrive].[drivingSchedule_driver] ADD FOREIGN KEY ([driver_id]) REFERENCES [uDrive].[driver] ([id]);
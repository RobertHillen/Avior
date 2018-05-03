USE [Avior]
GO

TRUNCATE TABLE [dbo].[Teams]
TRUNCATE TABLE [dbo].[Coaches]
TRUNCATE TABLE [dbo].[Players]
GO

DECLARE @time1645 time(0) = '16:45:00';  
DECLARE @time1800 time(0) = '18:00:00';  

SET IDENTITY_INSERT [dbo].[Teams] ON

INSERT INTO [dbo].[Teams] ([ID], [Season], [Category], [Name], [TrainingDay1], [TrainingTime1], [TrainingDay2], [TrainingTime2])
VALUES (1, 1, 1, 'CMV 5.2', 1, @time1645, null, null)
INSERT INTO [dbo].[Teams] ([ID], [Season], [Category], [Name], [TrainingDay1], [TrainingTime1], [TrainingDay2], [TrainingTime2])
VALUES (2, 1, 1, 'CMV 5.5', 1, @time1645, null, null)
INSERT INTO [dbo].[Teams] ([ID], [Season], [Category], [Name], [TrainingDay1], [TrainingTime1], [TrainingDay2], [TrainingTime2])
VALUES (3, 1, 2, 'MC 5', 1, @time1800, 4, @time1800)

SET IDENTITY_INSERT [dbo].[Teams] OFF

GO

SET IDENTITY_INSERT [dbo].[Coaches] ON

INSERT INTO [dbo].[Coaches] ([ID], [Name], [PhoneNumber], [Email], [TeamId])
VALUES (1, 'Marieke Haverkort', '06-20335823', 'mariekehaverkort@gmail.com', 1)
INSERT INTO [dbo].[Coaches] ([ID], [Name], [PhoneNumber], [Email], [TeamId])
VALUES (2, 'Sandra Massink', '06-20813804', 'r.s.massink@kickxl.nl', 1)
INSERT INTO [dbo].[Coaches] ([ID], [Name], [PhoneNumber], [Email], [TeamId])
VALUES (3, 'Marjan van de Vondervoort', '06-24248466', 'marjan@vondervoort.com', 2)
INSERT INTO [dbo].[Coaches] ([ID], [Name], [PhoneNumber], [Email], [TeamId])
VALUES (4, 'Marcel Hazelaar', '06-46624070', 'marcelhazelaar@gmail.com', 3)

SET IDENTITY_INSERT [dbo].[Coaches] OFF

GO

INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Joann Bijlsma' , null, 1)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Younique Gerritsen' , null, 1)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Michelle Haverkort' , null, 1)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Lémoni Massink' , null, 1)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Femme Wiegers' , null, 1)

INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Merle de Groot' , null, 2)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Anne Oldeniel' , null, 2)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Ella Velner' , null, 2)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Silke van de Vondervoort' , null, 2)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Isa van der Werff' , null, 2)

INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Annelinde Groeneveld' , '06-22579238', 3)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Anouk Joosse' , '06-37273828', 3)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Delfin Serenci' , '06-21905172', 3)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Geerte van Amersfoort' , '06-39287689', 3)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Aylin Tasbas' , '06-42458952', 3)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Vera Hazelaar' , '06-43140089', 3)
INSERT INTO [dbo].[Players] ([Name], [PhoneNumber], [TeamId])
VALUES ('Sure Sengun' , null, 3)

GO
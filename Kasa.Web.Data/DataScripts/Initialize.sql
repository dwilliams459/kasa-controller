USE [HomeAutomation]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 12/10/2022 9:05:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[DeviceType]    Script Date: 12/10/2022 9:05:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP TABLE DeviceType
GO

CREATE TABLE [dbo].[DeviceType](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_DeviceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (1, N'Outlet')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (2, N'Light')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (3, N'Dimmer')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (4, N'Outlet Multi Plug')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (5, N'Thermostat')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (6, N'Camera')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (7, N'Colored Light')
INSERT [dbo].[DeviceType] ([Id], [Name]) VALUES (8, N'Light Strip')
GO

DROP TABLE Devices
GO

CREATE TABLE [dbo].[Devices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Model] [nvarchar](255) NULL,
	[MAC] [nvarchar](30) NOT NULL,
	[Maker] nvarchar(100) NULL,
	IP [nvarchar](100) NULL,
	[Type] [int] NULL
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Devices] ON 
GO
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS220', N'HS220', 'Kasa', N'68-FF-7B-78-5A-EE', N'192.168.0.170', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'KL110', 'Kasa', N'60-32-B1-36-D7-07', N'192.168.0.185', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'KL110', 'Kasa', N'5C-A6-E6-AC-61-38', N'192.168.0.208', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'HS105', 'Kasa', N'AC-84-C6-D4-05-71', N'192.168.0.101', 3)

INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS210', N'HS210', 'Kasa', N'5C-A6-E6-AC-61-38', N'192.168.0.191', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'KL110', 'Kasa', N'5C-A6-E6-AC-61-38', N'192.168.0.', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'KL110', 'Kasa', N'68-FF-7B-78-DA-09', N'192.168.0.', 3)

INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS200', N'HS200', 'Kasa', N'98-DA-C4-77-86-4E', N'192.168.0.142', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'Outside Chirstmas Lights', N'EP40', 'Kasa', N'34-60-F9-FB-76-00', N'192.168.0.192', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS200', N'HS200', 'Kasa', N'98-DA-C4-92-02-83', N'192.168.0.176', 3)

INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS105', N'HS105', 'Kasa', N'B0-BE-76-E3-E0-B9', N'192.168.0.113', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS200', N'JS200', 'Kasa', N'68-FF-7B-B8-BB-FB', N'192.168.0.239', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'KL110', 'Kasa', N'B4-B0-24-04-CB-C8', N'192.168.0.117', 3)

INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS105', N'HS105', 'Kasa', N'B0-BE-76-E3-DF-F2', N'192.168.0.121', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'HS210', N'HS210', 'Kasa', N'D8-0D-17-A2-0B-B0', N'192.168.0.174', 3)
INSERT [dbo].[Devices] ([Id], [Name], [Model], Maker, [MAC], [IP], [Type]) VALUES (3, N'KL110', N'KL110', 'Kasa', N'D8-07-B6-A9-23-F5', N'192.168.0.154', 3)

GO
SET IDENTITY_INSERT [dbo].[Devices] OFF
GO



USE [PruebaPractica]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitString]
(
    @List NVARCHAR(MAX),
    @Delim VARCHAR(255)
)
RETURNS TABLE
AS
    RETURN ( SELECT [Value] FROM 
      ( 
        SELECT 
          [Value] = LTRIM(RTRIM(SUBSTRING(@List, [Number],
          CHARINDEX(@Delim, @List + @Delim, [Number]) - [Number])))
        FROM (SELECT Number = ROW_NUMBER() OVER (ORDER BY name)
          FROM sys.all_objects) AS x
          WHERE Number <= LEN(@List)
          AND SUBSTRING(@Delim + @List, [Number], LEN(@Delim)) = @Delim
      ) AS y
    );
GO
/****** Object:  Table [dbo].[test_CatalogoHabilidades]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_CatalogoHabilidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [varchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test_HabilidadesXUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_HabilidadesXUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdHabilidad] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdHabilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test_TelefonosXUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_TelefonosXUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test_TipoIdentificacion]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_TipoIdentificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [varchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test_TipoUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_TipoUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [varchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test_Usuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoIdentificacion] [int] NULL,
	[NumeroIdentificacion] [varchar](100) NULL,
	[Nombre] [varchar](500) NULL,
	[Usuario] [varchar](100) NULL,
	[Clave] [varchar](100) NULL,
	[IdTipoUsuario] [int] NULL,
	[Correo] [varchar](200) NULL,
	[FechaIngreso] [datetime] NULL,
	[Estado] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
	[PrimerApellido] [varchar](200) NULL,
	[SegundoApellido] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[test_CatalogoHabilidades] ON 

INSERT [dbo].[test_CatalogoHabilidades] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (1, N'Buena comunicación', CAST(N'2024-05-11T21:19:27.427' AS DateTime), 1)
INSERT [dbo].[test_CatalogoHabilidades] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (2, N'Buena organización', CAST(N'2024-05-11T21:19:27.427' AS DateTime), 1)
INSERT [dbo].[test_CatalogoHabilidades] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (3, N'Trabajo en equipo', CAST(N'2024-05-11T21:19:27.427' AS DateTime), 1)
INSERT [dbo].[test_CatalogoHabilidades] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (4, N'Puntualidad', CAST(N'2024-05-11T21:19:27.427' AS DateTime), 1)
INSERT [dbo].[test_CatalogoHabilidades] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (5, N'Ser creativo', CAST(N'2024-05-11T21:19:27.427' AS DateTime), 1)
INSERT [dbo].[test_CatalogoHabilidades] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (6, N'Facilidad de adaptación', CAST(N'2024-05-11T21:19:27.427' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[test_CatalogoHabilidades] OFF
GO
SET IDENTITY_INSERT [dbo].[test_HabilidadesXUsuario] ON 

INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (39, 1, 1, CAST(N'2024-05-12T21:47:32.983' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (1, 1, 2, CAST(N'2024-05-12T18:55:24.860' AS DateTime), 0)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (2, 1, 3, CAST(N'2024-05-12T18:55:24.860' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (3, 1, 6, CAST(N'2024-05-12T18:55:24.860' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (13, 5, 3, CAST(N'2024-05-12T19:24:43.270' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (14, 5, 5, CAST(N'2024-05-12T19:24:43.270' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (15, 5, 6, CAST(N'2024-05-12T19:24:43.270' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (16, 6, 1, CAST(N'2024-05-12T19:38:39.980' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (17, 6, 3, CAST(N'2024-05-12T19:38:39.980' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (18, 6, 4, CAST(N'2024-05-12T19:38:39.980' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (19, 7, 1, CAST(N'2024-05-12T21:11:39.107' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (20, 7, 2, CAST(N'2024-05-12T21:11:39.107' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (21, 7, 3, CAST(N'2024-05-12T21:11:39.107' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (48, 8, 1, CAST(N'2024-05-21T16:21:29.363' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (22, 8, 3, CAST(N'2024-05-12T21:14:19.103' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (23, 8, 4, CAST(N'2024-05-12T21:14:19.103' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (24, 8, 5, CAST(N'2024-05-12T21:14:19.103' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (25, 9, 1, CAST(N'2024-05-12T21:15:56.263' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (26, 9, 3, CAST(N'2024-05-12T21:15:56.263' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (27, 9, 6, CAST(N'2024-05-12T21:15:56.263' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (28, 10, 1, CAST(N'2024-05-12T21:20:15.817' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (29, 10, 2, CAST(N'2024-05-12T21:20:15.817' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (30, 10, 4, CAST(N'2024-05-12T21:20:15.817' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (31, 11, 2, CAST(N'2024-05-12T21:21:58.210' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (32, 11, 3, CAST(N'2024-05-12T21:21:58.210' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (33, 11, 4, CAST(N'2024-05-12T21:21:58.210' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (41, 13, 1, CAST(N'2024-05-20T20:31:37.370' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (42, 13, 2, CAST(N'2024-05-20T20:31:37.370' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (43, 13, 3, CAST(N'2024-05-20T20:31:37.370' AS DateTime), 0)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (44, 13, 4, CAST(N'2024-05-20T20:58:31.477' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (45, 14, 1, CAST(N'2024-05-21T16:13:13.210' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (46, 14, 2, CAST(N'2024-05-21T16:13:13.210' AS DateTime), 1)
INSERT [dbo].[test_HabilidadesXUsuario] ([Id], [IdUsuario], [IdHabilidad], [FechaRegistro], [Estado]) VALUES (47, 14, 4, CAST(N'2024-05-21T16:13:13.210' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[test_HabilidadesXUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[test_TelefonosXUsuario] ON 

INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (1, 1, N'22222222', CAST(N'2024-05-12T18:55:24.860' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (11, 1, N'23232323', CAST(N'2024-05-12T21:30:48.940' AS DateTime), 0)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (12, 1, N'23233456', CAST(N'2024-05-12T21:42:55.773' AS DateTime), 0)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (13, 1, N'34343456', CAST(N'2024-05-12T21:47:32.973' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (5, 5, N'11111111', CAST(N'2024-05-12T19:24:43.270' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (6, 6, N'33333333', CAST(N'2024-05-12T19:38:39.977' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (7, 7, N'00000000', CAST(N'2024-05-12T21:11:39.100' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (19, 8, N'21331232', CAST(N'2024-05-21T16:21:29.363' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (8, 8, N'44444444', CAST(N'2024-05-12T21:14:19.093' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (9, 10, N'12341234', CAST(N'2024-05-12T21:20:15.813' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (10, 11, N'12341234', CAST(N'2024-05-12T21:21:58.207' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (16, 13, N'11111111', CAST(N'2024-05-20T20:31:37.367' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (15, 13, N'88888888', CAST(N'2024-05-20T20:31:37.367' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (18, 14, N'11111111', CAST(N'2024-05-21T16:13:13.210' AS DateTime), 1)
INSERT [dbo].[test_TelefonosXUsuario] ([Id], [IdUsuario], [Telefono], [FechaRegistro], [Estado]) VALUES (17, 14, N'22222222', CAST(N'2024-05-21T16:13:13.210' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[test_TelefonosXUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[test_TipoIdentificacion] ON 

INSERT [dbo].[test_TipoIdentificacion] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (1, N'Nacional', CAST(N'2024-05-11T21:20:35.547' AS DateTime), 1)
INSERT [dbo].[test_TipoIdentificacion] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (2, N'Extranjero', CAST(N'2024-05-11T21:20:35.547' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[test_TipoIdentificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[test_TipoUsuario] ON 

INSERT [dbo].[test_TipoUsuario] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (1, N'Administrador', CAST(N'2024-05-11T21:21:20.917' AS DateTime), 1)
INSERT [dbo].[test_TipoUsuario] ([Id], [Detalle], [FechaIngreso], [Estado]) VALUES (2, N'Consultor', CAST(N'2024-05-11T21:21:20.917' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[test_TipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[test_Usuario] ON 

INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (1, 1, N'402270879', N'Olman2', N'ocheng', N'Clave123', 1, N'olman247@gmail.com', CAST(N'2024-05-12T18:55:24.857' AS DateTime), 1, CAST(N'2024-05-21T16:19:55.567' AS DateTime), N'Cheng', N'Lam')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (5, 1, N'11111111', N'ResetUser', N'prueba', N'Prueba123', 2, N'prueba@correo.com', CAST(N'2024-05-12T19:24:43.267' AS DateTime), 0, NULL, N'ResetUser', N'ResetUser')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (6, 1, N'222222222', N'Prueba', N'prueba2', N'Prueba2', 2, N'prueba2@correo.com', CAST(N'2024-05-12T19:38:39.977' AS DateTime), 0, NULL, N'Prueba', N'Prueba')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (7, 2, N'12345', N'extranjero', N'extranjero', N'Extra123', 1, N'extranjero@correo.com', CAST(N'2024-05-12T21:11:39.100' AS DateTime), 0, NULL, N'extranjero', N'extranjero')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (8, 2, N'Prueba2', N'Prueba2', N'Prueba2', N'Prueba2', 1, N'Prueba2@Prueba2.com', CAST(N'2024-05-12T21:14:19.093' AS DateTime), 1, CAST(N'2024-05-21T16:21:29.360' AS DateTime), N'Prueba2', N'Prueba2')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (9, 1, N'1234', N'Prueba3', N'Prueba3', N'Prueba3', 2, N'Prueba3@Prueba3.com', CAST(N'2024-05-12T21:15:56.263' AS DateTime), 0, NULL, N'Prueba3', N'Prueba3')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (10, 1, N'123', N'EmptyFields', N'EmptyFields', N'EmptyFields123', 2, N'empty@empty.com', CAST(N'2024-05-12T21:20:15.810' AS DateTime), 0, NULL, N'EmptyFields', N'EmptyFields')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (11, 1, N'123456', N'Wut', N'Wut', N'Wut1234', 1, N'wut@wut.com', CAST(N'2024-05-12T21:21:58.203' AS DateTime), 0, NULL, N'Wut', N'Wut')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (13, 1, N'402270878', N'Olman', N'Oclam', N'gissa123', 1, N'ocheng@correo.com', CAST(N'2024-05-20T20:31:37.347' AS DateTime), 0, CAST(N'2024-05-20T20:58:31.400' AS DateTime), N'Cheng', N'Lam')
INSERT [dbo].[test_Usuario] ([Id], [IdTipoIdentificacion], [NumeroIdentificacion], [Nombre], [Usuario], [Clave], [IdTipoUsuario], [Correo], [FechaIngreso], [Estado], [FechaActualizacion], [PrimerApellido], [SegundoApellido]) VALUES (14, 1, N'123456789', N'Usuario', N'Usuario', N'Clave123', 1, N'olman247@gmail.com', CAST(N'2024-05-21T16:13:13.207' AS DateTime), 0, NULL, N'Usuario', N'Usuario')
SET IDENTITY_INSERT [dbo].[test_Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__test_Usu__FCA68D91A3E9A83C]    Script Date: 5/21/2024 8:29:31 PM ******/
ALTER TABLE [dbo].[test_Usuario] ADD UNIQUE NONCLUSTERED 
(
	[NumeroIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[test_CatalogoHabilidades] ADD  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[test_CatalogoHabilidades] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[test_HabilidadesXUsuario] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[test_HabilidadesXUsuario] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[test_TelefonosXUsuario] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[test_TelefonosXUsuario] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[test_TipoIdentificacion] ADD  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[test_TipoIdentificacion] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[test_TipoUsuario] ADD  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[test_TipoUsuario] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[test_Usuario] ADD  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[test_HabilidadesXUsuario]  WITH CHECK ADD FOREIGN KEY([IdHabilidad])
REFERENCES [dbo].[test_CatalogoHabilidades] ([Id])
GO
ALTER TABLE [dbo].[test_HabilidadesXUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[test_Usuario] ([Id])
GO
ALTER TABLE [dbo].[test_TelefonosXUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[test_Usuario] ([Id])
GO
ALTER TABLE [dbo].[test_Usuario]  WITH CHECK ADD FOREIGN KEY([IdTipoIdentificacion])
REFERENCES [dbo].[test_TipoIdentificacion] ([Id])
GO
ALTER TABLE [dbo].[test_Usuario]  WITH CHECK ADD FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[test_TipoUsuario] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[test_ActualizarUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[test_ActualizarUsuario]
--declare
	@IdUsuario int = 1,
	@IdTipoIdentificacion int = 0,
	@NumeroIdentificacion varchar(100) = '',
	@Nombre varchar(500) = '',
	@PrimerApellido varchar(200) = '',
	@SegundoApellido varchar(200) = '',
	@Usuario varchar(100) = '',
	@Clave varchar(100) = '',
	@IdTipoUsuario int = 0,
	@Correo varchar(200) = '',
	@Telefonos varchar(max) = '',
	@Habilidades varchar(max) = ''
as
begin
	
	declare @telefonosTbl table(Telefono varchar(20))
	declare @habilidadesTbl table(IdHabilidad int)

	update top(1) u
	set IdTipoIdentificacion = @IdTipoIdentificacion,
		NumeroIdentificacion = @NumeroIdentificacion,
		Nombre = @Nombre,
		PrimerApellido = @PrimerApellido,
		SegundoApellido = @SegundoApellido,
		Usuario = @Usuario,
		Clave = @Clave,
		IdTipoUsuario = @IdTipoUsuario,
		Correo = @Correo,
		FechaActualizacion = GETDATE()
	--select *
	from test_Usuario u
	where Id = @IdUsuario

	insert into @telefonosTbl(Telefono)
	select Value
	from SplitString(@Telefonos, ',')

	insert into @habilidadesTbl(IdHabilidad)
	select CAST(Value as int)
	from SplitString(@Habilidades, ',')

	update tu
	set Estado = 0
	--select *
	from test_TelefonosXUsuario tu
	where tu.IdUsuario = @IdUsuario

	update tu
	set Estado = 1
	--select *
	from test_TelefonosXUsuario tu
	join @telefonosTbl t on t.Telefono = tu.Telefono
	where tu.IdUsuario = @IdUsuario

	insert into test_TelefonosXUsuario(IdUsuario, Telefono)
	select @IdUsuario, Telefono
	from @telefonosTbl
	except
	select @IdUsuario, Telefono
	from test_TelefonosXUsuario
	where IdUsuario = @IdUsuario




	update tu
	set Estado = 0
	--select *
	from test_HabilidadesXUsuario tu
	where tu.IdUsuario = @IdUsuario

	update tu
	set Estado = 1
	--select *
	from test_HabilidadesXUsuario tu
	join @habilidadesTbl t on t.IdHabilidad = tu.IdHabilidad
	where tu.IdUsuario = @IdUsuario

	insert into test_HabilidadesXUsuario(IdUsuario, IdHabilidad)
	select @IdUsuario, IdHabilidad
	from @habilidadesTbl
	except
	select @IdUsuario, IdHabilidad
	from test_HabilidadesXUsuario
	where IdUsuario = @IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[test_CrearUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[test_CrearUsuario]
	@IdTipoIdentificacion int,
	@NumeroIdentificacion varchar(100),
	@Nombre varchar(500),
	@PrimerApellido varchar(200),
	@SegundoApellido varchar(200),
	@Usuario varchar(100),
	@Clave varchar(100),
	@IdTipoUsuario int,
	@Correo varchar(200),
	@Telefonos varchar(max),
	@Habilidades varchar(max)
as
begin
	insert into test_Usuario(IdTipoIdentificacion, NumeroIdentificacion, Nombre, PrimerApellido, SegundoApellido, Usuario, Clave, IdTipoUsuario, Correo, Estado)
	values	(@IdTipoIdentificacion, @NumeroIdentificacion, @Nombre, @PrimerApellido, @SegundoApellido, @Usuario, @Clave, @IdTipoUsuario, @Correo, 1)

	declare @userId int = SCOPE_IDENTITY()

	insert into test_TelefonosXUsuario(IdUsuario, Telefono)
	select @userId, Value
	from SplitString(@Telefonos, ',')

	insert into test_HabilidadesXUsuario(IdUsuario, IdHabilidad)
	select @userId , CAST(Value as int)
	from SplitString(@Habilidades, ',')
end
GO
/****** Object:  StoredProcedure [dbo].[test_EliminarUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[test_EliminarUsuario]
	@IdUsuario int
as
begin
	
	update top(1) u
	set Estado = 0
	from test_Usuario u
	where Id = @IdUsuario
end

GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerDatosUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[test_ObtenerDatosUsuario]
	@idUsuario int
as
begin
	select u.*, tu.Detalle TipoUsuario
	from test_Usuario u
	join test_TipoUsuario tu on tu.Id = u.IdTipoUsuario
	where u.Estado = 1 and u.Id = @idUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerHabilidades]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[test_ObtenerHabilidades]
as
begin
	select *
	from test_CatalogoHabilidades
	where Estado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerHabilidadesXUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[test_ObtenerHabilidadesXUsuario]
	@idUsuario int
as
begin
	select IdHabilidad
	from test_HabilidadesXUsuario
	where IdUsuario = @idUsuario
	and Estado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerTelefonosXUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[test_ObtenerTelefonosXUsuario]
	@idUsuario int
as
begin
	select Telefono
	from test_TelefonosXUsuario
	where IdUsuario = @idUsuario
	and Estado = 1
end

GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerTiposIdentificacion]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[test_ObtenerTiposIdentificacion]
as
begin
	select 0 Id, '-- Seleccione --' Detalle, GETDATE() Fecha, 1 Estado
	union	
	select *
	from test_TipoIdentificacion
	where Estado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerTiposUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[test_ObtenerTiposUsuario]
as
begin
	select 0 Id, '-- Seleccione --' Detalle, GETDATE() Fecha, 1 Estado
	union	
	select *
	from test_TipoUsuario
	where Estado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[test_ObtenerUsuarios]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[test_ObtenerUsuarios]
as
begin
	select u.*, tu.Detalle TipoUsuario
	from test_Usuario u
	join test_TipoUsuario tu on tu.Id = u.IdTipoUsuario
	where u.Estado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[test_ValidarLoginUsuario]    Script Date: 5/21/2024 8:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[test_ValidarLoginUsuario]
	@usuario varchar(200),
	@clave varchar(200)
as
begin
	select *
	from test_Usuario u
	where Usuario = @usuario and Clave = @clave
	and Estado = 1
end
GO

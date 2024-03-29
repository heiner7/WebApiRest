USE [master]
GO
/****** Object:  Database [ApiRest]    Script Date: 14/3/2023 03:20:20 ******/
CREATE DATABASE [ApiRest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApiRest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ApiRest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApiRest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ApiRest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ApiRest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApiRest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApiRest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApiRest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApiRest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApiRest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApiRest] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApiRest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApiRest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApiRest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApiRest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApiRest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApiRest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApiRest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApiRest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApiRest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApiRest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApiRest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApiRest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApiRest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApiRest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApiRest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApiRest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApiRest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApiRest] SET RECOVERY FULL 
GO
ALTER DATABASE [ApiRest] SET  MULTI_USER 
GO
ALTER DATABASE [ApiRest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApiRest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApiRest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApiRest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApiRest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApiRest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ApiRest', N'ON'
GO
ALTER DATABASE [ApiRest] SET QUERY_STORE = OFF
GO
USE [ApiRest]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[StadiumId] [int] NOT NULL,
	[TeamId1] [int] NOT NULL,
	[TeamId2] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[LastName] [nvarchar](200) NULL,
	[Position] [nvarchar](100) NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Result] [varchar](7) NOT NULL,
	[EventId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stadium]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stadium](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Location] [varchar](255) NOT NULL,
	[Capacity] [int] NOT NULL,
	[YearBuilt] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 14/3/2023 03:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NULL,
	[Foundation] [int] NOT NULL,
	[City] [nvarchar](100) NULL,
	[Coach] [nvarchar](80) NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228152126_migracion reseteo', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228152612_migracion inicial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228155916_migracion 2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228160420_migracion 3', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228161112_migracion inical1', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228161336_migracion inical', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228162656_migracion v2', N'5.0.17')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ec37281d-e4eb-4cfb-8ec5-24f474c22b66', N'Heiner1', N'HEINER1', N'string3@gmail.com', N'STRING3@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELlz1ok0hpk4yOlSEgW+xX27u2TvsZEZqjC+XJ8H4jcSo1byfB0KdAbiwAu2WjLjIA==', N'TVNPNLPVJ37FSOUSTRP44DKJC2ZHBJOR', N'0ab2ae26-ea75-4e7c-85a7-f9cb2a8c1714', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [Date], [StadiumId], [TeamId1], [TeamId2]) VALUES (3, CAST(N'2023-03-18T00:00:00.000' AS DateTime), 2, 1, 2)
INSERT [dbo].[Events] ([Id], [Date], [StadiumId], [TeamId1], [TeamId2]) VALUES (5, CAST(N'2023-03-16T00:00:00.000' AS DateTime), 2, 3, 4)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (1, N'string', N'string18', N'string18', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (2, N'prueba2', N'string2', N'string2', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (3, N'Prueba3', N'string', N'string', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (10, N'string7', N'string', N'string', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (11, N'string3', N'string3', N'string3', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (12, N'Heiner', N'Alvarez', N'Delantero', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (17, N'string 3', N'string3', N'string', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (18, N'es3', N'es3', N'es3', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (20, N'string2', N'string2', N'string', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (30, N'tu', N'tu', N'tu', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (31, N'u', N'u', N'u', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (32, N'Ma', N'mu', N'bb', 1)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (49, N'prueba', N'q', N'q', 2)
INSERT [dbo].[Player] ([Id], [Name], [LastName], [Position], [TeamId]) VALUES (51, N'b', N'b', N'b', 3)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([Id], [Result], [EventId]) VALUES (1, N'2-1', 3)
SET IDENTITY_INSERT [dbo].[Results] OFF
GO
SET IDENTITY_INSERT [dbo].[Stadium] ON 

INSERT [dbo].[Stadium] ([Id], [Name], [Location], [Capacity], [YearBuilt]) VALUES (2, N'Santiago Bernabeu', N'Ver', 20000, 1995)
SET IDENTITY_INSERT [dbo].[Stadium] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [Name], [Foundation], [City], [Coach]) VALUES (1, N'Real Madrid', 1900, N'string4', N'string3')
INSERT [dbo].[Teams] ([Id], [Name], [Foundation], [City], [Coach]) VALUES (2, N'Barcelona', 1999, N'prueba', N'prueba')
INSERT [dbo].[Teams] ([Id], [Name], [Foundation], [City], [Coach]) VALUES (3, N'Masnchester United', 1997, N'prueba2', N'prueba2')
INSERT [dbo].[Teams] ([Id], [Name], [Foundation], [City], [Coach]) VALUES (4, N'Liverpool', 1997, N'prueba3', N'prueba3')
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 14/3/2023 03:20:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 14/3/2023 03:20:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 14/3/2023 03:20:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 14/3/2023 03:20:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 14/3/2023 03:20:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 14/3/2023 03:20:21 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 14/3/2023 03:20:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Player_TeamId]    Script Date: 14/3/2023 03:20:21 ******/
CREATE NONCLUSTERED INDEX [IX_Player_TeamId] ON [dbo].[Player]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD FOREIGN KEY([StadiumId])
REFERENCES [dbo].[Stadium] ([Id])
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD FOREIGN KEY([TeamId1])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD FOREIGN KEY([TeamId2])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Teams_TeamId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[obtenerEvents]    Script Date: 14/3/2023 03:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[obtenerEvents] 
	
AS
BEGIN
	SELECT Events.Id AS Id, teams1.Name AS TeamLocal, teams2.Name AS TeamVisit, Stadium.Name AS StadiumName, Events.Date AS Date
		FROM Events 
		INNER JOIN Stadium ON Events.StadiumId = Stadium.Id
		INNER JOIN Teams AS teams1 ON Events.TeamId1 = teams1.Id
		INNER JOIN Teams AS teams2 ON Events.TeamId2 = teams2.Id
		WHERE Events.Date > GETDATE()
END
GO
USE [master]
GO
ALTER DATABASE [ApiRest] SET  READ_WRITE 
GO

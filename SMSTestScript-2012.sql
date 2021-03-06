USE [master]
GO
/****** Object:  Database [SMSTest]    Script Date: 2/17/2018 1:00:50 PM ******/
CREATE DATABASE [SMSTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SMSTest', FILENAME = N'D:\Databases\Restored\SMSTest.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SMSTest_log', FILENAME = N'D:\Databases\Restored\SMSTest_log.ldf' , SIZE = 4736KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SMSTest] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SMSTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SMSTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SMSTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SMSTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SMSTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SMSTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [SMSTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SMSTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SMSTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SMSTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SMSTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SMSTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SMSTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SMSTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SMSTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SMSTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SMSTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SMSTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SMSTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SMSTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SMSTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SMSTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SMSTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SMSTest] SET RECOVERY FULL 
GO
ALTER DATABASE [SMSTest] SET  MULTI_USER 
GO
ALTER DATABASE [SMSTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SMSTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SMSTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SMSTest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SMSTest', N'ON'
GO
USE [SMSTest]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[isActive] [varchar](1) NULL,
	[BranchManager] [varchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeletedUserLevel]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeletedUserLevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserLevelID] [varchar](4) NULL,
	[UserTypeID] [varchar](3) NULL,
	[UserLevelName] [varchar](25) NULL,
	[InsertionDateTime] [varchar](14) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeletedUserType]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeletedUserType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [varchar](3) NULL,
	[UserTypeName] [varchar](25) NULL,
	[InsertionDateTime] [varchar](14) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Module]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [varchar](3) NULL,
	[ModuleName] [varchar](50) NULL,
	[isActive] [varchar](1) NULL,
	[LicenseA] [varchar](19) NULL,
	[LicenseB] [varchar](19) NULL,
	[ModuleController] [varchar](50) NULL,
	[ModuleAction] [varchar](100) NULL,
	[ModuleIcon] [varchar](250) NULL,
	[DisplayOrder] [varchar](3) NULL,
	[ModuleDescription] [varchar](100) NULL,
	[hasChild] [varchar](1) NULL,
	[ModuleIconClass] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ModuleFunction]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ModuleFunction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleFunctionID] [varchar](3) NULL,
	[ModuleFunctionName] [varchar](50) NULL,
	[ModuleID] [varchar](3) NULL,
	[isActive] [varchar](1) NULL,
	[ModuleFunctionController] [varchar](50) NULL,
	[ModuleFunctionAction] [varchar](100) NULL,
	[ModuleFunctionIcon] [varchar](250) NULL,
	[DisplayOrder] [varchar](3) NULL,
	[ModuleFunctionDescription] [varchar](100) NULL,
	[ModuleFunctionIconClass] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization_Configuration]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization_Configuration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Organization_Mnemonic] [varchar](10) NULL,
	[Oragnization_Main_Branch_ID] [int] NULL,
	[Production_Year] [varchar](4) NULL,
	[LicenseA] [varchar](19) NULL,
	[LicenseB] [varchar](19) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLevel]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserLevelID] [varchar](4) NULL,
	[UserTypeID] [varchar](3) NULL,
	[UserLevelName] [varchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](50) NULL,
	[UserLoginPassword] [varchar](100) NULL,
	[UserTypeID] [varchar](3) NULL,
	[UserLevelID] [varchar](4) NULL,
	[UserStatusID] [varchar](3) NULL,
	[LastLoginDateTime] [varchar](14) NULL,
	[LastLogoutDateTime] [varchar](14) NULL,
	[LastSessionTotalTime] [varchar](10) NULL,
	[isLoggedIn] [varchar](1) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserPermission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [varchar](3) NULL,
	[UserLevelID] [varchar](4) NULL,
	[ModuleID] [varchar](3) NULL,
	[ModuleFunctionID] [varchar](3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](50) NULL,
	[FirstName] [varchar](25) NULL,
	[MiddleName] [varchar](25) NULL,
	[LastName] [varchar](25) NULL,
	[FullName] [varchar](75) NULL,
	[Email] [varchar](75) NULL,
	[MobileNumber] [varchar](15) NULL,
	[AlternateMobileNumber] [varchar](15) NULL,
	[CNIC] [varchar](15) NULL,
	[HomeAddress] [varchar](250) NULL,
	[UserTypeID] [varchar](3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserStatusID] [varchar](3) NULL,
	[UserStatusName] [varchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [varchar](3) NULL,
	[UserTypeName] [varchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([id], [Name], [Address1], [Address2], [isActive], [BranchManager]) VALUES (1, N'Head Office', N'Address Location 1', N'Address 2', N'1', N'Test Manager Name')
SET IDENTITY_INSERT [dbo].[Branches] OFF
SET IDENTITY_INSERT [dbo].[DeletedUserLevel] ON 

INSERT [dbo].[DeletedUserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName], [InsertionDateTime]) VALUES (1, N'0004', N'002', N'Operator3', NULL)
INSERT [dbo].[DeletedUserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName], [InsertionDateTime]) VALUES (2, N'0005', N'002', N'Operator3', NULL)
INSERT [dbo].[DeletedUserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName], [InsertionDateTime]) VALUES (1002, N'0004', N'001', N'Operator1', NULL)
INSERT [dbo].[DeletedUserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName], [InsertionDateTime]) VALUES (1003, N'0000', N'005', N'Beginner', NULL)
SET IDENTITY_INSERT [dbo].[DeletedUserLevel] OFF
SET IDENTITY_INSERT [dbo].[DeletedUserType] ON 

INSERT [dbo].[DeletedUserType] ([id], [UserTypeID], [UserTypeName], [InsertionDateTime]) VALUES (1, N'008', N'Operator Test 2', NULL)
INSERT [dbo].[DeletedUserType] ([id], [UserTypeID], [UserTypeName], [InsertionDateTime]) VALUES (2, N'007', N'Operator Test', NULL)
SET IDENTITY_INSERT [dbo].[DeletedUserType] OFF
SET IDENTITY_INSERT [dbo].[Module] ON 

INSERT [dbo].[Module] ([id], [ModuleID], [ModuleName], [isActive], [LicenseA], [LicenseB], [ModuleController], [ModuleAction], [ModuleIcon], [DisplayOrder], [ModuleDescription], [hasChild], [ModuleIconClass]) VALUES (23, N'030', N'Stellar Vision', N'1', N'AAAA', N'BBBB', N'StellarVision', N'Index', N'~/img/MenuIcons/StellarVision.png', N'1', N'This is Stellar Vision', N'1', N'fa-home')
INSERT [dbo].[Module] ([id], [ModuleID], [ModuleName], [isActive], [LicenseA], [LicenseB], [ModuleController], [ModuleAction], [ModuleIcon], [DisplayOrder], [ModuleDescription], [hasChild], [ModuleIconClass]) VALUES (2, N'002', N'User Management', N'1', N'AAAAAA', N'BBBBBB', N'UserManagement', N'Index', N'~/img/MenuIcons/UserManagement.png', N'2', N'Manage User Details and their Roles', N'1', N'fa-users')
INSERT [dbo].[Module] ([id], [ModuleID], [ModuleName], [isActive], [LicenseA], [LicenseB], [ModuleController], [ModuleAction], [ModuleIcon], [DisplayOrder], [ModuleDescription], [hasChild], [ModuleIconClass]) VALUES (3, N'000', N'Home', N'1', N'AAAAAA', N'BBBBBB', N'Home', N'Index', N'~/img/MenuIcons/Home.png', N'0', N'Welcome to Stellar Vision', N'0', N'fa-home')
SET IDENTITY_INSERT [dbo].[Module] OFF
SET IDENTITY_INSERT [dbo].[ModuleFunction] ON 

INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (41, N'001', N'Stellar Vision Home', N'030', N'1', N'StellarVision', N'Home', N'~/img/MenuIcons/StellarVisionHome.png', N'1', N'This is Stellar Vision Home', N'fa-home')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (4, N'001', N'Add User', N'002', N'1', N'UserManagement', N'AddUser', N'~/img/MenuIcons/AddUser.png', N'1', NULL, N'fa-plus')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (5, N'002', N'Modify User', N'002', N'0', N'UserManagement', N'ModifyUser', N'~/img/MenuIcons/ModifyUser.png', N'2', NULL, N'fa-edit')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (6, N'003', N'View Users', N'002', N'1', N'UserManagement', N'ViewUsers', N'~/img/MenuIcons/ViewUsers.png', N'3', NULL, N'fa-eye')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (7, N'004', N'Add User Type', N'002', N'1', N'UserManagement', N'AddUserType', N'~/img/MenuIcons/AddUserType.png', N'4', NULL, N'fa-plus')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (37, N'005', N'View User Type', N'002', N'1', N'UserManagement', N'ViewUserType', N'~/img/MenuIcons/ViewUserType.png', N'5', NULL, N'fa-eye')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (38, N'006', N'Add User Level', N'002', N'1', N'UserManagement', N'AddUserLevel', N'~/img/MenuIcons/AddUserLevel.png', N'6', NULL, N'fa-plus')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (39, N'007', N'View User Level', N'002', N'1', N'UserManagement', N'ViewUserLevel', N'~/img/MenuIcons/ViewUserLevel.png', N'7', NULL, N'fa-eye')
INSERT [dbo].[ModuleFunction] ([id], [ModuleFunctionID], [ModuleFunctionName], [ModuleID], [isActive], [ModuleFunctionController], [ModuleFunctionAction], [ModuleFunctionIcon], [DisplayOrder], [ModuleFunctionDescription], [ModuleFunctionIconClass]) VALUES (40, N'008', N'Set Permissions', N'002', N'1', N'UserManagement', N'SetPermissions', N'~/img/MenuIcons/SetPermissions.png', N'8', NULL, N'fa-pencil-square-o')
SET IDENTITY_INSERT [dbo].[ModuleFunction] OFF
SET IDENTITY_INSERT [dbo].[Organization_Configuration] ON 

INSERT [dbo].[Organization_Configuration] ([id], [Name], [Organization_Mnemonic], [Oragnization_Main_Branch_ID], [Production_Year], [LicenseA], [LicenseB]) VALUES (1, N'Stellar Vision', N'SV00000000', 1, N'2018', N'B508-F0C4-ABEF-7F8E', N'1598-1FF7-1345-EA26')
SET IDENTITY_INSERT [dbo].[Organization_Configuration] OFF
SET IDENTITY_INSERT [dbo].[UserLevel] ON 

INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (1, N'0001', N'001', N'Normal')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (2, N'0001', N'002', N'Normal')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (3, N'0001', N'003', N'Normal')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (4, N'0001', N'004', N'Normal')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (6, N'0002', N'001', N'Beginner')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (1005, N'0002', N'002', N'Beginner')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (3009, N'0003', N'001', N'Operator')
INSERT [dbo].[UserLevel] ([id], [UserLevelID], [UserTypeID], [UserLevelName]) VALUES (3010, N'0003', N'002', N'Operator')
SET IDENTITY_INSERT [dbo].[UserLevel] OFF
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

INSERT [dbo].[UserLogin] ([id], [UserID], [UserLoginPassword], [UserTypeID], [UserLevelID], [UserStatusID], [LastLoginDateTime], [LastLogoutDateTime], [LastSessionTotalTime], [isLoggedIn]) VALUES (1, N'Admin', N'qdZLopyBhXxTz11ewBKcKA==', N'001', N'0001', N'001', N'', N'', N'', N'0')
INSERT [dbo].[UserLogin] ([id], [UserID], [UserLoginPassword], [UserTypeID], [UserLevelID], [UserStatusID], [LastLoginDateTime], [LastLogoutDateTime], [LastSessionTotalTime], [isLoggedIn]) VALUES (2, N'fawad', N'qdZLopyBhXxTz11ewBKcKA==', N'001', N'0001', N'001', N'', N'', N'', N'0')
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
SET IDENTITY_INSERT [dbo].[UserPermission] ON 

INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1, N'001', N'0001', N'000', N'')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (2, N'001', N'0001', N'001', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (3, N'001', N'0001', N'001', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (4, N'001', N'0001', N'001', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (5, N'001', N'0001', N'002', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (6, N'001', N'0001', N'002', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (7, N'001', N'0001', N'002', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (8, N'001', N'0001', N'002', N'004')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (9, N'002', N'0001', N'000', N'')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (10, N'002', N'0001', N'001', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (11, N'002', N'0001', N'001', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (12, N'002', N'0001', N'001', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (13, N'002', N'0001', N'002', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (14, N'002', N'0001', N'002', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (15, N'002', N'0001', N'002', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (16, N'002', N'0001', N'002', N'004')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (17, N'003', N'0001', N'000', N'')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (18, N'003', N'0001', N'001', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (19, N'003', N'0001', N'001', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (20, N'003', N'0001', N'001', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (21, N'003', N'0001', N'002', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (22, N'003', N'0001', N'002', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (23, N'003', N'0001', N'002', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (24, N'003', N'0001', N'002', N'004')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (25, N'004', N'0001', N'000', N'')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (26, N'004', N'0001', N'001', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (27, N'004', N'0001', N'001', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (28, N'004', N'0001', N'001', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (29, N'004', N'0001', N'002', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (30, N'004', N'0001', N'002', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (31, N'004', N'0001', N'002', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (32, N'004', N'0001', N'002', N'004')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (33, N'001', N'0001', N'003', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (34, N'001', N'0001', N'003', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (35, N'001', N'0001', N'004', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (36, N'001', N'0001', N'005', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (37, N'001', N'0001', N'006', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (38, N'001', N'0001', N'007', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (39, N'001', N'0001', N'008', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (40, N'001', N'0001', N'008', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (41, N'001', N'0001', N'009', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (42, N'001', N'0001', N'010', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (43, N'001', N'0001', N'011', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (44, N'001', N'0001', N'012', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (45, N'001', N'0001', N'012', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (46, N'001', N'0001', N'013', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (47, N'001', N'0001', N'013', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (48, N'001', N'0001', N'014', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (49, N'001', N'0001', N'014', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (50, N'001', N'0001', N'015', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (51, N'001', N'0001', N'016', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (52, N'001', N'0001', N'016', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (53, N'001', N'0001', N'016', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (54, N'001', N'0001', N'017', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (55, N'001', N'0001', N'018', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (56, N'001', N'0001', N'018', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (57, N'001', N'0001', N'019', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (58, N'001', N'0001', N'019', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (59, N'001', N'0001', N'020', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (60, N'001', N'0001', N'021', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (61, N'001', N'0001', N'021', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (62, N'001', N'0001', N'002', N'005')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (63, N'001', N'0001', N'002', N'006')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (64, N'001', N'0001', N'002', N'007')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (65, N'001', N'0001', N'002', N'008')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1062, N'001', N'0003', N'000', N'')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1063, N'001', N'0003', N'001', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1064, N'001', N'0003', N'001', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1065, N'001', N'0003', N'001', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1066, N'001', N'0003', N'010', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1067, N'001', N'0003', N'011', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1068, N'001', N'0003', N'012', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1069, N'001', N'0003', N'012', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1070, N'001', N'0003', N'013', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1071, N'001', N'0003', N'013', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1072, N'001', N'0003', N'014', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1073, N'001', N'0003', N'014', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1074, N'001', N'0003', N'015', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1075, N'001', N'0003', N'016', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1076, N'001', N'0003', N'016', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1077, N'001', N'0003', N'016', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1078, N'001', N'0003', N'017', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1079, N'001', N'0003', N'018', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1080, N'001', N'0003', N'018', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1081, N'001', N'0003', N'019', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1082, N'001', N'0003', N'019', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1083, N'001', N'0003', N'002', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1084, N'001', N'0003', N'002', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1085, N'001', N'0003', N'002', N'003')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1086, N'001', N'0003', N'002', N'004')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1087, N'001', N'0003', N'002', N'005')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1088, N'001', N'0003', N'002', N'006')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1089, N'001', N'0003', N'002', N'007')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1090, N'001', N'0003', N'002', N'008')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1091, N'001', N'0003', N'020', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1092, N'001', N'0003', N'021', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1093, N'001', N'0003', N'021', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1094, N'001', N'0003', N'003', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1095, N'001', N'0003', N'003', N'002')
GO
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1096, N'001', N'0003', N'004', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1097, N'001', N'0003', N'005', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1098, N'001', N'0003', N'006', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1099, N'001', N'0003', N'007', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1100, N'001', N'0003', N'008', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1101, N'001', N'0003', N'008', N'002')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1102, N'001', N'0003', N'009', N'001')
INSERT [dbo].[UserPermission] ([id], [UserTypeID], [UserLevelID], [ModuleID], [ModuleFunctionID]) VALUES (1103, N'001', N'0001', N'030', N'001')
SET IDENTITY_INSERT [dbo].[UserPermission] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([id], [UserID], [FirstName], [MiddleName], [LastName], [FullName], [Email], [MobileNumber], [AlternateMobileNumber], [CNIC], [HomeAddress], [UserTypeID]) VALUES (1, N'Admin', N'Administrator', N'', N'', N'Administrator', N'admin@ptsslive.com', N'03001234657', N'03001234567', N'12345-1234567-1', N'Address1 Address2', N'001')
INSERT [dbo].[UserProfile] ([id], [UserID], [FirstName], [MiddleName], [LastName], [FullName], [Email], [MobileNumber], [AlternateMobileNumber], [CNIC], [HomeAddress], [UserTypeID]) VALUES (2, N'fawad', N'Fawad', N' A', N' Khan', N'Fawad A Khan', N'fawad@email.com', N'03001234567', N'03001234576', N'12345-1234567-1', N'This is home address...', N'001')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
SET IDENTITY_INSERT [dbo].[UserStatus] ON 

INSERT [dbo].[UserStatus] ([id], [UserStatusID], [UserStatusName]) VALUES (1, N'001', N'Active')
INSERT [dbo].[UserStatus] ([id], [UserStatusID], [UserStatusName]) VALUES (2, N'002', N'Suspended')
INSERT [dbo].[UserStatus] ([id], [UserStatusID], [UserStatusName]) VALUES (3, N'003', N'Deleted')
SET IDENTITY_INSERT [dbo].[UserStatus] OFF
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([id], [UserTypeID], [UserTypeName]) VALUES (1, N'001', N'Administrator')
INSERT [dbo].[UserType] ([id], [UserTypeID], [UserTypeName]) VALUES (2, N'002', N'Faculty')
INSERT [dbo].[UserType] ([id], [UserTypeID], [UserTypeName]) VALUES (3, N'003', N'Student')
INSERT [dbo].[UserType] ([id], [UserTypeID], [UserTypeName]) VALUES (4, N'004', N'Parent')
INSERT [dbo].[UserType] ([id], [UserTypeID], [UserTypeName]) VALUES (1005, N'006', N'Operator')
INSERT [dbo].[UserType] ([id], [UserTypeID], [UserTypeName]) VALUES (11, N'005', N'Manager')
SET IDENTITY_INSERT [dbo].[UserType] OFF
/****** Object:  StoredProcedure [dbo].[AddUserLevel]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AddUserLevel]
@UserTypeID as varchar(3),
@UserLevelName as varchar(25)
AS
Declare @UserLevelID as varchar(4)
select @UserLevelID = Max(UserLevelID) + 1 from UserLevel
	where
UserTypeID = @UserTypeID
set @UserLevelID = Right('0000'+ISNULL(@UserLevelID,''), 4)
Insert into UserLevel (UserLevelID, UserTypeID, UserLevelName) values (@UserLevelID, @UserTypeID, @UserLevelName)

GO
/****** Object:  StoredProcedure [dbo].[AddUserLoginAndUserProfile]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AddUserLoginAndUserProfile]
@UserID as varchar(50),
@UserLoginPassword varchar(100),
@UserTypeID varchar(3),
@UserLevelID varchar(4),
@UserStatusID varchar(3),
@FirstName varchar(25),
@MiddleName varchar(25),
@LastName varchar(25),
@Email varchar(75),
@MobileNumber varchar(15),
@AlternateMobileNumber varchar(15),
@CNIC varchar(15),
@HomeAddress varchar(250)
As
Insert into UserLogin
(
	UserID,
	UserLoginPassword,
	UserTypeID,
	UserLevelID,
	UserStatusID,
	LastLoginDateTime,
	LastLogoutDateTime,
	LastSessionTotalTime,
	isLoggedIn
)
values
(
	@UserID,
	@UserLoginPassword,
	@UserTypeID,
	@UserLevelID,
	@UserStatusID,
	'',
	'',
	'',
	'0'
)

Declare @FullName as varchar(75)

set @FullName = @FirstName + ISNULL(@MiddleName, '') + ISNULL(@LastName, '')

Insert into UserProfile
(
	UserID,
	FirstName,
	MiddleName,
	LastName,
	FullName,
	Email,
	MobileNumber,
	AlternateMobileNumber,
	CNIC,
	HomeAddress,
	UserTypeID
)
values
(
	@UserID,
	@FirstName,
	@MiddleName,
	@LastName,
	@FullName,
	@Email,
	@MobileNumber,
	@AlternateMobileNumber,
	@CNIC,
	@HomeAddress,
	@UserTypeID
)

GO
/****** Object:  StoredProcedure [dbo].[AddUserType]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddUserType]
@UserTypeName as varchar(25)
AS
Declare @UserTypeID as varchar(3)
select @UserTypeID = Max(UserTypeID) + 1 from UserType
set @UserTypeID = Right('000'+ISNULL(@UserTypeID,''), 3)
Insert into UserType (UserTypeID, UserTypeName) values (@UserTypeID, @UserTypeName)

GO
/****** Object:  StoredProcedure [dbo].[deleteUserLevel]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[deleteUserLevel]
@UserTypeID as varchar(3),
@UserLevelName as varchar(25)
As
Delete from UserLevel
	where 
	UserTypeID = @UserTypeID
and UserLevelName = @UserLevelName

GO
/****** Object:  StoredProcedure [dbo].[deleteUserType]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[deleteUserType]
@UserTypeName as varchar(25)
As
Delete from UserType
	where 
UserTypeName = @UserTypeName

GO
/****** Object:  StoredProcedure [dbo].[editUserLevel]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[editUserLevel]
@UserLevelName as varchar(25),
@UserTypeID as varchar(3),
@NewUserLevelName as varchar(25)
As
Update UserLevel
	set
		UserLevelName = @NewUserLevelName
	where
		UserLevelName = @UserLevelName
	and UserTypeID = @UserTypeID

GO
/****** Object:  StoredProcedure [dbo].[editUserType]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[editUserType]
@UserTypeName as varchar(25),
@NewUserTypeName as varchar(25)
As
Update UserType 
	set 
		UserTypeName = @NewUserTypeName
	where 
		UserTypeName = @UserTypeName

GO
/****** Object:  StoredProcedure [dbo].[getAllModuleFunctions]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[getAllModuleFunctions]
As
Select * from ModuleFunction order by ModuleID, DisplayOrder

GO
/****** Object:  StoredProcedure [dbo].[getAllModules]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[getAllModules]
As
Select * from Module order by DisplayOrder

GO
/****** Object:  StoredProcedure [dbo].[getAllUserLevels]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[getAllUserLevels]
As
Select * from UserLevel


GO
/****** Object:  StoredProcedure [dbo].[getAllUserLevelsByUserTypeID]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[getAllUserLevelsByUserTypeID]
@UserTypeID as varchar(3)
As
Select * from UserLevel
where
UserTypeID = @UserTypeID


GO
/****** Object:  StoredProcedure [dbo].[GetAllUserStatus]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAllUserStatus]
As
Select * from UserStatus

GO
/****** Object:  StoredProcedure [dbo].[getAllUserTypes]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[getAllUserTypes]
As
Select * from UserType


GO
/****** Object:  StoredProcedure [dbo].[getModule]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[getModule]
@ModuleID varchar(3)
As
Select * from Module
where
ModuleID = @ModuleID

GO
/****** Object:  StoredProcedure [dbo].[getModuleFunction]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[getModuleFunction]
@ModuleID varchar(3),
@ModuleFunctionID varchar(3)
As
Select * from ModuleFunction
where
	ModuleID = @ModuleID
and	ModuleFunctionID = @ModuleFunctionID
Order By
	ModuleID, ModuleFunctionID

GO
/****** Object:  StoredProcedure [dbo].[getModuleFunctions]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[getModuleFunctions]
@ModuleID varchar(3)
As
Select * from ModuleFunction
where
ModuleID = @ModuleID
Order by
DisplayOrder

GO
/****** Object:  StoredProcedure [dbo].[getUserLevelByUserTypeIDAndUserLevelName]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[getUserLevelByUserTypeIDAndUserLevelName]
@UserTypeID as varchar(3),
@UserLevelName as varchar(25)
As
Select * from UserLevel
	where
	UserTypeID = @UserTypeID
and	UserLevelName = @UserLevelName 

GO
/****** Object:  StoredProcedure [dbo].[getUserLevelDescription]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUserLevelDescription]
@UserTypeID as varchar(3),
@UserLevelID as varchar(4)
As
Select * from UserLevel
	where
	UserTypeID = @UserTypeID
and UserLevelID = @UserLevelID

GO
/****** Object:  StoredProcedure [dbo].[getUserLoginDetails]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUserLoginDetails]
@UserID as varchar(50)
As
Select * from UserLogin
	where
UserID = @UserID

GO
/****** Object:  StoredProcedure [dbo].[getUserPermissionByUserTypeAndUserLevel]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[getUserPermissionByUserTypeAndUserLevel]
@UserTypeID as varchar(3),
@UserLevelID as varchar(4)
As
Select * from UserPermission p
	Left Join
		ModuleFunction MF on 
		P.ModuleFunctionID = MF.ModuleFunctionID
	and P.ModuleID = MF.ModuleID
	Left Join
		Module M on P.ModuleID = M.ModuleID
where
	(
		P.UserTypeID = @UserTypeID
	and	P.UserLevelID = @UserLevelID
	and MF.isActive = '1'
	and M.isActive = '1'
	)
	or
	(
		P.ModuleID in 
		(
			select ModuleID from Module where ModuleID not in 
			(
				select ModuleID from ModuleFunction
			) 
		)
	and	P.UserTypeID = @UserTypeID
	and P.UserLevelID = @UserLevelID
	and M.isActive = '1'
	)
Order by P.ModuleID, P.ModuleFunctionID


GO
/****** Object:  StoredProcedure [dbo].[getUserProfile]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUserProfile]
@UserID as varchar(50)
As
Select * from UserProfile
	where
UserID = @UserID

GO
/****** Object:  StoredProcedure [dbo].[getUserStatusDescription]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getUserStatusDescription]
@UserStatusID as varchar(3)
As
Select * from UserStatus
	where
UserStatusID = @UserStatusID

GO
/****** Object:  StoredProcedure [dbo].[getUserTypeByUserTypeName]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[getUserTypeByUserTypeName]
@UserTypeName as varchar(25)
As
Select * from UserType
	where
UserTypeName = @UserTypeName

GO
/****** Object:  StoredProcedure [dbo].[getUserTypeDescription]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getUserTypeDescription]
@UserTypeID as varchar(3)
As
Select * from UserType
	where
UserTypeID = @UserTypeID

GO
/****** Object:  StoredProcedure [dbo].[RemovePermissions]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RemovePermissions]
@UserTypeID as varchar(3),
@UserLevelID as varchar(4)
As
Delete from UserPermission
where
UserTypeID = @UserTypeID and 
UserLevelID = @UserLevelID

GO
/****** Object:  StoredProcedure [dbo].[SearchUsersByFilter]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SearchUsersByFilter]
@UserID as varchar(50),
@UserTypeID as varchar(3),
@UserLevelID as varchar(4),
@UserStatusID as varchar(3)
As
Declare @SelectStatement as varchar(500)
Declare @FilterUserID as varchar(75)
Declare @FilterUserTypeID as varchar(30)
Declare @FilterUserLevelID as varchar(30)
Declare @FilterUserStatusID as varchar(30)

if @UserID = '-1'
	set @FilterUserID = ''
else
	set @FilterUserID = ' and UL.UserID = ''' + @UserID + ''''

if @UserTypeID = '-1'
	set @FilterUserTypeID = ''
else
	set @FilterUserTypeID = ' and UL.UserTypeID = ''' + @UserTypeID + ''''

if @UserLevelID = '-1'
	set @FilterUserLevelID = ''
else
	set @FilterUserLevelID = ' and UL.UserLevelID = ''' + @UserLevelID + ''''

if @UserStatusID = '-1'
	set @FilterUserStatusID = ''
else
	set @FilterUserStatusID = ' and UL.UserStatusID = ''' + @UserStatusID + ''''

Set @SelectStatement = 'Select * from UserProfile UP 
	Join UserLogin UL on UP.UserID = UL.UserID
where
	1 = 1'
	+ @FilterUserID
	+ @FilterUserTypeID
	+ @FilterUserLevelID
	+ @FilterUserStatusID

Print(@SelectStatement)
Exec(@SelectStatement)

GO
/****** Object:  StoredProcedure [dbo].[SetPermissions]    Script Date: 2/17/2018 1:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SetPermissions]
@UserTypeID as varchar(3),
@UserLevelID as varchar(4),
@ModuleID as varchar(3),
@ModuleFunctionID as varchar(3)
As
Insert into UserPermission
(
	UserTypeID,
	UserLevelID,
	ModuleID,
	ModuleFunctionID
)
values
(
	@UserTypeID,
	@UserLevelID,
	@ModuleID,
	@ModuleFunctionID
)

GO
USE [master]
GO
ALTER DATABASE [SMSTest] SET  READ_WRITE 
GO

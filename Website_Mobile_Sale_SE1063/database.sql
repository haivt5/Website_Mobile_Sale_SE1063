USE [master]
GO
/****** Object:  Database [Mobile Web App]    Script Date: 14/03/2017 07:53:18 ******/
CREATE DATABASE [Mobile Web App]
GO
ALTER DATABASE [Mobile Web App] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mobile Web App].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mobile Web App] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mobile Web App] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mobile Web App] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mobile Web App] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mobile Web App] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mobile Web App] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mobile Web App] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mobile Web App] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mobile Web App] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mobile Web App] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mobile Web App] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mobile Web App] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mobile Web App] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mobile Web App] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mobile Web App] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mobile Web App] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mobile Web App] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mobile Web App] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mobile Web App] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mobile Web App] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mobile Web App] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mobile Web App] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mobile Web App] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mobile Web App] SET  MULTI_USER 
GO
ALTER DATABASE [Mobile Web App] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mobile Web App] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mobile Web App] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mobile Web App] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Mobile Web App] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Mobile Web App]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountInfo]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NULL,
	[PhoneId] [int] NULL,
	[Quantity] [int] NULL,
	[Total] [money] NULL,
 CONSTRAINT [PK_CartDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Color]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[PhoneId] [int] NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phone]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Capacity] [real] NOT NULL,
	[ScreenResolution] [nchar](10) NULL,
	[RAM] [int] NULL,
	[Platform] [nchar](10) NULL,
	[Quantity] [int] NOT NULL,
	[Image] [varchar](250) NULL,
	[Price] [money] NOT NULL,
	[Description] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 14/03/2017 07:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [nvarchar](128) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Total] [money] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Shopping Card] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201702170431280_InitialCreate', N'Website_Mobile_Sale_SE1063.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE4B8117D0F907F10F49404DE962F99C1C4E8DE85B76D2746C6174C7B367933D812BB4D8C446925CA6B63B15F96877C527E214589524BBCE8D2ADBE7861C0B0C8E2A962B148168B45FFEF3FFF1DFFF01AF8D60B8E1312D2897D323AB62D4CDDD0237439B153B6F8EE93FDC3F77FFCC3F8CA0B5EAD9F0ABA334E072D6932B19F198BCE1D27719F7180925140DC384CC2051BB961E0202F744E8F8FFFE69C9C3818206CC0B2ACF197943212E0EC033EA7217571C452E4DF861EF613510E35B30CD5BA43014E22E4E289FD2F3C4F08C34FB7E19CF8F86986F8AFAB93E38F67A3BCB16D5DF804816033EC2F6C0B511A32C440ECF3AF099EB138A4CB590405C87F7C8B30D02D909F60D19DF31579D79E1D9FF29E39AB8605949B262C0C7A029E9C09553972F3B5146E97AA04655E81D2D91BEF75A6D0897DE3E1ACE84BE883026486E7533FE6C413FBB66471914477988D8A86A31CF23A06B85FC2F8DBA88A7864756E77549AD6E9E898FF1C59D3D467698C2714A72C46FE91F590CE7DE2FE13BF3D86DF309D9C9DCC17679F3E7C44DED9C7BFE2B30FD59E425F81AE5600450F7118E11864C38BB2FFB6E5D4DB3972C3B259A54DAE15B0259825B6758B5E3F63BA64CF307F4E3FD9D63579C55E51228CEB2B2530A9A0118B53F8BC4B7D1FCD7D5CD63B8D3CF9EF06AEA71F3E0EC2F50EBD906536F4127F983831CCAB2FD8CF6A936712E5D3AB36DE4F82EC3A0E03FE5DB7AFBCF66916A6B1CB3B131A491E51BCC4AC2EDDD859196F2793E650C39B75817AF8A6CD2555CD5B4BCA3BB4CE4C2858EC7A3614F26E976F678BBB882218BCCCB4B8469A0CAE75EF1A49604796B9C9CAB04EBA1A16850EFF9ED7C9AB00117F8085B20317705916240E70D9CB1F43304B447BCBFC809204D609EF1F28796E101DFE1C40F41976D318CC77C650106D9DDBC37348F15D1ACCF9ACD81DAFC186E6F197F01AB92C8CAF286FB531DEE7D0FD16A6EC8A7A9788E1AFCC2D00F9E72309BA030C22CE85EBE224B90663C6DE34048FBC00BCA1ECECB4371C5FAFF6EDA84C7D4402BDA722ADAC4F05E9CA5BD153281E8B814CE7B53489FA395C12DA4DD482D42C6A4ED12AAA20EB2B2A07EB26A9A0340B9A11B4CA99530DE607662334BC2398C11EBE27B8D9E66D5A0B2A6A9CC10A89FF8E298E6119F31E106338A6AB11E8B26EECC359C8868F33DDFADE9471FA09F9E9D0ACD69A0DD92230FC6CC8600F7F36646242F10BF1B857D2E1785410037C277AFDC9AB7DCE4992ED7A3AD4BAB96BE6BB59034CD3E52249429764B340131813618DBAFCE0C359ED318EBC37729C043A06864EF8960725D0375B36AA7B7A897DCCB075E1E681C3294A5CE4A96A840E793D042B76548D60AB78495DB8BF283CC1D271CC1B217E084A60A612CAD46941A84B22E4B76A496AD9710BE37D2F79C8359738C294336CD54417E6FAF00817A0E4230D4A9B86C64EC5E29A0DD1E0B59AC6BCCD855D8DBB12B5D8894DB6F8CE06BB14FEDB560CB359633B30CE66957411C018EADB87818AB34A5703900F2E8766A0D289C960A0C2A5DA8981D635B60703ADABE4DD19687E44ED3AFED279F5D0CCB37E50DEFDB6DEA8AE3DD8664D1F07669AB9EF096D18B4C0B16A9E97735E895F99E67006728AF359225C5DD94438F80CB37AC866E5EF6AFD50A7194436A226C095A1B5808A4B42054899503D842B62798DD2092FA2076C11776B84156BBF045BB10115BB7A595A21345FA9CAC6D9E9F451F6ACB406C5C83B1D162A381A839017AF7AC73B28C514975515D3C517EEE30D573A2606A341412D9EAB4149456706D752619AED5AD239647D5CB28DB424B94F062D159D195C4BC246DB95A4710A7AB8051BA9A8BE850F34D98A4847B9DB947563274FA9120563C7907B35BE455144E8B2928B254AAC599E8835FD6ED63F2529C8311C37D1642695D2969C5818A325966A8135487A4DE2845D2286E688C779A65EA09069F756C3F25FB0AC6E9FEA2016FB4041CDFFCE5BB45FEDD7B65ED5371190D7D0E1803B3859545D630EFAE6164F95433E8A3581FC69E8A70135FB5BE6D6F9755EB57D5EA2228C1D497EC59F5294A778BDF591E8344EEA1CD9CE9895DECDFAE366863069BFF04DABFA37F9AB6694227C55453185B4F6368E26376793B1931DCAFE43D78AB09D5927B258AA00A2A8274625114201ABD47547ADE7AA5431EB35DD11A584942AA454D543CA6ADA494DC86AC55A78068DEA29BA7350134DAAE86A6D77644DCA49155A53BD06B64666B9AE3BAA262BA50AACA9EE8EBD4A5191D7D403DED78CC79CA136B6FC60BCD9CE66C0D8CE0239CCC658B9FFAF02558A7B62891B7E054C941FA471194F874319571E1ED9CCB80C18E675A976915E5F961A6FFFCD98B5DBF1DAD2DF941D60C6EB67C25B3514E5AC289394DCCB33A374361C8B735AFBE31DE5E09693D856A146D8F6DF128683112718CD7EF6A73EC17C912F086E11250B9CB03C23C43E3D3E39951EFC1CCEE31B27493C5F73CE35BDC0A98FD90E92BBE80B8ADD6714ABA9161B3C5059812A51EC1BEAE1D789FD6BD6EA3C0B88F0BFB2E223EB26F94AC9CF29543CC629B67E5353478749D86F3E911DE8F38AEE5ABDF9F753DEF4C8BA8F61C69C5BC7922ED719E1FAA38B5ED2E44D379066EDA718EF7742D55E326851A509B1FEC3853961833C5A28A4FC53805EFFDC5734EDC3848D10358F0F86C21B4485A6C705EB60191F1678F0C9B28705FD3AAB7F68B08E68C6470684F607939F18745F868A967BDC6A3447A45D2C49999E5B53B437CAD7DCF7DEA464726F34D1D56CED1E701B6464AF6119EF2C9979B0DD5193AB3C18F63E4D7BEB09CA879293BCCA16D96F2AF22EB38F1BEE907E5749C7079026A749FBD97F6AF1AE6DCD14D63DF0FCCC7E09C407666C22196CFF69C2BB36365398F7C08DAD5732F081D9DABEF6CF3D5B5AE72D74EFA9BD6A9692E17A46170B6E4BDDCD03E770C29F876004B94799BFB8D4E78A35E5B9B6305C9198999A93D464C6CAC451F82A14CD6CFBF5556CF88D9D1534CD6C0DA99D4DBCC5FADFC85BD034F336244CEE23E9589BB2A84B046F59C79A32A6DE539271AD272D39ED6D3E6BE35DFB7BCA291E4429B5D963B8237E3F29C483A864C8A9D3236558BDEE85BDB3F21F1D61FF4EC87205C1FFBF23C56E6DD72C696EE8222C366F49A282448AD0DC62863CD8522F624616C86550CD63CCD993F12C6EC76F3AE6D8BBA1F7298B52065DC6C1DCAF05BCB813D0C43FCB8BAECB3CBE8FB2FF7E324417404CC263F3F7F4C794F85E29F7B526266480E0DE8588E8F2B1643CB2BB7C2B91EE42DA1148A8AF748A1E7110F90096DCD3197AC1EBC806E6F7192F91FBB68A009A40DA07A2AEF6F12541CB180589C058B5874FB0612F78FDFEFFCF65EC4CD8540000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[AccountInfo] ON 

INSERT [dbo].[AccountInfo] ([Id], [Name], [Address], [UserId]) VALUES (1, N'', N'', N'd53af359-80ad-4aa1-9125-f122f584764f')
SET IDENTITY_INSERT [dbo].[AccountInfo] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'admin')
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'115238452023394388933', N'617f33af-5e92-42e7-b335-be53100d82ed')
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Facebook', N'1263417340439898', N'b6fb171e-e449-4adb-b58d-1911de52fc7c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'617f33af-5e92-42e7-b335-be53100d82ed', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eafbd39c-a5ad-4b00-94b3-dba96bfdbe05', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'617f33af-5e92-42e7-b335-be53100d82ed', N'duckhangtuong@gmail.com', 0, NULL, N'e3a75c61-0b8c-42d7-9d24-011f72ccc362', N'0123456789', 0, 0, NULL, 1, 0, N'duckhangtuong@gmail.com', N'Khang', N'Công viên phần mềm Quang Trung')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'91f8d5ab-a0c7-4e0f-bb73-e7ab78612d9e', N'abc@abc.com', 0, N'ADu8yMXhsWfUy/1liyrjvndLSOAE37O5IB1M32MFQOpW2ebCNrFyZjaIBgrIau4aGQ==', N'92f0b61d-8339-4dff-bcc7-5991673a9f65', NULL, 0, 0, NULL, 1, 0, N'abc@abc.com', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'ab9ab3f0-51cd-4937-b17a-f661eacec4a7', N'abcde@abc.com', 0, N'AGjWqKqMQhZPg7qNIcEOUTplPp8kC6pj2UInW2Ug0+WCzCaObfisVoLp8iDAiqNclQ==', N'75a8af99-3919-459d-bece-e5cef16fd6a2', NULL, 0, 0, NULL, 1, 0, N'abcde@abc.com', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'Anonymous', N'abcd@abc.com', 0, N'AN8X4/Al8bqC5LBeHC5Fr3TVMPaKvFPKHTQmiK2TPTM5nES75aTbByIYN/dy4vWbJQ==', N'3a829395-7c89-474f-9684-29b7812fbe65', NULL, 0, 0, NULL, 1, 0, N'abcd@abc.com', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'b6fb171e-e449-4adb-b58d-1911de52fc7c', N'koujifacebook@gmail.com', 0, NULL, N'404bfed9-311b-40a7-be1b-94ab73da1cc4', NULL, 0, 0, NULL, 1, 0, N'koujifacebook@gmail.com', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'd53af359-80ad-4aa1-9125-f122f584764f', N'abcxyz@abc.com', 0, N'AKE8m+ZklOzR7NXCt+zUQrdefVmhpbPil9OZVfR2y2sLw4PttbrcQh2A64sFAnXoAA==', N'14aa691b-ae8f-4e50-8452-f24d21243589', NULL, 0, 0, NULL, 1, 0, N'abcxyz@abc.com', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Address]) VALUES (N'eafbd39c-a5ad-4b00-94b3-dba96bfdbe05', N'jakelong1232007@gmail.com', 0, N'ADXKr7duG6+M+jYrdDDPu7fFGTLQKDo0BbvUPbDl/mMSQaUKyL0d9/Q9+dbXLqDrkA==', N'fccc5992-f447-48a7-921f-4a4f9fe16bbf', N'0123456789', 0, 0, NULL, 1, 0, N'jakelong1232007@gmail.com', N'Khang', N'Công viên phần mềm Quang Trung')
SET IDENTITY_INSERT [dbo].[CartDetail] ON 

INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (1, 1, 1, 1, 1000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (2, 1, 2, 2, 4000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (3, 2, 3, 5, 3000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (4, 2, 1, 3, 2000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (9, 15, 3, 3, 9000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (10, 15, 11, 1, 20000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (14, 19, 3, 1, 3000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (15, 19, 2, 1, 2000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (16, 19, 36, 1, 3.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (17, 20, 3, 3, 9000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (18, 20, 1, 6, 6000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (19, 20, 2, 2, 4000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (20, 20, 29, 2, 2.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (21, 21, 31, 1, 2.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (22, 21, 35, 1, 3.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (23, 23, 26, 1, 35000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (24, 23, 28, 1, 2.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (25, 24, 1, 1, 1000.0000)
INSERT [dbo].[CartDetail] ([Id], [CartId], [PhoneId], [Quantity], [Total]) VALUES (26, 24, 2, 1, 2000.0000)
SET IDENTITY_INSERT [dbo].[CartDetail] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (1, N'Samsung', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (2, N'Apple', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (3, N'Xiaomi', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (4, N'Sony', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (5, N'LG', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (6, N'Lenovo', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ParentId]) VALUES (7, N'Blackberry', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Phone] ON 

INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (1, N'Galaxy S7', 1, 32, N'1024      ', 4, N'Platform  ', 10, N'/Content/images/New_phone_pictures/samsung/s1.jpg', 1000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (2, N'Galaxy S4', 1, 32, N'1024      ', 4, N'Android   ', 20, N'/Content/images/New_phone_pictures/samsung/s4.jpg', 2000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (3, N'Iphone 7', 2, 32, N'1024      ', 4, N'iOS       ', 15, N'/Content/images/New_phone_pictures/iphone/iphone7.jpg', 3000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (4, N'SamSung S1', 1, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/samsung/s1.jpg', 1000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (6, N'SamSung S2', 1, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/samsung/s2.jpg', 2000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (8, N'SamSung S3', 1, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/samsung/s3.jpg', 3000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (9, N'SamSung S4', 1, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/samsung/s4.jpg', 4000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (11, N'SamSung S5', 1, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/samsung/s5.jpg', 20000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (12, N'Iphone 1', 2, 32, N'1024      ', 4, N'IOS       ', 10, N'/Content/images/New_phone_pictures/iphone/1.jpg', 2000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (14, N'Iphone 2', 2, 32, N'1024      ', 4, N'IOS       ', 10, N'/Content/images/New_phone_pictures/iphone/2.jpg', 3000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (15, N'Iphone 3', 2, 32, N'1024      ', 4, N'IOS       ', 10, N'/Content/images/New_phone_pictures/iphone/3.jpg', 200.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (16, N'Iphone 4', 2, 32, N'1024      ', 4, N'IOS       ', 10, N'/Content/images/New_phone_pictures/iphone/4.jpg', 2000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (19, N'Iphone 5', 2, 32, N'1024      ', 4, N'IOS       ', 10, N'/Content/images/New_phone_pictures/iphone/5.jpg', 2000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (21, N'Iphone 6', 2, 32, N'1024      ', 4, N'IOS       ', 10, N'/Content/images/New_phone_pictures/iphone/6.jpg', 3000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (24, N'Redmi Note 4', 3, 32, N'1024      ', 4, N'Android   ', 10, NULL, 2000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (26, N'Redmi 3s', 3, 32, N'1024      ', 4, N'Android   ', 10, NULL, 35000.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (27, N'Mi 5', 3, 32, N'1024      ', 4, N'Android   ', 10, NULL, 23.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (28, N'Motorola Moto M', 4, 32, N'1024      ', 4, N'Android   ', 10, NULL, 2.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (29, N'LG V20', 5, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/LG/G1.jpg', 1.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (31, N'LG G Pro 2 2', 5, 32, N'1024      ', 4, N'Android   ', 10, N'/Content/images/New_phone_pictures/LG/G2.jpg', 2.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (32, N'Sony Xperia', 4, 32, N'1024      ', 4, N'Android   ', 10, NULL, 3.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (33, N'Sony Xperia XZ', 4, 32, N'1024      ', 4, N'Android   ', 10, NULL, 4.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (35, N'Curve 9380', 7, 32, N'1024      ', 4, N'Android   ', 10, NULL, 3.0000, NULL)
INSERT [dbo].[Phone] ([Id], [Name], [CategoryID], [Capacity], [ScreenResolution], [RAM], [Platform], [Quantity], [Image], [Price], [Description]) VALUES (36, N'Porsche Design P9982', 7, 32, N'1024      ', 4, N'Android   ', 10, NULL, 3.0000, NULL)
SET IDENTITY_INSERT [dbo].[Phone] OFF
SET IDENTITY_INSERT [dbo].[ShoppingCart] ON 

INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (1, N'617f33af-5e92-42e7-b335-be53100d82ed', 0, N'new       ', 0.0000, CAST(N'2017-03-07 11:39:25.000' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (2, N'617f33af-5e92-42e7-b335-be53100d82ed', 1, N'new       ', 0.0000, CAST(N'2017-03-08 09:21:00.000' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (15, N'Anonymous', 0, N'new       ', 0.0000, CAST(N'2017-03-09 10:13:08.627' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (19, N'Anonymous', 3, N'checkout  ', 5003.0000, CAST(N'2017-03-10 08:04:13.787' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (20, N'Anonymous', 4, N'Complete  ', 6001.0000, CAST(N'2017-03-10 21:30:46.680' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (21, N'eafbd39c-a5ad-4b00-94b3-dba96bfdbe05', 2, N'Complete  ', 5.0000, CAST(N'2017-03-12 10:48:29.387' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (22, N'eafbd39c-a5ad-4b00-94b3-dba96bfdbe05', 0, N'new       ', 0.0000, CAST(N'2017-03-12 10:49:32.663' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (23, N'eafbd39c-a5ad-4b00-94b3-dba96bfdbe05', 2, N'Complete  ', 35002.0000, CAST(N'2017-03-12 10:52:09.253' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (24, N'eafbd39c-a5ad-4b00-94b3-dba96bfdbe05', 2, N'Complete  ', 3000.0000, CAST(N'2017-03-12 10:55:41.767' AS DateTime))
INSERT [dbo].[ShoppingCart] ([Id], [AccountID], [Quantity], [Status], [Total], [DateCreated]) VALUES (25, N'Anonymous', 0, N'new       ', 0.0000, CAST(N'2017-03-12 11:08:16.507' AS DateTime))
SET IDENTITY_INSERT [dbo].[ShoppingCart] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 14/03/2017 07:53:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 14/03/2017 07:53:19 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 14/03/2017 07:53:19 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 14/03/2017 07:53:19 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 14/03/2017 07:53:19 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 14/03/2017 07:53:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Phone] FOREIGN KEY([PhoneId])
REFERENCES [dbo].[Phone] ([Id])
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Phone]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Shopping Cart] FOREIGN KEY([CartId])
REFERENCES [dbo].[ShoppingCart] ([Id])
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Shopping Cart]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Color]  WITH CHECK ADD  CONSTRAINT [FK_Color_Phone] FOREIGN KEY([PhoneId])
REFERENCES [dbo].[Phone] ([Id])
GO
ALTER TABLE [dbo].[Color] CHECK CONSTRAINT [FK_Color_Phone]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Category]
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCart_AspNetUsers] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [Mobile Web App] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [ShopOnlineMobie]    Script Date: 1/8/2024 9:39:14 PM ******/
CREATE DATABASE [ShopOnlineMobie]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopOnlineMobie', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopOnlineMobie.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopOnlineMobie_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopOnlineMobie_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopOnlineMobie] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopOnlineMobie].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopOnlineMobie] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopOnlineMobie] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopOnlineMobie] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopOnlineMobie] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopOnlineMobie] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopOnlineMobie] SET  MULTI_USER 
GO
ALTER DATABASE [ShopOnlineMobie] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopOnlineMobie] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopOnlineMobie] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopOnlineMobie] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopOnlineMobie] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopOnlineMobie] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopOnlineMobie] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopOnlineMobie] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopOnlineMobie]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/8/2024 9:39:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/8/2024 9:39:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/8/2024 9:39:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/8/2024 9:39:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/8/2024 9:39:14 PM ******/
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
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[BinhLuanID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[UserName] [nvarchar](256) NULL,
	[NoiDung] [text] NULL,
	[Ngay] [datetime] NULL,
	[PhanHoiID] [int] NULL,
	[LuotLike] [int] NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[BinhLuanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoNhoTrong]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoNhoTrong](
	[MaBoNhoTrong] [nvarchar](50) NOT NULL,
	[DungLuongBoNho] [nchar](10) NULL,
 CONSTRAINT [PK_BoNhoTrong] PRIMARY KEY CLUSTERED 
(
	[MaBoNhoTrong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHinh]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHinh](
	[CauHinhID] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[ManHinh] [nvarchar](max) NULL,
	[MaHeDieuHanh] [nvarchar](50) NULL,
	[CameraSau] [nvarchar](max) NULL,
	[CameraTruoc] [nvarchar](max) NULL,
	[CPU] [nvarchar](max) NULL,
	[MaRam] [nvarchar](50) NULL,
	[MaBoNhoTrong] [nvarchar](50) NULL,
	[TheSim] [nvarchar](max) NULL,
	[DungLuongPin] [nvarchar](max) NULL,
	[ThietKe] [nvarchar](max) NULL,
	[DungLuongBoNho] [nchar](10) NULL,
	[TenHeDieuHanh] [nvarchar](255) NULL,
	[DungLuongRam] [nvarchar](100) NULL,
 CONSTRAINT [PK_CauHinh] PRIMARY KEY CLUSTERED 
(
	[CauHinhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IdGH] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[ThongTinKHID] [nvarchar](100) NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IdGH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeDieuHanh]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeDieuHanh](
	[MaHeDieuHanh] [nvarchar](50) NOT NULL,
	[TenHeDieuHanh] [nvarchar](255) NULL,
 CONSTRAINT [PK_HeDieuHanh] PRIMARY KEY CLUSTERED 
(
	[MaHeDieuHanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[HoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[ThongTinKHID] [nvarchar](100) NULL,
	[NguoiDat] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[SDT] [numeric](18, 0) NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[TongTien] [int] NULL,
	[Gia] [int] NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[HinhChinh] [nvarchar](200) NULL,
 CONSTRAINT [PK_HoaDon_1] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [nvarchar](200) NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NULL,
	[TinhTrang] [nchar](10) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNhaSanXuat] [nvarchar](200) NOT NULL,
	[TenNhaSanXuat] [nvarchar](50) NULL,
	[TinhTrang] [nchar](10) NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaNhaSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanHoiBL]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoiBL](
	[PhanHoiID] [int] IDENTITY(1,1) NOT NULL,
	[BinhLuanID] [int] NULL,
	[UserID] [nvarchar](128) NULL,
	[UserName] [nvarchar](256) NULL,
	[NoiDungPhanHoi] [text] NULL,
	[Ngay] [date] NULL,
 CONSTRAINT [PK_PhanHoiBL] PRIMARY KEY CLUSTERED 
(
	[PhanHoiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ram]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ram](
	[MaRam] [nvarchar](50) NOT NULL,
	[DungLuongRam] [nvarchar](100) NULL,
 CONSTRAINT [PK_Ram] PRIMARY KEY CLUSTERED 
(
	[MaRam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [nvarchar](10) NOT NULL,
	[IdGH] [int] NULL,
	[MaLoaiSanPham] [nvarchar](200) NULL,
	[MaNhaSanXuat] [nvarchar](200) NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[HinhChinh] [nvarchar](200) NULL,
	[Hinh1] [nvarchar](200) NULL,
	[Hinh2] [nvarchar](200) NULL,
	[Hinh3] [nvarchar](200) NULL,
	[Hinh4] [nvarchar](200) NULL,
	[Gia] [int] NULL,
	[SoLuong] [int] NULL,
	[SoLuongDaBan] [int] NULL,
	[VideoSP] [text] NULL,
	[LuotView] [int] NULL,
	[TinhTrang] [nchar](10) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinKhachHang]    Script Date: 1/8/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinKhachHang](
	[ThongTinKHID] [nvarchar](100) NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[NguoiDat] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[SDT] [numeric](18, 0) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[ThongTinKHID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202312171523225_InitialCreate', N'Shop_Mobile.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE3B6127E2F70FE83A0A7738AD4CAE5EC621BD82D52273927389B0BD6D9E2BC05B4443BC44A942A51D904457F591FFA93FA173A942859E245175BB19D628185450EBF190E87E47038CC9FBFFF31FEF139F0AD271C2724A413FB6874685B98BAA147E87262A76CF1DD07FBC71FFEF1CDF8C20B9EAD9F0BBA134E072D6932B11F198B4E1D27711F7180925140DC384CC2051BB961E0202F748E0F0FBF778E8E1C0C10366059D6F8534A190970F6019FD390BA386229F2AF430FFB8928879A59866ADDA000271172F1C49E3D86D1C37538273E1EE5D4B675E6130492CCB0BFB02D4469C81003394F3F2778C6E2902E67111420FFFE25C240B7407E8285FCA72BF2AE5D393CE65D71560D0B28374D5818F4043C3A11BA71E4E66B69D82E7507DABB002DB317DEEB4C8313FBCAC359D1A7D00705C80C4FA77ECC8927F675C9E22C896E301B150D4739E4650C705FC3F8CBA88A7860756E7750DAD2F1E890FF3BB0A6A9CFD2184F284E598CFC03EB2E9DFBC4FD1F7EB90FBF603A39399A2F4E3EBC7B8FBC93F7FFC627EFAA3D85BE025DAD008AEEE230C231C8861765FF6DCBA9B773E48665B34A9B5C2B604B302D6CEB1A3D7FC474C91E61C21C7FB0AD4BF28CBDA24418D7674A6016412316A7F07993FA3E9AFBB8AC771A79F2FF1BB81EBF7B3F08D71BF44496D9D04BFC61E2C430AF3E613FAB4D1E49944FAFDA783F08B2CB380CF877DDBEF2DA875998C62EEF4C6824B947F112B3BA74636765BC9D4C9A430D6FD605EAFE9B369754356F2D29EFD03A33A160B1EDD950C8FBBA7C3B5BDC5914C1E065A6C535D26470EA6635925A1F58159A95E91C75351D0A5DFA3BAF84170122FE004B61072EE0852C481CE0B2973F85607888F696F90E2509AC04DE7F51F2D8203AFC1C40F41976D3180C74C65010BD3AB7BBC790E29B349873BBDF1EAFC186E6FE6B78895C16C61794B7DA18EF63E87E09537641BD73C4F067E61680FCF39E04DD010611E7CC7571925C8231636F1A82935D005E517672DC1B8E2F50BB7645A63E2281DE179196D2878274E58FE829149FC440A6F34B9A44FD182E09ED266A416A1635A768155590F5159583759354509A05CD085AE5CCA906F3F4B2111ADED5CB60F7DFD7DB6CF336AD051535CE6085C4FFC114C7B08C797788311CD3D50874593776E12C64C3C799BEFADE9471FA19F9E9D0ACD69A0DD92230FC6CC860F77F36646242F113F1B857D2E1005410037C277AFDD9AA7DCE49926D7B3AD4BAB96DE6DB59034CD3E52C49429764B34013FA12818BBAFCE0C359ED518CBC377224043A06864EF8960725D0375B36AA5B7A8E7DCCB075E6E6A1C1294A5CE4A96A840E793D042B76548D60AB88485DB86F159E60E938E68D103F042530530965EAB420D42511F25BB524B5ECB885F1BE973CE49A731C61CA19B66AA20B737D00840B50F29106A54D4363A76271CD8668F05A4D63DEE6C2AEC65D894B6CC5265B7C67835D0AFFED550CB359635B30CE66957411C018CCDB85818AB34A5703900F2EFB66A0D289C960A0C2A5DA8A81D635B60303ADABE4CD19687E44ED3AFED27975DFCCB37E50DEFEB6DEA8AE1DD8664D1F7B669AB9EF096D18B4C0B16A9EE7735E899F99E67006728AF359225C5DD94438F80CB37AC866E5EF6AFD50A7194436A226C095A1B5808A6B40054899503D842B62798DD2092FA2076C11776B84156BBF045BB10115BB7A1D5A21345F9ACAC6D9E9F451F6ACB406C5C83B1D162A381A839017AF7AC73B28C514975515D3C517EEE30D573A2606A341412D9EAB4149456706D752619AED5AD239647D5CB28DB424B94F062D159D195C4BC246DB95A4710A7AB8051BA9A8BE850F34D98A4847B9DB94756327CF92120563C7904E35BE465144E8B2925E254AAC599E5B35FD6ED63FE928C8311C37D1E41E95D2969C5818A325966A8135487A49E2849D2386E688C779A65EA09069F756C3F25FB0AC6E9FEA2016FB4041CD7F8B9B55F5F2BEB6D7AACE88C0B8841E06DCA3C9C2E89AF1D737B778BA1BF251AC89DC4F433F0DA8D9C132B7CEEFEFAAEDF3121561EC48F22B0E94A22DC5CDADABBED3C0A89362A0412AFD97F507CA0C615277E17D56156EF248CD284580AA8A620A5AED6CE04C8E4CAFC1927DC4FE63D58AF03AF34A24A6540144514F8C4A6E830256A9EB8E5A4F3FA962D66BBA234A39265548A9AA8794D54C929A90D58AB5F00C1AD55374E7A0E68E54D1D5DAEEC89A2C922AB4A67A0D6C8DCC725D77544DA249155853DD1D7B9575222FA27BBC73194F2E6B6F5DF9E176B3BDCB80F13A2BE2305B5FE50EBF0A5429EE89256EE9153051BE97D6643CE1AD6D4D794C63336B326098579EDAED777DE169BCB23763D6AEB46B8B7BD395BE19AF9FCDBEAA6528073C99A4E45E1EF4A403DD581CAEDA1FD128A7AD9CC4B60A35823DBD240C07234E309AFDE24F7D82F9325E105C234A163861791A877D7C78742CBDC3D99F37314E9278BEE6706A7A18531FB32D6464D12714BB8F2856F323367837B2025542CF57D4C3CF13FBD7ACD56916C5E0BFB2E203EB2AF94CC92F2954DCC729B67E53F33D87C9A3EFF072A314F4B737F124A2BBCAAFFEFF90373DB06E63984EA7D6A1A4E87586BFFE50A2973479D30DA459FBF9C4DB9D6DB5B7095A5469B6ACFF14614ED820CF100A29FF19A0E77FF5154DFBD4602344CD7382A1F00651A1E9B9C03A58C6A7021E7CB2ECA940BFCEEA9F0EAC239AF1D900A1FDC1E44703DD97A1A2E50EF721CD81691B4B52A6E7D6A4EB8D323077BD3729B9D91B4D7435FFBA07DCA039D69BB9286F2C7779B0AD53939A3C18F62EEDFED5F391F7250579E5B4EF36F3789BC9C60D174A7FAB1CE33DC88AD364F9EC3E9378DBB6668A00EF793A66BF7CE13D3336B1CDEF3E2B78DBC6660A10EFB9B1F5CAFDDD335BDBD5FEB9634BEBBC85EE3C93574D4A32DCE4E8A2C86D99BA79C81D8EFFF3108C20F728F30796FAD4B0A6B4D616862B123353734E9ACC5899380A5F85A2996DBFBE8A0DBFB1B382A699AD2193B389B758FF1B790B9A66DE86FCC85DE4186B33147579DF2DEB5853FAD45BCA29AEF5A42585BDCD676DBC967F4B29C48328A5367B0CB7CB6F27637810950C39757A6408AB17C5B07756FE2623ECDF0959AE20F85F68A4D8ADED9A25CD155D84C5E62D49549048119A6BCC90075BEA59CCC802B90CAA79003A7B219E05F5F835C81C7B57F4366551CAA0CB3898FBB5801777029AF86769D07599C7B711FF4A86E802884978E0FE96FE9412DF2BE5BED4C4840C10DCBB10E15E3E968C877D972F25D24D483B0209F5954ED13D0E221FC0925B3A434F781DD9C0FC3EE225725F5611401348FB40D4D53E3E276819A3201118ABF6F00936EC05CF3FFC054C54B3319A540000, N'6.2.0-61023')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'60c48b2d-e570-4c5f-b074-77d05c333b7f', N'Admin')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7f00297-2542-4903-b55d-796d7eb0807d', N'60c48b2d-e570-4c5f-b074-77d05c333b7f')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'250517d7-a8f3-4209-acdb-8b085e6e1779', N'quanghanhphuc95@gmail.com', 0, N'AHyNYK4Zw3ezbHag607fB6hlY/yYWIuxewfwWjj0duETQBNuZCRPaLA55DeDHgYjTg==', N'392f3aec-ac66-4232-8eb6-320325fc2261', NULL, 0, 0, NULL, 1, 0, N'phuc')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7f00297-2542-4903-b55d-796d7eb0807d', N'admin@gmail.com', 0, N'ABoaiXrGMs6LixZICnSnintmpPPvO0b03WA6hRXfOqYzsPBsfUDBzQNMtsZ9vxXsCA==', N'94e9e7f3-1bd8-4809-823e-84c1cd4c6dea', NULL, 0, 0, NULL, 0, 0, N'admin@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fac422d3-3422-49b5-86e2-247bb5406429', N'hanhut95@gmail.com', 0, N'AJrbJU3aw6x96waXDCxDjOHHI6MrEbec6Jyo1KKMIoJffvi2KqJk/i43WXqBw5I5fg==', N'cbb4d95a-ac06-43b5-b79c-c66f85c24487', NULL, 0, 0, NULL, 1, 0, N'Nguyễn Văn Trị')
GO
SET IDENTITY_INSERT [dbo].[BinhLuan] ON 

INSERT [dbo].[BinhLuan] ([BinhLuanID], [UserID], [MaSanPham], [UserName], [NoiDung], [Ngay], [PhanHoiID], [LuotLike]) VALUES (1, N'250517d7-a8f3-4209-acdb-8b085e6e1779', N'SP1', N'phuc', N'oi ', CAST(N'2024-01-07T20:48:06.143' AS DateTime), NULL, 4)
SET IDENTITY_INSERT [dbo].[BinhLuan] OFF
GO
INSERT [dbo].[BoNhoTrong] ([MaBoNhoTrong], [DungLuongBoNho]) VALUES (N'BN1', N'64GB      ')
INSERT [dbo].[BoNhoTrong] ([MaBoNhoTrong], [DungLuongBoNho]) VALUES (N'BN2', N'128GB     ')
INSERT [dbo].[BoNhoTrong] ([MaBoNhoTrong], [DungLuongBoNho]) VALUES (N'BN3', N'256GB     ')
INSERT [dbo].[BoNhoTrong] ([MaBoNhoTrong], [DungLuongBoNho]) VALUES (N'BN4', N'512GB     ')
INSERT [dbo].[BoNhoTrong] ([MaBoNhoTrong], [DungLuongBoNho]) VALUES (N'BN5', N'1024GB    ')
GO
SET IDENTITY_INSERT [dbo].[CauHinh] ON 

INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (10, N'SP1', N'Dynamic AMOLED 2X, 120Hz, HDR10+, 1750 nits (tối đa) 6.8 inches, QHD+ (1440 x 3088 pixels), tỷ lệ 19.5:9 Corning Gorilla Glass Victus 2 Always-on display', N'HDH1', N'200 MP, f/1.7, 24mm (góc rộng) Laser AF, OIS 10 MP, f/4.9, 230mm (tele kính tiềm vọng), zoom 10x 10 MP, f/2.4, 70mm (tele), zoom 3x 12 MP, f/2.2, 13mm, 120˚ (góc siêu rộng) Quay phim: 8K@24/30fps, 4K@30/60fps, 1080p@30/60/240fps, 720p@960fps, HDR10+, stereo sound rec., gyro-EIS', N'12 MP, f/2.2, 26mm (góc rộng) Quay phim: 4K@30/60fps, 1080p@30fps', N'Qualcomm SM8550-AC Snapdragon 8 Gen 2 (4 nm) 8 nhân (1x3.36 GHz & 2x2.8 GHz & 2x2.8 GHz & 3x2.0 GHz) GPU: Adreno 740', N'Ram4', N'BN3', N'2 SIM, 2 Nano SIM 1 Nano SIM + 1eSIM', N'Li-Ion 5000 mAh Sạc nhanh 45W. 65% trong 30 phút Sạc không dây Qi/PMA 15W Sạc ngược không dây 4.5W', N'Khung kim loại + Hai mặt kính (Gorilla Glass Victus 2) Bút SPen, IP68 Khung nhôm bọc thép', N'256GB     ', N'Android', N'8GB')
INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (11, N'SP2', N'IPS LCD, 90Hz, 450 nits (typ), 600 nits (HBM) 6.74 inches, HD+ (720 x 1600 pixels) Mật độ điểm ảnh ~260 ppi Corning Gorilla Glass', N'HDH1', N'50 MP, f/1.8 (góc rộng), PDAF 2 MP, f/2.4 (macro) + Ống kính phụ (Auxiliary) Quay phim: 1080p@30fps', N'8 MP, f/2.0 (góc rộng) Film Filter, HDR, Vòng ánh sáng dịu, Chế độ chân dung Quay phim: 1080p@30fps', N'Mediatek Helio G85 (12nm) 8 nhân (2x2.0 GHz & 6x1.8 GHz) GPU: Mali-G52 MC2', N'Ram3', N'BN1', N'2 SIM, Nano SIM', N'Li-Po 5000 mAh Sạc 18W', N'Khung nhựa vuông vức Mặt lưng nhựa Kính màn hình Corning Gorilla Glass', N'64GB      ', N'Android', N'6GB')
INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (12, N'SP3', N'AMOLED, 1 tỷ màu, HDR10+, 120Hz, 800 nits 6.7 inches, Full HD+ (1080 x 2412 pixels), tỷ lệ 20:9', N'HDH1', N'108 MP, f/1.8, 26mm (góc rộng) 8 MP, f/2.2, 119˚, 16mm (góc siêu rộng) 2 MP, f/2.4, (macro) Quay phim: 4K@30fps, 1080p@30/60/120/480fps, 720p@960fps, gyro-EIS', N'16 MP, f/2.1, 25mm (góc rộng) Quay phim: 1080p@30fps', N'MediaTek Dimensity 1080 (6 nm) 8 nhân (2x2.6 GHz & 6x2.0 GHz) GPU: Mali-G68 MC4', N'Ram4', N'BN2', N'2 SIM, Nano SIM', N'5000 mAh Sạc nhanh 67W, sạc 50% Pin trong 17 phút (quảng cáo)', N'Thanh + Cảm ứng Màn hình cong', N'128GB     ', N'Android', N'8GB')
INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (13, N'SP4', N'LTPO Super Retina XDR OLED, 120Hz, HDR10, Dolby Vision, 1000 nits (typ), 2000 nits (HBM) 6.1 inches, 1.5K (1179 x 2556 pixels), tỷ lệ19.5:9 Kính thủy tinh gốm chống xước, phủ oleophobic Always-On display', N'HDH2', N'48 MP, f/1.8, 24mm (góc rộng), dual pixel PDAF, sensor-shift OIS 12 MP, f/2.8, 77mm (tele), PDAF, OIS, 3x optical zoom 12 MP, f/2.2, 13mm, 120˚ (góc siêu rộng), dual pixel PDAF TOF 3D máy quét LiDAR (depth) Quay phim: 4K@24/25/30/60fps, 1080p@25/30/60/120/240fps, 10-bit HDR, Dolby Vision HDR (up to 60fps), ProRes, Cinematic mode (4K@30fps), stereo sound rec.', N'12 MP, f/1.9, 23mm (góc rộng), PDAF SL 3D, (cảm biến độ sâu/sinh trắc học) Quay phim: 4K@24/25/30/60fps, 1080p@25/30/60/120fps, gyro-EIS', N'Apple A16 Bionic (4 nm) 6 nhân GPU: Apple GPU (5-core graphics) 16‑core Neural Engine', N'Ram3', N'BN2', N'1 Sim', N'Li-Ion 3200 mAh Sạc nhanh 20W, sạc 50% trong 30ph (Quảng cáo) Sạc nhanh tối đa: Đang cập nhật Sạc không dây MagSafe 15W Sạc nhanh không dây Qi từ tính 7.5W', N'Khung thép + Mặt lưng kính', N'128GB     ', N'iOS', N'6GB')
INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (14, N'SP5', N'Super Retina XDR OLED, 60Hz, HDR10, Dolby Vision 5,4 inches, Full HD+ (1080 x 2340 pixels) Thủy tinh gốm chống xước, lớp phủ oleophobic True-tone', N'HDH2', N'12 MP, f/1.6, 26mm (góc rộng), dual pixel PDAF, OIS 12 MP, f/2.4, 120˚, 13mm (góc siêu rộng) Quay phim: 4K@24/30/60fps, 1080p@30/60/120/240fps, HDR, Dolby Vision HDR (lên đến 60fps)', N'12 MP, f/2.2, 23mm (góc rộng) SL 3D, (depth/biometrics sensor) Quay phim: 4K@24/25/30/60fps, 1080p@30/60/120fps, gyro-EIS', N'Apple A15 Bionic (5 nm) 6 nhân (2x3.23 GHz + 4x1.82 GHz) GPU: Apple GPU (4 nhân đồ họa)', N'Ram4', N'BN3', N'1 SIM hoặc 2 SIM', N'Li-Ion 2438 mAh Sạc nhanh 20W, 50% trong 30 phút (được quảng cáo)', N'Thanh + cảm ứng', N'256GB     ', N'iOS', N'8GB')
INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (15, N'SP6', N'LTPO Super Retina XDR OLED, 120Hz, HDR10, Dolby Vision, 1000 nits (typ), 2000 nits (HBM) 6.7 inches, 1290 x 2796 pixels, tỷ lệ 19.5:9 Ceramic Shield glass Always-on Display', N'HDH2', N'48 MP, f/1.8, 24mm (góc rộng), dual pixel PDAF, sensor-shift OIS 12 MP, f/2.8, 120mm (tele kính tiềm vọng), dual pixel PDAF, 3D sensor‑shift OIS, zoom quang 5x 12 MP, f/2.2, 13mm, 120˚ (góc siêu rộng), dual pixel PDAF TOF 3D LiDAR scanner (đo độ sâu) Quay phim: 4K@24/25/30/60fps, 1080p@25/30/60/120/240fps, 10-bit HDR, Dolby Vision HDR (up to 60fps), ProRes, Cinematic mode (4K@24/30fps), 3D (spatial) video, stereo sound rec.', N'12 MP, f/1.9, 23mm (góc rộng), PDAF, OIS SL 3D (độ sâu/cảm biến sinh trắc học) HDR, Cinematic mode (4K@24/30fps) Quay phim: 4K@24/25/30/60fps, 1080p@25/30/60/120fps, gyro-EIS', N'Apple A17 Pro (3 nm) 6 nhân (2x3.78 GHz+ 4x) GPU: Apple GPU (6-lõi đồ họa)', N'Ram4', N'BN2', N'Nano SIM và eSIM (Quốc tế) Chỉ eSIM (bản Mỹ) 2 SIM,Nano SIM (Trung Quốc)', N'Li-Ion (x) mAh Sạc nhanh có dây 50% trong 30 ph (QC) Sạc không dây (MagSafe) 15W Sạc không dây (Qi) 7.5W', N'Màn hình tràn viền với Dynamic Island Khung viền Titan (grade 5) Mặt lưng kính Corning-made Kính trước Ceramic Shield Kháng nước, bụi IP68', N'128GB     ', N'iOS', N'8GB')
INSERT [dbo].[CauHinh] ([CauHinhID], [MaSanPham], [ManHinh], [MaHeDieuHanh], [CameraSau], [CameraTruoc], [CPU], [MaRam], [MaBoNhoTrong], [TheSim], [DungLuongPin], [ThietKe], [DungLuongBoNho], [TenHeDieuHanh], [DungLuongRam]) VALUES (16, N'SP7', N'Màn Chính: Foldable Dynamic AMOLED 2X, 120Hz, HDR10+, 1200 nits (tối đa) 6.7 inches, Full HD+ (1080 x 2640 pixels) Màn phụ: Super AMOLED, 3.4 inches, 720 x 748 pixels Gorilla Glass Victus 2', N'HDH1', N'12 MP, f/1.8, 24mm (góc rộng), Dual Pixel PDAF, OIS 12 MP, f/2.2, 123˚ (góc siêu rộng) Quay phim: 4K@30/60fps, 1080p@60/240fps, 720p@960fps, HDR10+', N'10 MP, f/2.4, 26mm (góc rộng), HDR Quay phim: 4K@30fps', N'Qualcomm SM8550-AB Snapdragon 8 Gen 2 (4 nm) 8 nhân (1x3.2 GHz & 2x2.8 GHz & 2x2.8 GHz & 3x2.0 GHz) GPU: Adreno 740', N'Ram5', N'BN4', N'Nano SIM và eSIM', N'Li-Po 3700 mAh Sạc nhanh 25W, 50% trong 30 ph (QC) Sạc không dây 15W Sạc ngược không dây 4.5W', N'Khung nhôm bọc thép Mặt sau kính Gorilla Glass Victus 2 Kháng nước IPX8', N'512GB     ', N'Android', N'12GB')
SET IDENTITY_INSERT [dbo].[CauHinh] OFF
GO
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([IdGH], [UserID], [ThongTinKHID], [MaSanPham], [SoLuong], [TongTien]) VALUES (74, N'b7f00297-2542-4903-b55d-796d7eb0807d', NULL, N'SP1', 1, 19250000)
INSERT [dbo].[GioHang] ([IdGH], [UserID], [ThongTinKHID], [MaSanPham], [SoLuong], [TongTien]) VALUES (75, N'fac422d3-3422-49b5-86e2-247bb5406429', NULL, N'SP3', 1, 4750000)
SET IDENTITY_INSERT [dbo].[GioHang] OFF
GO
INSERT [dbo].[HeDieuHanh] ([MaHeDieuHanh], [TenHeDieuHanh]) VALUES (N'HDH1', N'Android')
INSERT [dbo].[HeDieuHanh] ([MaHeDieuHanh], [TenHeDieuHanh]) VALUES (N'HDH2', N'iOS')
INSERT [dbo].[HeDieuHanh] ([MaHeDieuHanh], [TenHeDieuHanh]) VALUES (N'HDH3', N'KaiOS')
INSERT [dbo].[HeDieuHanh] ([MaHeDieuHanh], [TenHeDieuHanh]) VALUES (N'HDH4', N'HarmonyOS (Hongmeng OS)')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (N'LSP01', N'Cao Cấp', N'0         ')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (N'LSP02', N'Trung Bình', N'0         ')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (N'NSX04', N'Bình Dân', N'0         ')
GO
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (N'NSX1', N'Xiaomi', N'0         ')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (N'NSX10', N'LG', N'0         ')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (N'NSX11', N'SamSung', N'0         ')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (N'NSX2', N'Iphone', N'0         ')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (N'NSX3', N'Readmi', N'0         ')
GO
SET IDENTITY_INSERT [dbo].[PhanHoiBL] ON 

INSERT [dbo].[PhanHoiBL] ([PhanHoiID], [BinhLuanID], [UserID], [UserName], [NoiDungPhanHoi], [Ngay]) VALUES (1, 1, N'fac422d3-3422-49b5-86e2-247bb5406429', N'Nguyễn Văn Trị', N'Chào th?ng ? trên', CAST(N'2024-01-07' AS Date))
SET IDENTITY_INSERT [dbo].[PhanHoiBL] OFF
GO
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram1', N'3GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram2', N'4GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram3', N'6GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram4', N'8GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram5', N'12GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram6', N'16GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram7', N'24GB')
INSERT [dbo].[Ram] ([MaRam], [DungLuongRam]) VALUES (N'Ram8', N'32GB')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP1', NULL, N'LSP01', N'NSX11', N'Điện thoại Samsung Galaxy S23 Ultra (Chính hãng - ', N'Điện_thoại_Samsung_Galaxy_S23_Ultra_(Chính_hãng_-__Images1.png', N'Điện_thoại_Samsung_Galaxy_S23_Ultra_(Chính_hãng_-__Images2.png', N'Điện_thoại_Samsung_Galaxy_S23_Ultra_(Chính_hãng_-__Images3.png', N'Điện_thoại_Samsung_Galaxy_S23_Ultra_(Chính_hãng_-__Images4.png', N'Điện_thoại_Samsung_Galaxy_S23_Ultra_(Chính_hãng_-__Images5.png', 19250000, 120, 0, NULL, 0, N'0         ', N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP2', NULL, N'NSX04', N'NSX1', N'Điện thoại Xiaomi POCO C65 (Camera 50MP)', N'Điện_thoại_Xiaomi_POCO_C65_(Camera_50MP)_Images1.png', N'Điện_thoại_Xiaomi_POCO_C65_(Camera_50MP)_Images2.png', N'Điện_thoại_Xiaomi_POCO_C65_(Camera_50MP)_Images3.png', NULL, NULL, 2680000, 50, 0, NULL, 0, N'0         ', N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP3', NULL, N'NSX04', N'NSX3', N'Điện thoại Realme 10 Pro Plus 5G (Dimensity 1080 -', N'Điện_thoại_Realme_10_Pro_Plus_5G_(Dimensity_1080_-_Images1.png', N'Điện_thoại_Realme_10_Pro_Plus_5G_(Dimensity_1080_-_Images2.png', N'Điện_thoại_Realme_10_Pro_Plus_5G_(Dimensity_1080_-_Images3.png', NULL, NULL, 4750000, 20, 0, NULL, 0, N'0         ', N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP4', NULL, N'LSP01', N'NSX2', N'Điện thoại iPhone 14 Pro Chính hãng VN/A', N'Điện_thoại_iPhone_14_Pro_Chính_hãng_VNA_Images1.png', N'Điện_thoại_iPhone_14_Pro_Chính_hãng_VNA_Images2.png', N'Điện_thoại_iPhone_14_Pro_Chính_hãng_VNA_Images3.png', N'Điện_thoại_iPhone_14_Pro_Chính_hãng_VNA_Images4.png', NULL, 24850000, 100, 0, NULL, 0, N'0         ', N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP5', NULL, N'LSP01', N'NSX2', N'Điện thoại iPhone 13 mini Chính hãng VN/A', N'Điện_thoại_iPhone_13_mini_Chính_hãng_VNA_Images1.png', N'Điện_thoại_iPhone_13_mini_Chính_hãng_VNA_Images2.png', N'Điện_thoại_iPhone_13_mini_Chính_hãng_VNA_Images3.png', N'Điện_thoại_iPhone_13_mini_Chính_hãng_VNA_Images4.png', N'Điện_thoại_iPhone_13_mini_Chính_hãng_VNA_Images5.png', 27650000, 100, 0, NULL, 0, N'0         ', N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP6', NULL, N'LSP01', N'NSX2', N'Điện thoại iPhone 15 Pro Max Chính hãng VN/A', N'Điện_thoại_iPhone_15_Pro_Max_Chính_hãng_VNA_Images1.png', N'Điện_thoại_iPhone_15_Pro_Max_Chính_hãng_VNA_Images2.png', N'Điện_thoại_iPhone_15_Pro_Max_Chính_hãng_VNA_Images3.png', N'Điện_thoại_iPhone_15_Pro_Max_Chính_hãng_VNA_Images4.png', NULL, 34999000, 30, 0, NULL, 0, N'0         ', N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [IdGH], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuong], [SoLuongDaBan], [VideoSP], [LuotView], [TinhTrang], [GhiChu]) VALUES (N'SP7', NULL, N'LSP01', N'NSX11', N'Điện thoại Samsung Galaxy Z Flip 5 5G (Snapdragon ', N'Điện_thoại_Samsung_Galaxy_Z_Flip_5_5G_(Snapdragon__Images1.png', N'Điện_thoại_Samsung_Galaxy_Z_Flip_5_5G_(Snapdragon__Images2.png', N'Điện_thoại_Samsung_Galaxy_Z_Flip_5_5G_(Snapdragon__Images3.png', N'Điện_thoại_Samsung_Galaxy_Z_Flip_5_5G_(Snapdragon__Images4.png', N'Điện_thoại_Samsung_Galaxy_Z_Flip_5_5G_(Snapdragon__Images5.png', 25950000, 10, 0, NULL, 0, N'0         ', N'New')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/8/2024 9:39:15 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 1/8/2024 9:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 1/8/2024 9:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 1/8/2024 9:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 1/8/2024 9:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/8/2024 9:39:15 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LoaiSanPham] ADD  CONSTRAINT [DF_LoaiSanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[NhaSanXuat] ADD  CONSTRAINT [DF_NhaSanXuat_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_Gia]  DEFAULT ((0)) FOR [Gia]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_SoLuongDaBan]  DEFAULT ((0)) FOR [SoLuongDaBan]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_LuotView]  DEFAULT ((0)) FOR [LuotView]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_GhiChu]  DEFAULT (N'New') FOR [GhiChu]
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
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_AspNetUsers]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_PhanHoiBL] FOREIGN KEY([PhanHoiID])
REFERENCES [dbo].[PhanHoiBL] ([PhanHoiID])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_PhanHoiBL]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_SanPham]
GO
ALTER TABLE [dbo].[CauHinh]  WITH CHECK ADD  CONSTRAINT [FK_CauHinh_BoNhoTrong] FOREIGN KEY([MaBoNhoTrong])
REFERENCES [dbo].[BoNhoTrong] ([MaBoNhoTrong])
GO
ALTER TABLE [dbo].[CauHinh] CHECK CONSTRAINT [FK_CauHinh_BoNhoTrong]
GO
ALTER TABLE [dbo].[CauHinh]  WITH CHECK ADD  CONSTRAINT [FK_CauHinh_HeDieuHanh] FOREIGN KEY([MaHeDieuHanh])
REFERENCES [dbo].[HeDieuHanh] ([MaHeDieuHanh])
GO
ALTER TABLE [dbo].[CauHinh] CHECK CONSTRAINT [FK_CauHinh_HeDieuHanh]
GO
ALTER TABLE [dbo].[CauHinh]  WITH CHECK ADD  CONSTRAINT [FK_CauHinh_Ram] FOREIGN KEY([MaRam])
REFERENCES [dbo].[Ram] ([MaRam])
GO
ALTER TABLE [dbo].[CauHinh] CHECK CONSTRAINT [FK_CauHinh_Ram]
GO
ALTER TABLE [dbo].[CauHinh]  WITH CHECK ADD  CONSTRAINT [FK_CauHinh_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[CauHinh] CHECK CONSTRAINT [FK_CauHinh_SanPham]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_AspNetUsers]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_SanPham]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_ThongTinKhachHang] FOREIGN KEY([ThongTinKHID])
REFERENCES [dbo].[ThongTinKhachHang] ([ThongTinKHID])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_ThongTinKhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_ThongTinKhachHang] FOREIGN KEY([ThongTinKHID])
REFERENCES [dbo].[ThongTinKhachHang] ([ThongTinKHID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_ThongTinKhachHang]
GO
ALTER TABLE [dbo].[PhanHoiBL]  WITH CHECK ADD  CONSTRAINT [FK_PhanHoiBL_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PhanHoiBL] CHECK CONSTRAINT [FK_PhanHoiBL_AspNetUsers]
GO
ALTER TABLE [dbo].[PhanHoiBL]  WITH CHECK ADD  CONSTRAINT [FK_PhanHoiBL_BinhLuan] FOREIGN KEY([BinhLuanID])
REFERENCES [dbo].[BinhLuan] ([BinhLuanID])
GO
ALTER TABLE [dbo].[PhanHoiBL] CHECK CONSTRAINT [FK_PhanHoiBL_BinhLuan]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSanPham])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaSanXuat] FOREIGN KEY([MaNhaSanXuat])
REFERENCES [dbo].[NhaSanXuat] ([MaNhaSanXuat])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaSanXuat]
GO
ALTER TABLE [dbo].[ThongTinKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinKhachHang_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ThongTinKhachHang] CHECK CONSTRAINT [FK_ThongTinKhachHang_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [ShopOnlineMobie] SET  READ_WRITE 
GO

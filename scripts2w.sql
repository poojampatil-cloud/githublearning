USE [master]
GO
/****** Object:  Database [SELL2WORLDdb]    Script Date: 18-06-2020 03:07:55 ******/
CREATE DATABASE [SELL2WORLDdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SELL2WORLDdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SELL2WORLDdb.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SELL2WORLDdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SELL2WORLDdb_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SELL2WORLDdb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SELL2WORLDdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SELL2WORLDdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SELL2WORLDdb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SELL2WORLDdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SELL2WORLDdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SELL2WORLDdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SELL2WORLDdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SELL2WORLDdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SELL2WORLDdb] SET  MULTI_USER 
GO
ALTER DATABASE [SELL2WORLDdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SELL2WORLDdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SELL2WORLDdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SELL2WORLDdb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SELL2WORLDdb]
GO
/****** Object:  StoredProcedure [dbo].[USP_Employee_Authentication]    Script Date: 18-06-2020 03:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_Employee_Authentication] ---- USP_Employee_Authentication 'varsha.shendge17@gmail.com','vOZDRWYq6QMr'

@Username varchar(100),
@Password varchar(100),
@Result int output,
@EmployeeId int output,

@EmployeeName varchar(100) output

as
begin
	if exists(Select * From Tbl_EmployeeAuthentication A inner join Tbl_Employee S on A.ReferenceId=S.EmployeeId
	where  ltrim(rtrim(A.UserName))=ltrim(rtrim(@Username)) 
	and ltrim(rtrim(A.UserPassword))=ltrim(rtrim(@Password)))
	begin
		set @Result=1
		set @EmployeeId=(Select ReferenceId From Tbl_EmployeeAuthentication where  ltrim(rtrim(UserName))=ltrim(rtrim(@Username)) and ltrim(rtrim(UserPassword))=ltrim(rtrim(@Password)))
		set @EmployeeName=(Select EmployeeNm from Tbl_Employee  Where EmployeeId=@EmployeeId)
		
		--set @UserId=(Select StudentAuthenticationId From Tbl_EmployeeAuthentication where ReferenceId=@StudentId)
		--set @MembershipNumber =(Select MembershipNumber From tbl_Students where StudentId=@StudentId)
	end
	else
	begin
		set @Result=0
	end	

end

GO
/****** Object:  StoredProcedure [dbo].[USP_EmployeeDetail_Insert]    Script Date: 18-06-2020 03:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_EmployeeDetail_Insert]

@EmployeeNm nvarchar(MAX),

@EmployeeId int output,

@AccountPassword nvarchar(100),


@CreatedDate datetime,
@CreatedBy nvarchar(100)



as
begin
	

	set @EmployeeId=ISNULL((select MAX(EmployeeId) from tbl_Employee),0)+1
	--set @MemberShipNumber=@StudentId
	
	

	insert into Tbl_Employee(EmployeeId,EmployeeNm,CreatedBy,CreateDate) 

	values(@EmployeeId,@EmployeeNm,@CreatedBy,@CreatedDate)

	declare @Authentication_Id int
		set @Authentication_Id=ISNULL((select max(EmployeeAuthenticationId) from tbl_EmployeeAuthentication),0)+1
		insert into tbl_EmployeeAuthentication(EmployeeAuthenticationId,ReferenceId,UserName,UserPassword,CreatedDate,CreatedBy)
		values

		(@Authentication_Id,@EmployeeId,@EmployeeNm,@AccountPassword,@CreatedDate,@CreatedBy)



end









GO
/****** Object:  Table [dbo].[Tbl_Employee]    Script Date: 18-06-2020 03:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Employee](
	[EmployeeId] [nchar](10) NOT NULL,
	[EmployeeNm] [nvarchar](max) NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_EmployeeAuthentication]    Script Date: 18-06-2020 03:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_EmployeeAuthentication](
	[EmployeeAuthenticationId] [int] NOT NULL,
	[ReferenceId] [int] NULL,
	[UserName] [varchar](100) NULL,
	[UserPassword] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_EmployeeAuthentication] PRIMARY KEY CLUSTERED 
(
	[EmployeeAuthenticationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tbl_Employee] ([EmployeeId], [EmployeeNm], [CreatedBy], [CreateDate]) VALUES (N'1         ', N'a', NULL, NULL)
INSERT [dbo].[Tbl_EmployeeAuthentication] ([EmployeeAuthenticationId], [ReferenceId], [UserName], [UserPassword], [CreatedDate], [CreatedBy]) VALUES (1, 1, N'a', N'a', NULL, NULL)
USE [master]
GO
ALTER DATABASE [SELL2WORLDdb] SET  READ_WRITE 
GO

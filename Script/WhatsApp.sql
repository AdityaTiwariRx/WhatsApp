USE [master]
GO
/****** Object:  Database [WhatsAppDb]    Script Date: 21-02-2020 18:32:35 ******/
CREATE DATABASE [WhatsAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WhatsAppDb_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQL2017\MSSQL\DATA\WhatsAppDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WhatsAppDb_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQL2017\MSSQL\DATA\WhatsAppDb.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WhatsAppDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WhatsAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WhatsAppDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WhatsAppDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WhatsAppDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WhatsAppDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WhatsAppDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [WhatsAppDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WhatsAppDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WhatsAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WhatsAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WhatsAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WhatsAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WhatsAppDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WhatsAppDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WhatsAppDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WhatsAppDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WhatsAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WhatsAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WhatsAppDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WhatsAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WhatsAppDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WhatsAppDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WhatsAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WhatsAppDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WhatsAppDb] SET  MULTI_USER 
GO
ALTER DATABASE [WhatsAppDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WhatsAppDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WhatsAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WhatsAppDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WhatsAppDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WhatsAppDb] SET QUERY_STORE = OFF
GO
USE [WhatsAppDb]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[StatusType] [varchar](50) NOT NULL,
	[StatusContent] [varchar](max) NULL,
	[StatusCaption] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserPhoto] [varchar](max) NULL,
	[About] [varchar](150) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserMobileNumber] [bigint] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[UserMobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vStatus]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vStatus]
AS
SELECT        dbo.UserDetails.UserName, dbo.Status.StatusId, dbo.Status.StatusType, dbo.Status.StatusContent, dbo.Status.StatusCaption, dbo.Status.CreatedTime, dbo.Status.UserId
FROM            dbo.Status INNER JOIN
                         dbo.Users ON dbo.Status.UserId = dbo.Users.UserId INNER JOIN
                         dbo.UserDetails ON dbo.Users.UserId = dbo.UserDetails.UserId
GO
/****** Object:  Table [dbo].[SeenStatus]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeenStatus](
	[SeenStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[SeenTime] [datetime] NOT NULL,
	[MyContactId] [int] NOT NULL,
 CONSTRAINT [PK_SeenStatus] PRIMARY KEY CLUSTERED 
(
	[SeenStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyContacts]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyContacts](
	[MyContactId] [int] IDENTITY(1,1) NOT NULL,
	[MyContactName] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[UsercontactId] [int] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_MyContacts] PRIMARY KEY CLUSTERED 
(
	[MyContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vStatusSeen]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vStatusSeen]
AS
SELECT        dbo.Status.UserId, dbo.SeenStatus.StatusId, dbo.MyContacts.MyContactId, dbo.MyContacts.MyContactName, dbo.SeenStatus.SeenTime
FROM            dbo.Status INNER JOIN
                         dbo.SeenStatus ON dbo.Status.StatusId = dbo.SeenStatus.StatusId INNER JOIN
                         dbo.MyContacts ON dbo.SeenStatus.MyContactId = dbo.MyContacts.MyContactId
GO
/****** Object:  Table [dbo].[ChatContents]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatContents](
	[ChatContentId] [int] IDENTITY(1,1) NOT NULL,
	[ChatMessage] [varchar](max) NOT NULL,
	[ChatId] [int] NOT NULL,
	[ChatAttachmentId] [int] NULL,
	[SendTime] [datetime] NOT NULL,
	[ReceiveTime] [datetime] NULL,
	[SeenTime] [datetime] NULL,
 CONSTRAINT [PK_ChatContents] PRIMARY KEY CLUSTERED 
(
	[ChatContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chats]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chats](
	[ChatId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MyContactId] [int] NOT NULL,
 CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED 
(
	[ChatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vChats]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vChats]
AS
SELECT        dbo.Chats.UserId AS [Sender Id], dbo.UserDetails.UserName AS [Sender name], dbo.MyContacts.UsercontactId AS ReceiverId, dbo.MyContacts.MyContactName AS [Receiver name], dbo.Chats.ChatId, 
                         dbo.ChatContents.ChatMessage, dbo.ChatContents.SendTime
FROM            dbo.Chats INNER JOIN
                         dbo.MyContacts ON dbo.Chats.MyContactId = dbo.MyContacts.MyContactId INNER JOIN
                         dbo.ChatContents ON dbo.Chats.ChatId = dbo.ChatContents.ChatId INNER JOIN
                         dbo.Users ON dbo.Chats.UserId = dbo.Users.UserId AND dbo.MyContacts.UserId = dbo.Users.UserId INNER JOIN
                         dbo.UserDetails ON dbo.Users.UserId = dbo.UserDetails.UserId
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocks](
	[BlockId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BlockedUserId] [int] NOT NULL,
 CONSTRAINT [PK_Blocks] PRIMARY KEY CLUSTERED 
(
	[BlockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatAttachments]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatAttachments](
	[ChatAttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[ChatAttachmentType] [varchar](50) NULL,
	[Contents] [varchar](max) NULL,
	[Caption] [varchar](50) NULL,
 CONSTRAINT [PK_ChatAttachments] PRIMARY KEY CLUSTERED 
(
	[ChatAttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [varchar](50) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Otp]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otp](
	[OtpId] [int] IDENTITY(1,1) NOT NULL,
	[OtpCode] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Otp] PRIMARY KEY CLUSTERED 
(
	[OtpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Otp] UNIQUE NONCLUSTERED 
(
	[OtpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privacies]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privacies](
	[PrivacyId] [int] IDENTITY(1,1) NOT NULL,
	[PhotoPrivacy] [varchar](50) NULL,
	[AboutPrivacy] [varchar](50) NULL,
	[LastSeenPrivacy] [varchar](50) NULL,
	[StatusPrivacy] [varchar](50) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Privacies] PRIMARY KEY CLUSTERED 
(
	[PrivacyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserDetails]    Script Date: 21-02-2020 18:32:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserDetails] ON [dbo].[UserDetails]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_Blocks_MyContacts] FOREIGN KEY([BlockedUserId])
REFERENCES [dbo].[MyContacts] ([MyContactId])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_Blocks_MyContacts]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_Blocks_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_Blocks_Users]
GO
ALTER TABLE [dbo].[ChatContents]  WITH CHECK ADD  CONSTRAINT [FK_ChatContents_ChatAttachments] FOREIGN KEY([ChatAttachmentId])
REFERENCES [dbo].[ChatAttachments] ([ChatAttachmentId])
GO
ALTER TABLE [dbo].[ChatContents] CHECK CONSTRAINT [FK_ChatContents_ChatAttachments]
GO
ALTER TABLE [dbo].[ChatContents]  WITH CHECK ADD  CONSTRAINT [FK_ChatContents_Chats] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chats] ([ChatId])
GO
ALTER TABLE [dbo].[ChatContents] CHECK CONSTRAINT [FK_ChatContents_Chats]
GO
ALTER TABLE [dbo].[Chats]  WITH CHECK ADD  CONSTRAINT [FK_Chats_MyContacts1] FOREIGN KEY([MyContactId])
REFERENCES [dbo].[MyContacts] ([MyContactId])
GO
ALTER TABLE [dbo].[Chats] CHECK CONSTRAINT [FK_Chats_MyContacts1]
GO
ALTER TABLE [dbo].[Chats]  WITH CHECK ADD  CONSTRAINT [FK_Chats_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Chats] CHECK CONSTRAINT [FK_Chats_Users]
GO
ALTER TABLE [dbo].[MyContacts]  WITH CHECK ADD  CONSTRAINT [FK_MyContacts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[MyContacts] CHECK CONSTRAINT [FK_MyContacts_Users]
GO
ALTER TABLE [dbo].[Otp]  WITH CHECK ADD  CONSTRAINT [FK_Otp_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Otp] CHECK CONSTRAINT [FK_Otp_Users]
GO
ALTER TABLE [dbo].[Privacies]  WITH CHECK ADD  CONSTRAINT [FK_Privacies_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Privacies] CHECK CONSTRAINT [FK_Privacies_Users]
GO
ALTER TABLE [dbo].[SeenStatus]  WITH CHECK ADD  CONSTRAINT [FK_SeenStatus_MyContacts] FOREIGN KEY([MyContactId])
REFERENCES [dbo].[MyContacts] ([MyContactId])
GO
ALTER TABLE [dbo].[SeenStatus] CHECK CONSTRAINT [FK_SeenStatus_MyContacts]
GO
ALTER TABLE [dbo].[SeenStatus]  WITH CHECK ADD  CONSTRAINT [FK_SeenStatus_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[SeenStatus] CHECK CONSTRAINT [FK_SeenStatus_Status]
GO
ALTER TABLE [dbo].[Status]  WITH CHECK ADD  CONSTRAINT [FK_Status_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Status] CHECK CONSTRAINT [FK_Status_Users]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Countries]
GO
/****** Object:  StoredProcedure [dbo].[Search]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Search] @SearchText varchar(30),@myId int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select MyContactName from MyContacts where MyContactName like '%'+@SearchText+'%' and UserId=@myId;
	

END
GO
/****** Object:  StoredProcedure [dbo].[ShowChat]    Script Date: 21-02-2020 18:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowChat] @sendarId int, @ReceiverId int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from vChats where ([Sender Id] =@sendarId or [ReceiverId] =@sendarId ) and ([Sender Id] =@ReceiverId or [ReceiverId] =@ReceiverId)
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id of the person with whom you are chatting.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyContacts', @level2type=N'COLUMN',@level2name=N'UsercontactId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[36] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ChatContents"
            Begin Extent = 
               Top = 6
               Left = 672
               Bottom = 136
               Right = 859
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 897
               Bottom = 119
               Right = 1090
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserDetails"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chats"
            Begin Extent = 
               Top = 6
               Left = 464
               Bottom = 119
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MyContacts"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2145
         Alias = 2760
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vChats'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vChats'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vChats'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 119
               Right = 647
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserDetails"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Status"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SeenStatus"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Status"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MyContacts"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vStatusSeen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vStatusSeen'
GO
USE [master]
GO
ALTER DATABASE [WhatsAppDb] SET  READ_WRITE 
GO

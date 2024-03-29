USE [Assignment20]
GO
ALTER TABLE [dbo].[Tweet] DROP CONSTRAINT [FK_Tweet_Person]
GO
ALTER TABLE [dbo].[Following] DROP CONSTRAINT [FK_Following_Person1]
GO
ALTER TABLE [dbo].[Following] DROP CONSTRAINT [FK_Following_Person]
GO
ALTER TABLE [dbo].[Person] DROP CONSTRAINT [DF_Person_Active]
GO
ALTER TABLE [dbo].[Person] DROP CONSTRAINT [DF_Person_Joined]
GO
/****** Object:  Table [dbo].[Tweet]    Script Date: 6/29/2019 5:55:34 PM ******/
DROP TABLE [dbo].[Tweet]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/29/2019 5:55:34 PM ******/
DROP TABLE [dbo].[Person]
GO
/****** Object:  Table [dbo].[Following]    Script Date: 6/29/2019 5:55:34 PM ******/
DROP TABLE [dbo].[Following]
GO
/****** Object:  Table [dbo].[Following]    Script Date: 6/29/2019 5:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Following](
	[UserId] [varchar](25) NOT NULL,
	[FollowingId] [varchar](25) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/29/2019 5:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[UserId] [varchar](25) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FullName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Joined] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tweet]    Script Date: 6/29/2019 5:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tweet](
	[TweetId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](25) NOT NULL,
	[Message] [varchar](140) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Tweet] PRIMARY KEY CLUSTERED 
(
	[TweetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Joined]  DEFAULT (getdate()) FOR [Joined]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Following]  WITH CHECK ADD  CONSTRAINT [FK_Following_Person] FOREIGN KEY([UserId])
REFERENCES [dbo].[Person] ([UserId])
GO
ALTER TABLE [dbo].[Following] CHECK CONSTRAINT [FK_Following_Person]
GO
ALTER TABLE [dbo].[Following]  WITH CHECK ADD  CONSTRAINT [FK_Following_Person1] FOREIGN KEY([FollowingId])
REFERENCES [dbo].[Person] ([UserId])
GO
ALTER TABLE [dbo].[Following] CHECK CONSTRAINT [FK_Following_Person1]
GO
ALTER TABLE [dbo].[Tweet]  WITH CHECK ADD  CONSTRAINT [FK_Tweet_Person] FOREIGN KEY([UserId])
REFERENCES [dbo].[Person] ([UserId])
GO
ALTER TABLE [dbo].[Tweet] CHECK CONSTRAINT [FK_Tweet_Person]
GO

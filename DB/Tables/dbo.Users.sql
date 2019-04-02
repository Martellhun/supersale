CREATE TABLE [dbo].[Users]
(
[UserID] [bigint] NOT NULL,
[FirstName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UserName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Password] [varbinary] (128) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK_Users_UserID] PRIMARY KEY CLUSTERED  ([UserID]) ON [PRIMARY]
GO

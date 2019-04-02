CREATE TABLE [dbo].[UserDetails]
(
[UserID] [bigint] NOT NULL,
[State] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[City] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Zip] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Street] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Streettype] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Adress] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserDetails] ADD CONSTRAINT [PK_UserDetails_UserID] PRIMARY KEY CLUSTERED  ([UserID]) ON [PRIMARY]
GO

CREATE TABLE [dbo].[di_Brands]
(
[BrandID] [tinyint] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[di_Brands] ADD CONSTRAINT [PK_di_Brands_BrandID] PRIMARY KEY CLUSTERED  ([BrandID]) ON [PRIMARY]
GO

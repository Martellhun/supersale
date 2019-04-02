CREATE TABLE [dbo].[Recipes]
(
[RecipeID] [bigint] NOT NULL IDENTITY(1, 1),
[ServicePackID] [bigint] NOT NULL,
[PartID] [bigint] NOT NULL,
[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Recipes] ADD CONSTRAINT [PK_Recipes_RecipeID] PRIMARY KEY CLUSTERED  ([RecipeID]) ON [PRIMARY]
GO

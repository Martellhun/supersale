using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Data.SQLQueries
{
    internal static class RecipeQueries
    {
        internal const string GetRecipes =
            @"SELECT r.RecipeID, p.Name, r.Quantity, p.UM 
              FROM DBO.Recipes r
              INNER JOIN dbo.Parts p 
                ON p.PartID = r.PartID";
    }
}

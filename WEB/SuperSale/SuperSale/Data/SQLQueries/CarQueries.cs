namespace SuperSale.Data.SQLQueries
{
    public static class CarQueries
    {
        internal const string DeleteCar = "DELETE FROM dbo.cars WHERE CarID = @CarId";
    }
}

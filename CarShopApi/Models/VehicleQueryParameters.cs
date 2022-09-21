namespace CarShopApi.Models
{
    public class VehicleQueryParameters:QueryParameters
    {
        public  decimal? Min_Price { get; set; }
        public  decimal? Max_Price { get; set; }
    }
}

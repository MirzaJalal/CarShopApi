namespace CarShopApi.Models
{
    public class QueryParameters
    {
        const int maxPageSize = 100;
        private int _size = 50;
        public int Page { get; set; } = 1;
        public int Size
        {
            get { return _size; }
            set
            {
                _size = Math.Min(value, maxPageSize);
            }
        }
    }
}
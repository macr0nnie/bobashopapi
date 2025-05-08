using Microsoft.ML.Data;
namespace BobaShopApi.Models
{
    public class BookDataML
    {
        [LoadColumn(0)]
        public string Title { get; set; }

        [LoadColumn(1)]
        public string Author { get; set; }

        [LoadColumn(2)]
        public string Genre { get; set; }

        [LoadColumn(3)]
        public string Description { get; set; }

        [LoadColumn(4)]
        public int Year { get; set; }
    }
}
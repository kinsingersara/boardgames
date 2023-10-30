using System.ComponentModel.DataAnnotations;

namespace boardgamestore_skinsinger.Data.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Difficulty { get; set; }
        public decimal Price { get; set; }



    }
}

using RecordShop_Frontend.Model;
using System.ComponentModel.DataAnnotations;

namespace RecordShop_Frontend.Model
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Album Title Required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Artist Name Required.")]
        public string ArtistName { get; set; }
        public string MusicGenre { get; set; } = string.Empty;
        [ReleaseYearValidation(ErrorMessage = "Release year should not be greater than current year")]
        public int ReleaseYear { get; set; }
        [Required(ErrorMessage = " Stock Value Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Stock Value.")]
        public int Stock { get; set; }

        public void Copy(AlbumDTO other)
        {
            if (other != null)
            {
                Title = other.Title;
                ArtistName = other.ArtistName;
                MusicGenre = other.MusicGenre;
                ReleaseYear = other.ReleaseYear;
                Stock = other.Stock;
            }
        }
    }
}
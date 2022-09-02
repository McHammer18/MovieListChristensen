using System.ComponentModel.DataAnnotations;

namespace MovieListChristensen.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter the Name of the Movie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the year the Movie came out.")]
        [Range(1889, 2050, ErrorMessage ="Year must be between 1889 and 2024")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a Rating")]
        [Range(1, 5, ErrorMessage = " Ratings are on the 5 star scale")]
        public int Rating { get; set; }

        [Required(ErrorMessage="Please enter the Genre")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();

    }
}

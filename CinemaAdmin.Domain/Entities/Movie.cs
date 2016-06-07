using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CinemaAdmin.Domain.Entities
{
    public class Movie
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Geef een geldige naam")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]

        [Required(ErrorMessage = "Geef een geldige beschrijving")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Geef een geldige taal")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Geef geldige ondertiteling")]
        public string Subtitle { get; set; }

        [Required(ErrorMessage = "Geef een geldige schrijver")]
        public string Writer { get; set; }

        [Required(ErrorMessage = "Geef geldige acteurs")]
        public string Stars { get; set; }

        [Required(ErrorMessage = "Geef een geldige website")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Geef een geldige IMDB pagina")]
        public string IMDB { get; set; }

        [Required(ErrorMessage = "Geef een geldige trailer")]
        public string Trailer { get; set; }

        public string ImageData { get; set; }

        [Required(ErrorMessage = "Geef een geldige kijkwijzer")]
        public string Kijkwijzer { get; set; }

        [Required(ErrorMessage = "Geef een geldige thumbnail")]
        public string ThumbnailData { get; set; }

        [Required(ErrorMessage = "Geef een geldig type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Geef een geldige filmduur")]
        public int Duration { get; set; }
    }
}

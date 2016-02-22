namespace WatchMe.Web.Areas.Administration.ViewModels.Movies
{
    using System;
    using Data.Models;
    using Infastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    public class MovieViewModel : IMapFrom<Movie>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    
        public int? Duration { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Overview { get; set; }
    }
}
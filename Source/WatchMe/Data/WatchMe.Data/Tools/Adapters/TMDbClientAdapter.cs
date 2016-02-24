namespace WatchMe.Data.Tools.Adapters
{
    using System.Collections.Generic;

    using TMDbLib.Client;
    using TMDbLib.Objects.General;
    using TMDbLib.Objects.Movies;

    public class TMDbClientAdapter : ITMDbClientAdapter
    {
        private TMDbClient client;

        public TMDbClientAdapter()
        {
            this.client = new TMDbClient("33551b01424882b74730e2ee86ca1693");
        }

        public Movie GetMovie(int movieId, MovieMethods extraMethods = MovieMethods.Undefined)
        {
            return this.client.GetMovie(movieId, extraMethods);
        }

        public List<Genre> GetMovieGenres()
        {
            return this.client.GetMovieGenres();
        }

        public SearchContainer<MovieResult> GetMovieList(MovieListType type, int page = 0)
        {
            return this.client.GetMovieList(type, page);
        }
    }
}
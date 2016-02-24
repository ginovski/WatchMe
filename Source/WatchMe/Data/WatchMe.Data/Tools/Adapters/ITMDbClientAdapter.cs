namespace WatchMe.Data.Tools.Adapters
{
    using System.Collections.Generic;

    using TMDbLib.Objects.General;
    using TMDbLib.Objects.Movies;

    public interface ITMDbClientAdapter
    {
        List<Genre> GetMovieGenres();

        SearchContainer<MovieResult> GetMovieList(MovieListType type, int page = 0);

        Movie GetMovie(int movieId, MovieMethods extraMethods = MovieMethods.Undefined);
    }
}
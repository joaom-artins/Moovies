using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;

namespace Movies.Data.Repositories.Repository.Movie;

public class MovieRepository(AppDbContext context) : GenericRepository<MovieModel>(context),
    IMovieRepository
{
}

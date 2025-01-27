using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;
using Movies.Data.Repositories.Repository.Movie.Interface;

namespace Movies.Data.Repositories.Repository.Movie;

public class MovieRepository(AppDbContext context) : GenericRepository<MovieModel>(context),
    IMovieRepository
{
}

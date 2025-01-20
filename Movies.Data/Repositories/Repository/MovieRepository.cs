using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;
using Movies.Data.Repositories.Interfaces;

namespace Movies.Data.Repositories.Repository;

public class MovieRepository(AppDbContext context) : GenericRepository<MovieModel>(context),
    IMovieRepository
{
}

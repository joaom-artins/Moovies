using Movies.Core.Models;
using Movies.Data.Repositories.Generic.Interfaces;

namespace Movies.Data.Repositories.Repository.Movie;

public interface IMovieRepository : IGenericRepository<MovieModel>
{
}

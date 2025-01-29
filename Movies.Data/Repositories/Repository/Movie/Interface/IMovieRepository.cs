using Movies.Core.Models;
using Movies.Data.Repositories.Generic.Interfaces;

namespace Movies.Data.Repositories.Repository.Movie.Interface;

public interface IMovieRepository : IGenericRepository<MovieModel>
{
}

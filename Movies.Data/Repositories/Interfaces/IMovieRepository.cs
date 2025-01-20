﻿using Movies.Core.Models;
using Movies.Data.Repositories.Generic.Interfaces;

namespace Movies.Data.Repositories.Interfaces;

public interface IMovieRepository : IGenericRepository<MovieModel>
{
}

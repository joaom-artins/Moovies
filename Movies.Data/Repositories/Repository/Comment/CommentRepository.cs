using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;

namespace Movies.Data.Repositories.Repository.Comment;

public class CommentRepository(AppDbContext context) : GenericRepository<CommentModel>(context),
    ICommentRepository
{
}

using System.ComponentModel.DataAnnotations;
using Movies.Core.Models.Base;

namespace Movies.Core.Models
{
    public class CommentModel : BaseEntity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public UserModel User { get; private set; } = default!;
        [MaxLength(100)]
        public string? Title { get; private set; }
        [MaxLength(1024)]
        public string? Comment { get; private set; }
        public double Stars { get; private set; }

        public CommentModel()
        {
        }
        public CommentModel(UserModel user, string? title, string? comment, double stars)
        {
            SetUser(user);
            SetTitle(title);
            SetComment(comment);
            SetStars(stars);
        }

        public void SetUser(UserModel user)
        {
            User = user;
        }

        public void SetTitle(string? title) 
        {
            Title = title; 
        }

        public void SetComment(string? comment)
        { 
            Comment = comment;  
        }

        public void SetStars(double stars)
        {
            Stars = stars;
        }
    }
}

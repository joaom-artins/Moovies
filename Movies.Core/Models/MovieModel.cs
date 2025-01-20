﻿using System.ComponentModel.DataAnnotations;
using Movies.Core.Enum;

namespace Movies.Core.Models;

public class MovieModel
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; } 
    public UserModel User { get; private set; } = default!;
    [MaxLength(128)]
    public string Title { get; private set; } = string.Empty;
    [MaxLength(1024)]
    public string Synopsis { get; private set; } = string.Empty;
    public double Stars { get; private set; }
    public int VoteNumbers { get; private set; }
    public MovieGender Gender { get; private set; }
    [MaxLength(60)]
    public string Author { get; set; } = string.Empty;
    public double MediaByUser { get; set; }

    public MovieModel()
    {
    }

    public MovieModel(UserModel user,string title, string synopsis, double stars, int voteNumbers, MovieGender gender, string author, double mediaByUser)
    {
        SetUSer(user);
        SetTitle(title);
        SetSynopsis(synopsis);
        SetStars(stars);
        SetVoteNumbers(voteNumbers);    
        SetGender(gender);
        SetAuthor(author);
        SetMediaByUser(mediaByUser);
    }

    public void SetTitle(string title)
    {
        Title = title;
    }
    
    public void SetSynopsis(string synopsis)
    {
        Synopsis = synopsis;
    }

    public void SetStars(double stars)
    {
        Stars = stars;
    }

    public void SetVoteNumbers(int voteNumbers)
    {
        VoteNumbers = voteNumbers;
    }

    public void SetUSer(UserModel user)
    {
        User = user;
    }

    public void SetGender(MovieGender gender)
    {
        Gender = gender;
    }

    public void SetAuthor(string author)
    {
        Author = author;
    }

    public void SetMediaByUser(double mediaByUser)
    {
        MediaByUser = mediaByUser;
    }
}

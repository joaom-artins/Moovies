namespace Movies.Core.Models;

public class MovieModel
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Synopsis { get; private set; } = string.Empty;
    public double Stars { get; private set; }
    public int VoteNumbers { get; private set; }

    public MovieModel(string title, string synopsis, double stars, int voteNumbers)
    {
        SetTitle(title);
        SetSynopsis(synopsis);
        SetStars(stars);
        SetVoteNumbers(voteNumbers);    
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
}

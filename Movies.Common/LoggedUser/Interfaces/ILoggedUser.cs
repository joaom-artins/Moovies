namespace Movies.Common.LoggedUser.Interfaces;

public interface ILoggedUser
{
    Guid GetId();
    string GetRole();
}

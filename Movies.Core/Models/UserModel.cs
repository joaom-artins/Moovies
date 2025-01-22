using Microsoft.AspNetCore.Identity;

namespace Movies.Core.Models;

public class UserModel : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    public void SetUpdatedAt(DateTime? updatedAt)
    {
        UpdatedAt = updatedAt;
    }

}

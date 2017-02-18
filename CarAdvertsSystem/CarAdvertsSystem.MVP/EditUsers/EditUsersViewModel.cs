using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.EditUsers
{
    public class EditUsersViewModel
    {
        public IQueryable<User> Users { get; set; }
    }
}

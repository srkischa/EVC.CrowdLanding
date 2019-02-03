using System.Collections.Generic;

namespace EVC.CrowdLanding.DomainModel
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<UsersFundings> UsersFundings { get; set; }
    }
}

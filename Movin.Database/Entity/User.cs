using System.ComponentModel.DataAnnotations;

namespace Movin.Database.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public bool Enable { get; set; }
    }
}

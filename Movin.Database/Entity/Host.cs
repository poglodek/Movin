using System.ComponentModel.DataAnnotations;

namespace Movin.Database.Entity
{
    public class Host
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HostName { get; set; }
        [Required]
        public string Ip { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Test> Tests { get; set; }
        public List<TestResult> TestResults { get; set; }
        public int Port { get; set; }
    }

}

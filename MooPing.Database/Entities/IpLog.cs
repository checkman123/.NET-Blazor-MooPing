using System.ComponentModel.DataAnnotations;

namespace MooPing.Database.Entities
{
    public class IpLog
    {
        [Key]
        public int LogId { get; set; }

        public string Ipaddress { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}

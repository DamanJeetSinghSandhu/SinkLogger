
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sink.Logger.Models
{
    public class LogMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string Content { get; set; }
        public string Level { get; set; }
        public string Namespace { get; set; }

        //public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Entidades
{
    public class SemanaTopics
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Anho { get; set; }
        [Required]
        public int NumSemana { get; set; }
        public ICollection<TopicSemanaTopics> TopicsSemanaTopics { get; set; }
        
    }
}

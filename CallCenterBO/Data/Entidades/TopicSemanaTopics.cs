using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Entidades
{
    // Relaciona los topics con la tabla de semana topics
    public class TopicSemanaTopics
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Topic")]
        public Guid IdTopic { get; set; }
        public Topic Topic { get; set; }
        [ForeignKey("SemanaTopics")]
        public Guid IdSemanaTopics { get; set; }
        public SemanaTopics SemanaTopics { get; set; }
    }
}

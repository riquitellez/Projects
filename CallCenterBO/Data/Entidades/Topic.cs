using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Entidades
{
    public class Topic
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Codigo { get; set; } //Para en un futuro utilizar un nñumero de tema y no el nombre completo
        public string Descripcion { get; set; }
        public ICollection<TopicSemanaTopics> TopicsSemanaTopics { get; set; }

    }
}
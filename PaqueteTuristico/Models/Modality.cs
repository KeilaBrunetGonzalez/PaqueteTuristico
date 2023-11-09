﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Modality")]
    public class Modality
    {
        public Modality() {
            this.Transports = new HashSet<Transport>(); 
        }
        [Key]
        public virtual int ModalityId { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEscuelaMVC.Models
{
    public class Aula
    {
        [Required]
        [Key]
        public string AulaId { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]  
        public string Estado { get; set; }

    }
}
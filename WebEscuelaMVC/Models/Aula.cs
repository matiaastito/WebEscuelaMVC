using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebEscuelaMVC.Validations;

namespace WebEscuelaMVC.Models
{
    public class Aula
    {
        [Key]
        public int AulaId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [CheckValidAula]
        public int Numero { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]  
        public string Estado { get; set; }

    }
}
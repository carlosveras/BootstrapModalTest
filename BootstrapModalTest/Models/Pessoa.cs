using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootstrapModalTest.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobre Nome")]
        public string SobreNome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xSoftBackend.Models
{
    public class Grad
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
    }
}

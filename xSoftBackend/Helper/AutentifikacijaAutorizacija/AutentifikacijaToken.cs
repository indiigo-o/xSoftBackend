using xSoftBackend.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xSoftBackend.ModelsAutentififkacija
{
    public class AutentifikacijaToken
    {
        [Key]
        public int id { get; set; }
        public string vrijednost { get; set; }
        [ForeignKey(nameof(korisnickiNalog))]
        public int korisnickiNalogId { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public DateTime vrijemeEvideniranja { get; set; }
        public string ipAdresa { get; set; }

    }
}

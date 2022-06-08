
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace xSoftBackend.Models
{
    [Table("KorisnickiNalog")]
    public abstract class KorisnickiNalog
    {
       
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public string KorisnickoIme { get; set; }
       
        public string Lozinka { get; set; }

        [JsonIgnore]
        public Korisnik korisnik => this as Korisnik;
               
    }
}

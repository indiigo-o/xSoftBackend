using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace xSoftBackend.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
      
        [ForeignKey(nameof(kategorijaknjige))]
        public int Kategorija_Knjige_id { get; set; }
        public KategorijaKnjige kategorijaknjige { get; set; }
        public string AutorKnjige { get; set; }
        public string GodinaIzdavanja { get; set; }
        public string Jezik { get; set; }
        public string NazivKnjige { get; set; }
        public DateTime DatumObjave { get; set; }
        public string SlikaKnjige { get; set; }
        public string DetaljanOpis { get; set; }
        public string Knjigapdf { get; set; }
    }
}

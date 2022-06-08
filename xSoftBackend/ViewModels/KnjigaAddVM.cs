using Microsoft.AspNetCore.Http;
using System;


namespace xSoftBackend.ViewModels
{
    public class ArtikalAddVM
    {

        public int Kategorija_Knjige_id { get; set; }
        public string NazivKnjige { get; set; }
        public DateTime DatumObjave { get; set; }
        public string DetaljanOpis { get; set; }
        public IFormFile SlikaKnjige { get; set; }
        public string AutorKnjige { get; set; }
        public string GodinaIzdavanja { get; set; }
        public string Jezik { get; set; }
        public IFormFile Knjigapdf { get; set; }


    }
}

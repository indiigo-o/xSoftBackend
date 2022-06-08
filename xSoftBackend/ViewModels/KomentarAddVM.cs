using System;

namespace xSoftBackend.ViewModels
{
    public class KomentarAddVM
    {
        public string Pitanja { get; set; }
        public int artikalID { get; set; }
        public int korisnikID { get; set; }
        public DateTime DatumVrijeme { get; set; }
    }
}

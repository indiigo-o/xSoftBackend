using xSoftBackend.Data;
using xSoftBackend.Models;
using xSoftBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace xSoftBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public KorisnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran) potrebno odobriti komunikaciju izmedju frontenda i backenda da bi ovo raidlo
            //    return Forbid("poruka");
            return Ok(_dbContext.Korisnici.Include(g=>g.grad).FirstOrDefault(s => s.Id == id));
        }

        //add
        [HttpPost]
        public Korisnik Add([FromBody] KorisniciAddVM x)
        {

            //Provjera da li je korisnik logiran, ako je logiran moci ce dodavati nove ako nije vratit ce se null
            //ova provjera nesto ne radi dobro pa  treba popraviti 

            //   KorisnickiNalog korisnickinalog = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnickinalog == null)
            //    return null;
            
            var novikorisnik = new Korisnik()
            {
                
                Ime = x.ime,
                Prezime = x.prezime,
                Email = x.email,
                DatumRodjenja = x.dtumRodjenja,
                Adresa = x.adresa,
                KorisnickoIme = x.korisnickoime,
                Lozinka = x.lozinka,
                Grad_id = x.grad_id,
                Spol_id = x.spol_id,
               
            };
           
            _dbContext.Add(novikorisnik);
            _dbContext.SaveChanges();
            return novikorisnik;
        }

        [HttpGet]
        public  ActionResult<List<Korisnik>> GetAll2()
        {



            var country =  _dbContext.Korisnici.Include(i => i.grad).Include(i=>i.spol).ToList();
            return country;

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
  
            Korisnik korisnik = _dbContext.Korisnici.Find(id);

            if (korisnik == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(korisnik);
            _dbContext.SaveChanges();
            return Ok(korisnik);
        }
    }
}

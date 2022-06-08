using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using xSoftBackend.Data;
using xSoftBackend.Helper.AutentifikacijaAutorizacija;
using xSoftBackend.Models;
using xSoftBackend.ModelsAutentififkacija;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using static FIT_Api_Examples.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace xSoftBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AutentifikacijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AutentifikacijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {

            //1.provjera logina
            KorisnickiNalog logiraniKorisnik = _dbContext.KorisnickiNalog
                .FirstOrDefault(k => k.KorisnickoIme != null && k.KorisnickoIme == x.korisnickoIme && k.Lozinka == x.lozinka);


            if(logiraniKorisnik == null)
            {
                return null;
            }

            string randomString = TokenGenerator.Generate(10);
            var noviToken = new AutentifikacijaToken()
            {
                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvideniranja = DateTime.Now
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok("Bio je null");

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok("Uspjesno");
        }
        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }


    }
}

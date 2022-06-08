using xSoftBackend.Data;
using xSoftBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using xSoftBackend.ViewModels;

namespace xSoftBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KnjigaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        
        private IHttpContextAccessor httpContextAccessor;

        public KnjigaController(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment, IHttpContextAccessor _httpContextAccessor)
        {
            this._dbContext = dbContext;
            webHostEnvironment = hostEnvironment;
            httpContextAccessor = _httpContextAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Knjiga.Include(kp => kp.kategorijaknjige)
               .FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public Knjiga Add([FromForm] ArtikalAddVM x)
        {
            
            var noviArtikal = new Knjiga()
            {
                Kategorija_Knjige_id = x.Kategorija_Knjige_id,
                NazivKnjige = x.NazivKnjige,
                DetaljanOpis = x.DetaljanOpis,
                DatumObjave = x.DatumObjave,
                AutorKnjige=x.AutorKnjige,
                GodinaIzdavanja=x.GodinaIzdavanja,
                Jezik=x.Jezik,
            };

            var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" +
                  httpContextAccessor.HttpContext.Request.Host +
                  httpContextAccessor.HttpContext.Request.PathBase;
            if (x.SlikaKnjige != null)
            {
                string ekstenzija = Path.GetExtension(x.SlikaKnjige.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.SlikaKnjige.CopyTo(new FileStream("wwwroot/" + "uploads/" + filename, FileMode.Create));
                noviArtikal.SlikaKnjige = "https://localhost:44308/" + "uploads/" + filename;
            }
            if (x.Knjigapdf != null)
            {
                string ekstenzija = Path.GetExtension(x.Knjigapdf.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.Knjigapdf.CopyTo(new FileStream("wwwroot/" + "uploads/" + filename, FileMode.Create));
                noviArtikal.Knjigapdf = "https://localhost:44308/" + "uploads/" + filename;
            }
            _dbContext.Knjiga.Add(noviArtikal);
            _dbContext.SaveChanges();
            return noviArtikal;
        }

        [HttpGet]
        public ActionResult<List<Knjiga>> GetAll()
        {

            var data = _dbContext.Knjiga.Include(kp => kp.kategorijaknjige).ToList();
            return data;

        }
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {


            Knjiga artikal = _dbContext.Knjiga.Find(id);
            if (artikal == null)
             return BadRequest("Pogresan ID");
            _dbContext.Remove(artikal);
            _dbContext.SaveChanges();
            return Ok(artikal);
        }
        [HttpGet("{id}")]
        public IActionResult GetPoKategoriji(int id)
        {
            return Ok(_dbContext.Knjiga.Include(kp => kp.kategorijaknjige).Where(kp => kp.Kategorija_Knjige_id == id));
        }
    }
}

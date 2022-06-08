using xSoftBackend.Data;
using Microsoft.AspNetCore.Mvc;
using xSoftBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using xSoftBackend.Models;

namespace xSoftBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KategorijaKnjigeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KategorijaKnjigeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.KategorijaKnjige.FirstOrDefault(s => s.Id == id));
        }


      
        //add
        [HttpPost]
        public KategorijaKnjige Add([FromBody] KategorijaknjigeAddVM x)
        {

            var novaKategorija = new KategorijaKnjige()
            {
                Ime = x.Ime,

            };
            _dbContext.Add(novaKategorija);
            _dbContext.SaveChanges();
            return novaKategorija;
        }

        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] KategorijaknjigeAddVM x)
        {


            KategorijaKnjige katetgorija = _dbContext.KategorijaKnjige.FirstOrDefault(s => s.Id == id);

            if (katetgorija == null)
                return BadRequest("Pogresan ID");

            katetgorija.Ime = x.Ime;

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<KategorijaKnjige>> GetAll(string Naziv)
        {

            var data = _dbContext.KategorijaKnjige.Where(x => Naziv == null || (x.Ime)
            .StartsWith(Naziv))
                .OrderByDescending(s => s.Ime).ThenByDescending(s => s.Ime)
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            KategorijaKnjige kategorija = _dbContext.KategorijaKnjige.Find(id);

            if (kategorija == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(kategorija);
            _dbContext.SaveChanges();
            return Ok(kategorija);
        }
    }
}

﻿using xSoftBackend.Data;
using xSoftBackend.Models;
using xSoftBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace xSoftBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SpolController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SpolController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Spol.FirstOrDefault(s => s.Id == id));
        }


       
        //add
        [HttpPost]
        public Spol Add([FromBody] SpolAddVM x)
        {

            var noviSpol = new Spol()
            {
                Ime = x.Ime,

            };
            _dbContext.Add(noviSpol);
            _dbContext.SaveChanges();
            return noviSpol;
        }

        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] SpolAddVM x)
        {


            Spol spol = _dbContext.Spol.FirstOrDefault(s => s.Id == id);

            if (spol == null)
                return BadRequest("Pogresan ID");

            spol.Ime = x.Ime;

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<Spol>> GetAll()
        {

            var data = _dbContext.Spol
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Spol spol = _dbContext.Spol.Find(id);

            if (spol == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(spol);
            _dbContext.SaveChanges();
            return Ok(spol);
        }
    }
}

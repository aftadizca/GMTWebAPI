using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helper;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MaterialController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly ILogger _logger;

        public MaterialController(DatabaseContext db, ILogger<MaterialController> logger)
        {
            _db = db;
            _logger = logger;
            if(_db.Materials.Count() == 0)
            {
                var IdGen = new IdGen();
                var count = 0;
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SUPRACOR", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 1", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "DUS JDO 3", Suplier = "SURINDO", Unit = "pcs", Type = "dus" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "SEAL JDO 5", Suplier = "AMCOR", Unit = "roll", Type = "seal" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "SEAL JDO 7", Suplier = "AMCOR", Unit = "roll", Type = "seal" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "SEAL JDO 9", Suplier = "AMCOR", Unit = "roll", Type = "seal" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "SEAL JBC 4", Suplier = "AMCOR", Unit = "roll", Type = "seal" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "SEAL JBC 8", Suplier = "AMCOR", Unit = "roll", Type = "seal" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3000", ++count), Name = "SEAL JBC 9", Suplier = "AMCOR", Unit = "roll", Type = "seal" });
                _db.SaveChanges();
                _logger.LogInformation("Created new mock material");
            }
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  ActionResult<Material> GetAll()
        {
            var item = _db.Materials.Where(x => x.IsActive == true);
            return Ok(item);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public  ActionResult<Material> GetById(string id)
        {
            var result = _db.Materials.FirstOrDefault(x => x.Id == id && x.IsActive == true);
            if (result == null)
            {
                return NotFound(new { Error = "Material ID not found" });
            }
            return  Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(typeof(Material), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Material>> Post([FromBody] Material material)
        {
            if (_db.Materials.Find(material.Id) != null)
            {
                return BadRequest(new { Error = "Material ID has been used!" });
            }
            _db.Materials.Add(material);
            await _db.SaveChangesAsync();
            return CreatedAtAction (nameof(GetById), new{id = material.Id }, material);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Material material)
        {
            var result =_db.Materials.First(x=>x.Id == id);
            if(result != null && material.Id == id)
            {                                                            
                result.Name = material.Name;
                result.Suplier = material.Suplier;
                result.Unit = material.Unit;
                result.Type = material.Type;
                _db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(string id)
        {
            var result = _db.Materials.First(x=> x.Id.Equals(id));
            if (result != null)
            {
                _db.Materials.Remove(result);
                _db.SaveChanges();
                Request.Headers.Add("msg", "Material deleted!");
                return Ok();
            }  
            
            return BadRequest();
            
        }
    }
}
                                                    
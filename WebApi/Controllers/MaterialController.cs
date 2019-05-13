using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Helper;
using WebApi.IRepository;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IGMTRepository<Material> _materialRepo;
        private readonly ILogger _logger;

        public MaterialController(DatabaseContext db, ILogger<MaterialController> logger, IGMTRepository<Material> materialRepo)
        {
            _db = db;
            _materialRepo = materialRepo;

            _logger = logger;
            if (_db.Materials.Count() == 0)
            {
                var count = _db.Materials.Count();
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3", count), Name = "DUS JDO 1", Suplier = "SUPRACOR", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3", ++count), Name = "DUS JDO 3", Suplier = "SUPRACOR", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3", ++count), Name = "DUS JDO 7", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3", ++count), Name = "DUS JDO 9", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { Id = IdGen.CreateId("3", ++count), Name = "SEAL JDO 3", Suplier = "SURINDO", Unit = "ROLL", Type = "SEAL" });
                _db.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(typeof(Material), StatusCodes.Status200OK)]
        public ActionResult<Material> Get()
        {
            return Ok(_db.Materials.ToList());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Material> Get(string id)
        {
            var result = _db.Materials.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound(new { Error = "Material ID not found" });
            }
            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(typeof(Material), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Material>> Post([FromBody] Material material)
        {
            if (_db.Materials.Any(m => m.Name.ToLower() == material.Name.ToLower() && m.Suplier.ToLower() == material.Suplier.ToLower() && m.IsDeleted == false))
            {
                return BadRequest(new { Error = "Material already exists!" });
            }
            material.Id = IdGen.CreateId("3", _db.Materials.Count() + 1);
            _db.Materials.Add(material);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = material.Id }, material);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Material), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(string id, [FromBody]Material material)
        {
            var result = _db.Materials.First(x => x.Id == id);
            if (result != null && material.Id == id)
            {
                result.Name = material.Name;
                result.Suplier = material.Suplier;
                result.Unit = material.Unit;
                result.Type = material.Type;
                result.ModifiedDate = DateTime.Now;
                _db.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("ID didn't match!!");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutDelete([FromBody]List<Material> materials)
        {
            if (!_materialRepo.Delete(materials))
            {
                return NotFound("Id not found!");
            }
            try
            {
                await _materialRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Item not deleted");
            }

            return NoContent();
        }

        //// DELETE api/<controller>/5
        //[HttpDelete]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult Delete([FromBody]List<Material> materials)
        //{
        //    foreach(var material in materials)
        //    {
        //        var result = _db.Materials.FirstOrDefault(x => x.Id.Equals(material.Id));
        //        if (result == null)
        //        {
        //            return NotFound(new { Error = "Material ID not found" });
                    
        //        }
        //        result.IsDeleted = true;
        //    }
        //    _db.SaveChanges();
        //    return Ok();
        //}

        private bool MaterialExists(string id)
        {
            return _db.Materials.Any(e => e.Id == id);
        }
    }
}

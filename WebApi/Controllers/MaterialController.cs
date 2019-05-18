using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helper;
using WebApi.IRepository;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IGMTRepository<Material> _materialRepo;

        public MaterialController(DatabaseContext db, IGMTRepository<Material> materialRepo)
        {
            _db = db;
            _materialRepo = materialRepo;

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
            return Ok(_materialRepo.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Material>> Get(string id)
        {
            var result = await _materialRepo.Get(id);
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
                return BadRequest("Material with current Name & Suplier already exists!");
            }
            material.Id = IdGen.CreateId("3", _db.Materials.Count());
            _db.Materials.Add(material);
            await _materialRepo.Save();
            return CreatedAtAction(nameof(Get), new { id = material.Id }, material);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [ProducesResponseType(typeof(Material), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody]Material material)
        {
            if (_materialRepo.Put(material))
            {
                try
                {
                    await _materialRepo.Save();
                }
                catch (System.Exception)
                {
                    return BadRequest("Item not deleted");
                }
                return Ok(material);
            }

            return NotFound("Id didn't match!!");
            
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody]List<Material> materials)
        {
            if (!_materialRepo.Delete(materials))
            {
                return NotFound("Id not found!");
            }

            try
            {
                await _materialRepo.Save();
            }
            catch (System.Exception)
            {
                return BadRequest("Item not deleted");
            }

            return NoContent();
        }
    }
}

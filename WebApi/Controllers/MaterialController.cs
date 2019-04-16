using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helper;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly ILogger _logger;

        public MaterialController(DatabaseContext db, ILogger<MaterialController> logger)
        {
            _db = db;
            _logger = logger;
            if (_db.Materials.Count() == 0)
            {
                var count = 0;
                _db.Materials.Add(new Material { ID = IdGen.CreateId("3", ++count), Name = "DUS JDO 1", Suplier = "SUPRACOR", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { ID = IdGen.CreateId("3", ++count), Name = "DUS JDO 3", Suplier = "SUPRACOR", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { ID = IdGen.CreateId("3", ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { ID = IdGen.CreateId("3", ++count), Name = "DUS JDO 7", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { ID = IdGen.CreateId("3", ++count), Name = "DUS JDO 9", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" });
                _db.Materials.Add(new Material { ID = IdGen.CreateId("3", ++count), Name = "SEAL JDO 3", Suplier = "SURINDO", Unit = "ROLL", Type = "SEAL" });
                _db.SaveChanges();
                _logger.LogInformation("Created new mock material");
            }
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(typeof(Material),StatusCodes.Status200OK)]
        public ActionResult<Material> Get()
        {
            var item = _db.Materials.Where(x => x.IsActive == true);
            return Ok(item);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Material> Get(string id)
        {
            var result = _db.Materials.FirstOrDefault(x => x.ID == id && x.IsActive == true);
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
            _logger.LogDebug(material.Name);
            if (_db.Materials.Where(m=>m.Name.ToLower() == material.Name.ToLower() && m.Suplier.ToLower() == material.Suplier.ToLower()).Count()>0)
            {
                return BadRequest(new { Error = "Material already exists!"});
            }
            material.ID = IdGen.CreateId("3", _db.Materials.Count()+1);
            _db.Materials.Add(material);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = material.ID }, material);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Material),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(string id, [FromBody]Material material)
        {
            var result = _db.Materials.First(x => x.ID == id);
            if (result != null && material.ID == id)
            {
                result.Name = material.Name;
                result.Suplier = material.Suplier;
                result.Unit = material.Unit;
                result.Type = material.Type;
                result.ModifiedDate = DateTime.Now;
                _db.SaveChangesAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string id)
        {
            var result = _db.Materials.FirstOrDefault(x => x.ID.Equals(id));
            if (result != null)
            {
                result.IsActive = false;
                _db.SaveChanges();
                return Ok();
            }

            return NotFound(new { Error = "Material ID not found" });

        }
    }
}

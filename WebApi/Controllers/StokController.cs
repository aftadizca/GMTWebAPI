
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.CostumModel;
using WebApi.Helper;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StokController(DatabaseContext context)
        {
            _context = context;
            if (!_context.Stoks.Any())
            {
                int i = 0;
                _context.AddRangeAsync(
                    new Stok { Id = IdGen.CreateId("TRC", i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", LocationID = "1", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000003", LocationID = "2", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", LocationID = "3", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", LocationID = "4", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000004", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId("TRC", ++i), MaterialID = "30000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 }
                );
                _context.SaveChanges();
            }
        }

        // GET: api/Stok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stok>>> GetStoks()
        {
            return await _context.Stoks.ToListAsync();
        }

        // GET: api/Stok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stok>> GetStok(string id)
        {
            var stok = await _context.Stoks.FindAsync(id);

            if (stok == null)
            {
                return NotFound();
            }

            return stok;
        }

        // PUT: api/Stok/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutStok([FromBody] List<Stok> stoks)
        {
            foreach (var stok in stoks)
            {
                _context.Entry(stok).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach (var stok in stoks)
                {
                    if (!StokExists(stok.Id))
                    {
                        return NotFound("Id didn't match!");
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // POST: api/Stok
        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(List<Stok>),StatusCodes.Status201Created)]
        public async Task<ActionResult<NewStok>> PostStok(NewStok newStok)
        {
            List<Stok> stok = new List<Stok>();
            if (newStok.Qty <= newStok.Pallet)
            {
                stok.Add(new Stok {Id=IdGen.CreateId("TRC",_context.Stoks.Count()+1), Lot = newStok.Lot, ExpiredDate = newStok.ExpiredDate, MaterialID = newStok.MaterialID, QTY = newStok.Qty });
                _context.Stoks.Add(stok[0]);
            }else if(newStok.Qty > newStok.Pallet)
            {
                int stokCount = newStok.Qty / newStok.Pallet;
                int sisa = newStok.Qty % newStok.Pallet;
                for(int i =1; i <= stokCount; i++)
                {
                    stok.Add(new Stok { Id = IdGen.CreateId("TRC", _context.Stoks.Count() + i), Lot = newStok.Lot, ExpiredDate = newStok.ExpiredDate, MaterialID = newStok.MaterialID, QTY = newStok.Pallet });
                }
                if (sisa != 0)
                {
                    stok.Add(new Stok { Id = IdGen.CreateId("TRC", _context.Stoks.Count()+stokCount + 1), Lot = newStok.Lot, ExpiredDate = newStok.ExpiredDate, MaterialID = newStok.MaterialID, QTY = sisa });
                }

            }
            else
            {
                return BadRequest();
            }
            _context.Stoks.AddRange(stok);
            await _context.SaveChangesAsync();

            return StatusCode(201, stok);
        }

        // DELETE: api/Stok/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stok>> DeleteStok(string id)
        {
            var stok = await _context.Stoks.FindAsync(id);
            if (stok == null)
            {
                return NotFound();
            }

            _context.Stoks.Remove(stok);
            await _context.SaveChangesAsync();

            return stok;
        }

        private bool StokExists(string id)
        {
            return _context.Stoks.Any(e => e.Id == id);
        }
    }
}

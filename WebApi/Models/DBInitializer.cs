using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helper;

namespace WebApi.Models
{
    public static class DBInitializer
    {
        public static void Initialize(DatabaseContext db)
        {

            if (!db.Materials.Any())
            {
                var count = db.Materials.Count();
                db.AddRange(
                    new Material { Id = IdGen.CreateId(IdGen.MATERIAL_PREFIX, count), Name = "DUS JDO 1", Suplier = "SUPRACOR", Unit = "PCS", Type = "DUS" },
                    new Material { Id = IdGen.CreateId(IdGen.MATERIAL_PREFIX, ++count), Name = "DUS JDO 3", Suplier = "SUPRACOR", Unit = "PCS", Type = "DUS" },
                    new Material { Id = IdGen.CreateId(IdGen.MATERIAL_PREFIX, ++count), Name = "DUS JDO 5", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" },
                    new Material { Id = IdGen.CreateId(IdGen.MATERIAL_PREFIX, ++count), Name = "CUP JDO 9", Suplier = "SURINDO", Unit = "PCS", Type = "CUP" },
                    new Material { Id = IdGen.CreateId(IdGen.MATERIAL_PREFIX, ++count), Name = "DUS JDO 7", Suplier = "SURINDO", Unit = "PCS", Type = "DUS" },
                    new Material { Id = IdGen.CreateId(IdGen.MATERIAL_PREFIX, ++count), Name = "SEAL JDO 3", Suplier = "SURINDO", Unit = "ROLL", Type = "SEAL" }
                    );
            }

            if (!db.Locations.Any())
            {
                int c = -1;
                for (int i = 1; i < 26; i++)
                {
                    for (int j = 1; j < 15; j++)
                    {
                        db.Locations.Add(new Location { Id = IdGen.CreateId(++c), Name = $"A{String.Format("{0:00}", i)}A{String.Format("{0:00}", j)}" });
                        db.Locations.Add(new Location { Id = IdGen.CreateId(++c), Name = $"A{String.Format("{0:00}", i)}B{String.Format("{0:00}", j)}" });
                    }
                }
            }

            if (!db.StatusQCs.Any())
            {
                db.StatusQCs.Add(new StatusQC { Id = "1", Name = "UNAPPROVE" });
                db.StatusQCs.Add(new StatusQC { Id = "2", Name = "PASS" });
                db.StatusQCs.Add(new StatusQC { Id = "3", Name = "QUARANTINE" });
                db.StatusQCs.Add(new StatusQC { Id = "4", Name = "BLOCK" });
            }

            if (!db.MaterialOuts.Any())
            {
                int i = 0;
                db.MaterialOuts.AddRange(
                    new MaterialOut { Id = IdGen.CreateId(IdGen.OUT_PREFIX, i), ReceiverDepartement = "Produksi", ReceiverName = "Afta" }
                    );
            }

            if (!db.StokMaterialOut.Any())
            {
                db.StokMaterialOut.AddRange(
                    new StokMaterialOut { Id = "OUT0000001", StokID = "ST0000002" },
                    new StokMaterialOut { Id = "OUT0000001", StokID = "ST0000003" },
                    new StokMaterialOut { Id = "OUT0000001", StokID = "ST0000004" },
                    new StokMaterialOut { Id = "OUT0000001", StokID = "ST0000005" }
                    );
            }

            if (!db.Stoks.Any())
            {
                int i = 0;
                db.AddRangeAsync(
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "1", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400, IsOut=true},
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000003", LocationID = "2", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400, IsOut = true },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "3", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400, IsOut = true },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "4", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400, IsOut = true },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "5", ComingDate = DateTime.Now.AddMonths(-1), ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "6", ComingDate = DateTime.Now.AddMonths(-1), ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "7", ComingDate = DateTime.Now.AddMonths(-1), ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "8", ComingDate = DateTime.Now.AddMonths(-1), ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", LocationID = "9", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000003", LocationID = "10", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000003", LocationID = "11", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "2", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000002", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000004", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000006", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000005", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000004", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000004", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000003", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000001", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 },
                    new Stok { Id = IdGen.CreateId(IdGen.STOK_PREFIX, ++i), MaterialID = "MT0000005", ComingDate = DateTime.Now, ExpiredDate = DateTime.Now.AddYears(2), Lot = "1235545", StatusQCID = "1", QTY = 1400 }
                );


                db.SaveChanges();
            }

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300027.Models;

namespace MahasiswaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "apsril", Nim = "1302000001" },
        };

        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<List<Mahasiswa>> GetAllMahasiswa()
        {
            return mahasiswaList;
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }
            return mahasiswaList[index];
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswaBaru)
        {
            mahasiswaList.Add(mahasiswaBaru);
            return Ok();
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }

            mahasiswaList.RemoveAt(index);
            return Ok();
        }
    }
}

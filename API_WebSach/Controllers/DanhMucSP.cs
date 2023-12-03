using API_WebSach.EntityView;
using API_WebSach.Models;
using API_WebSach.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucSP : ControllerBase
    {
        private readonly NxbKimDongContext db;
        public DanhMucSP(NxbKimDongContext _db)
        {
            db = _db;
        }
        [HttpPost]
        public IActionResult Add(DanhMucModel dm)
        {
            var _dm   = new DanhMucSp
            {
                Name = dm.Name
            };
            db.DanhMucSps.Add(_dm);
            db.SaveChanges();
            return Ok();

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dm = db.DanhMucSps.ToList();
            return Ok(dm);
        }

        [HttpGet("id")]
        public IActionResult GetByID(int id)
        {
            var _dm = db.DanhMucSps.Find(id);
            if(_dm != null)
            {
                return Ok(_dm);
            }
            return NotFound();
        }

        [HttpPut("id")]
        public IActionResult Update(int id, DanhMucModel dm)
        {
            var _dm = db.DanhMucSps.Find(id);
            if(_dm != null)
            {
                _dm.Name = dm.Name;
                db.SaveChanges();
            }
            return NotFound();

        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var _dm = db.DanhMucSps.Find(id);
            if (_dm != null)
            {
                db.DanhMucSps.Remove(_dm);
                db.SaveChanges();
            }
            return NotFound();
        }







    }
}

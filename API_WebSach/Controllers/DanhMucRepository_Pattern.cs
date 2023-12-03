using API_WebSach.EntityView;
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
    public class DanhMucRepository_Pattern : ControllerBase
    {
        private readonly IDanhMucRepository db;
        public DanhMucRepository_Pattern(IDanhMucRepository _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(db.GetAllDM());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(db.GetByID(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("id")]
        public IActionResult Update(int id, DanhMucView dm)
        {
            if (id != dm.MaDM)
            {
                return BadRequest();
            }
            try
            {
                db.Update(dm);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
















    }
}

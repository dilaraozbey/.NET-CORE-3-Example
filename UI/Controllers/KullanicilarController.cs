using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        private IKullaniciService _kullaniciService;
        public KullanicilarController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;

        }
        [HttpGet(template:"getall")]
        public IActionResult GetList()
        {
            var Result = _kullaniciService.GetList();
            if (Result.Success)
            {
                return Ok(Result.Data);
            }
            return BadRequest(Result.Message);
        }
        [HttpGet(template: "Getbyid")]
        public IActionResult GetById(int id)
        {
            var Result = _kullaniciService.GetById(id);
            if (Result.Success)
            {
                return Ok(Result.Data);
            }
            return BadRequest(Result.Message);
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Kullanici kullanici)
        {
            var Result = _kullaniciService.Add(kullanici);
            if (Result.Success)
            {
                return Ok(Result.Message);
            }
            return BadRequest(Result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Kullanici kullanici)
        {
            var Result = _kullaniciService.Delete(kullanici);
            if (Result.Success)
            {
                return Ok(Result.Message);
            }
            return BadRequest(Result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(Kullanici kullanici)
        {
            var Result = _kullaniciService.Update(kullanici);
            if (Result.Success)
            {
                return Ok(Result.Message);
            }
            return BadRequest(Result.Message);
        }
    }
}

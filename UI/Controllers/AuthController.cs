using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authservice;
        public  AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }
        [HttpPost("giris")]
        public ActionResult Giris(KullaniciGirisDto kullaniciGirisDto)
        {
            var kullaniciGirisi = _authservice.Giris(kullaniciGirisDto);
            if (!kullaniciGirisi!.Success)
            {
                return BadRequest(kullaniciGirisi.Message);
            }
           var result= _authservice.CreateAccessToken(kullaniciGirisi.Data);
            if (result.Success)
            {
                return Ok(kullaniciGirisi.Data);
            }
            return BadRequest(result.Message);
        }
        public ActionResult Kaydol(KaydolDto kaydolDto)
        {
            var kullaniciKontrol = _authservice.KullaniciKontrol(kaydolDto.KullaniciAdi);
            if (!kullaniciKontrol.Success)
            {
                return BadRequest(kullaniciKontrol.Message);
            }
            var kaydolResult = _authservice.Kaydol(kaydolDto, kaydolDto.Sifre);
            var result = _authservice.CreateAccessToken(kaydolResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}

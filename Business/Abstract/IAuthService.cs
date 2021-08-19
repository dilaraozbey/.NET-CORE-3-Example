using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Core.Utilities.Security.jwt;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Kullanici> Kaydol(KaydolDto kaydolDto, string sifre);
        IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto);
        IResult KullaniciKontrol(string kullaniciAdi);
        IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);
    }
}

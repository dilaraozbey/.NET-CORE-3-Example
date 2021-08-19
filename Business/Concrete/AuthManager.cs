using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService kullaniciService, ITokenHelper tokenHelper)
        {
            _kullaniciService = kullaniciService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto)
        {
            var KullaniciDenetim = _kullaniciService.GetByUserName(kullaniciGirisDto.KullaniciAdi);
            if (KullaniciDenetim == null)
            {
                return new DataResult<Kullanici>(new Kullanici { }, false, "Kullanici yok");
            }
            if(!HashingHelper.VerifyPasswordHash(kullaniciGirisDto.Sifre,KullaniciDenetim.PasswordHash,KullaniciDenetim.PasswordSalt))
            {
                return new DataResult<Kullanici>(new Kullanici { }, false, "Şifre Hatali ");
            }
            return new DataResult<Kullanici>(new Kullanici { }, false, "Giris Basarili ");
        }

        public IDataResult<Kullanici> Kaydol(KaydolDto kaydolDto, string sifre)
        {
            throw new NotImplementedException();
        }

        public IResult KullaniciKontrol(string kullaniciAdi)
        {
            if (_kullaniciService.GetByUserName(kullaniciAdi) != null)
            {
                return new DataResult<Kullanici>(new Kullanici { }, false, "Giris Kullanici Mevcut ");
            }
            return new DataResult<Kullanici>(new Kullanici { }, false, "Giris Basarili ");
        }
    }
}

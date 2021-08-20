using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
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
            var claims = _kullaniciService.GetRols(kullanici);

            _tokenHelper.CreateToken(kullanici, claims);
            return new DataResult<AccessToken>(new AccessToken (), true, "Giris Basarili ");
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
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(sifre, out passwordHash,out passwordSalt);
            var kullanici = new Kullanici
            {
                Ad = kaydolDto.Ad,
                Soyad = kaydolDto.Soyad,
                KullaniciAdi = kaydolDto.KullaniciAdi,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Durum=true


            };
            _kullaniciService.Add(kullanici);
            return new DataResult<Kullanici>(new Kullanici { }, false, "Kayit Basarili ");
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

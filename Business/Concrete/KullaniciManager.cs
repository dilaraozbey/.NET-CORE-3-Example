using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;

        }
      
        IDataResult<Kullanici> IKullaniciService.GetById(int Id)
        {
            return new SuccesDataResult<Kullanici>(_kullaniciDal.Get(filter: p => p.Id == Id));
        }

       List<Rol> IKullaniciService.GetRols(Kullanici kullanici)
        {
       
            return  _kullaniciDal.GetRols(kullanici);
        }

        IResult IKullaniciService.Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
            return new SuccessResult("Eklendi");
        }

        IResult IKullaniciService.Delete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
            return new SuccessResult("Silindi");
        }

        IResult IKullaniciService.Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
            return new SuccessResult("Güncellendi");
        }

        IDataResult<Kullanici> IKullaniciService.GetByUserName(string username)
        {
            var kullanici = _kullaniciDal.Get(p => p.KullaniciAdi == username);
            if (kullanici != null)
            {
                return new SuccesDataResult<Kullanici>(_kullaniciDal.Get(p => p.KullaniciAdi == username));
            }
            return new ErrorDataResult<Kullanici>(null,"Kullanici Mevcut Değil");
        }

        IDataResult<List<Kullanici>> IKullaniciService.GetList()
        {
            return new SuccesDataResult<List<Kullanici>>(_kullaniciDal.GetList().ToList());
        }
    }
}

using Business.Abstract;
using Core.Entities.Concrete;
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
        public IKullaniciDal Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
            return _kullaniciDal;
        }

        public IKullaniciDal Delete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
            return _kullaniciDal;
        }
       

        public IKullaniciDal Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
            return _kullaniciDal;
        }
        public Kullanici GetById(int Id)
        {
            return _kullaniciDal.Get(filter: p => p.Id == Id);
        }

        public List<Rol> GetRols(Kullanici kullanici)
        {
            return _kullaniciDal.GetRols(kullanici);
        }

        public Kullanici GetByUserName(string username)
        {
            return _kullaniciDal.Get(p => p.KullaniciAdi == username);
        }

        public List<Kullanici> GetList()
        {
            return (List<Kullanici>)_kullaniciDal.GetList();
        }
    }
}

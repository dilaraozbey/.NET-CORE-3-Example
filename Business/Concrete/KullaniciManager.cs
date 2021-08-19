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
        public void Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public void Delete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
        }
       

        public void Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
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
            return _kullaniciDal.Get(filter: p => p.KullaniciAdi == username);
        }
    }
}

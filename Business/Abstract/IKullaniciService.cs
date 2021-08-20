

using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface IKullaniciService
    {
        public Kullanici GetById(int Id);
        public List<Rol> GetRols(Kullanici kullanici);
        public IKullaniciDal Add(Kullanici kullanici);
        public IKullaniciDal Delete(Kullanici kullanici);
        public IKullaniciDal Update(Kullanici kullanici);
        public Kullanici GetByUserName(string username);
        public List<Kullanici> GetList();

    }
}

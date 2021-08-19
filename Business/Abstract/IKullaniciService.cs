

using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface IKullaniciService
    {
        public Kullanici GetById(int Id);
        public List<Rol> GetRols(Kullanici kullanici);
        public void Add(Kullanici kullanici);
        public void Delete(Kullanici kullanici);
        public void Update(Kullanici kullanici);
        public Kullanici GetByUserName(string username);
        object GetList();
    }
}

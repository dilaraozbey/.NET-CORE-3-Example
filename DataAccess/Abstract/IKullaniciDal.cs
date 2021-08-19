using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Abstract
{
    public interface IKullaniciDal : IEntityRepository<Kullanici>
    {
        List<Rol> GetRols(Kullanici kullanici);
    }
}

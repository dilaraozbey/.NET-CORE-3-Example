using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRespositoryBase<Kullanici, UygulamaContext>, IKullaniciDal
    {

        //db işlemi oldugu için burda yaptıı aslında IKullaniciDalda tanımladık 
       public List<Rol> GetRols(Kullanici kullanici)
        {
            using (var context = new UygulamaContext())
            {

                var result = from r in context.Rol
                             join k in context.Kullanici_Rol
                             on r.Id equals k.RolId
                             where k.KullaniciId == kullanici.Id
                             select new Rol
                             {
                                 Id = r.Id,
                                 RolAdi = r.RolAdi
                             };


                return result.ToList();
            }
        } 
    }

}

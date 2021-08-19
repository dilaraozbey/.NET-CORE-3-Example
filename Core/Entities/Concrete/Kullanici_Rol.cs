using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class Kullanici_Rol:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int RolId { get; set; }
        

    }
}

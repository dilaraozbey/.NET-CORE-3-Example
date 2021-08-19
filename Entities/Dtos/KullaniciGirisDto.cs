using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
  public  class KullaniciGirisDto:IDto
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}

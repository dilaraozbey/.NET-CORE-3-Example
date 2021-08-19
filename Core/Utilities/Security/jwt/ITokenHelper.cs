using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.jwt
{
    public interface ITokenHelper
    {
        //katmanlar arasında iletişim sorunu var
        //core entityi referans alamaz o yüzden gerekli tablolar core içine taşındı.
        AccessToken CreateToken(Kullanici kullanici,List<Rol> Roller);
    }
}

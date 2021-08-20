

using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface IKullaniciService
    {
        public IDataResult<Kullanici>  GetById(int Id);
        public List<Rol> GetRols(Kullanici kullanici);
        public IResult Add(Kullanici kullanici);
        public IResult Delete(Kullanici kullanici);
        public IResult Update(Kullanici kullanici);
        public IDataResult<Kullanici> GetByUserName(string username);
        public IDataResult<List<Kullanici>> GetList();

    }
}

using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module   
    {
        //conf yapılan yer
        protected override void Load(ContainerBuilder builder)
        {
            // eğer birisi IkullaniciService cağrırırsa ona KullaniciManager de temin edilir
            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            // eğer birisi IKullaniciDal cağrırırsa ona EfKullaniciDal de temin edilir
            builder.RegisterType<EfKullaniciDal>().As<IKullaniciDal>();

        }
    }
}

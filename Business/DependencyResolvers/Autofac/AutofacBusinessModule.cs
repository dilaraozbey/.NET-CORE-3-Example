using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        }
    }
}

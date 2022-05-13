using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Converter;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Business Service -Manager
            builder.RegisterType<HouseManager>().As<IHouseService>().SingleInstance();
            builder.RegisterType<HouseImageUrlManager>().As<IHouseImageUrlService>().SingleInstance();
            builder.RegisterType<LandManager>().As<ILandService>().SingleInstance();
            builder.RegisterType<LandImageUrlManager>().As<ILandImageUrlService>().SingleInstance();
            builder.RegisterType<WorkPlaceManager>().As<IWorkPlaceService>().SingleInstance();
            builder.RegisterType<WorkPlaceImageUrlManager>().As<IWorkPlaceImageUrlService>().SingleInstance();
            builder.RegisterType<LocationManager>().As<ILocationService>().SingleInstance();
            builder.RegisterType<SalesCategoryManager>().As<ISalesCategoryService>().SingleInstance();
            builder.RegisterType<SalesTypeManager>().As<ISalesTypeService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();


            // Business Converter
            builder.RegisterType<HouseConverter>().As<IHouseConverter>().SingleInstance();
            builder.RegisterType<LandConverter>().As<ILandConverter>().SingleInstance();
            builder.RegisterType<LocationConverter>().As<ILocationConverter>().SingleInstance();
            builder.RegisterType<SalesTypeConverter>().As<ISalesTypeConverter>().SingleInstance();
            builder.RegisterType<SalesCategoryConverter>().As<ISalesCategoryConverter>().SingleInstance();
            builder.RegisterType<UserConverter>().As<IUserConverter>().SingleInstance();
            builder.RegisterType<WorkPlaceConverter>().As<IWorkPlaceConverter>().SingleInstance();

            //DataAccess
            builder.RegisterType<EfHouseDal>().As<IHouseDal>().SingleInstance();
            builder.RegisterType<EfHouseImageUrlDal>().As<IHouseImageUrlDal>().SingleInstance();
            builder.RegisterType<EfLandDal>().As<ILandDal>().SingleInstance();
            builder.RegisterType<EfLandImageUrlDal>().As<ILandImageUrlDal>().SingleInstance();
            builder.RegisterType<EfWorkPlaceDal>().As<IWorkPlaceDal>().SingleInstance();
            builder.RegisterType<EfWorkPlaceImageUrlDal>().As<IWorkPlaceImageUrlDal>().SingleInstance();
            builder.RegisterType<EfLocationDal>().As<ILocationDal>().SingleInstance();
            builder.RegisterType<EfSalesCategoryDal>().As<ISalesCategoryDal>().SingleInstance();
            builder.RegisterType<EfSalesTypeDal>().As<ISalesTypeDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();
            
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

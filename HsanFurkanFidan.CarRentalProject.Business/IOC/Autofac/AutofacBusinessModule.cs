using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using HasanFurkanFidan.CarRentalProject.Core.Utilities.AOP;
using HasanFurkanFidan.CarRentalProject.DataAccess.Abstract;
using HasanFurkanFidan.CarRentalProject.DataAccess.Concrete.EntityFrameworkCore;
using HsanFurkanFidan.CarRentalProject.Business.Abstract;
using HsanFurkanFidan.CarRentalProject.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HsanFurkanFidan.CarRentalProject.Business.IOC.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>();
            builder.RegisterType<ColorRepository>().As<IColorRepository>();
            builder.RegisterType<CarImageRepository>().As<ICarImageRepository>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

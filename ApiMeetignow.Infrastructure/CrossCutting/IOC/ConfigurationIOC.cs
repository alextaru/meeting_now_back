using ApiMeetignow.Application;
using ApiMeetignow.Application.Interfaces;
using ApiMeetignow.Application.Interfaces.Mappers;
using ApiMeetignow.Application.Mappers;
using ApiMeetignow.Domain.Core.Interfaces.Repositorys;
using ApiMeetignow.Domain.Core.Interfaces.Services;
using ApiMeetignow.Domain.Services;
using ApiMeetignow.Infrastructure.Data.Repositorys;
using Autofac;

namespace ApiMeetignow.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceAgenda>().As<IApplicationServiceAgenda>();
            builder.RegisterType<ServiceAgenda>().As<IServiceAgenda>();
            builder.RegisterType<RepositoryAgenda>().As<IRepositoryAgenda>();
            builder.RegisterType<MapperAgenda>().As<IMapperAgenda>();

            #endregion IOC
        }
    }
}

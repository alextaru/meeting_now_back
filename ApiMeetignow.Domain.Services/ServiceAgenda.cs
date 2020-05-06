using System;
using ApiMeetignow.Domain.Core.Interfaces.Repositorys;
using ApiMeetignow.Domain.Core.Interfaces.Services;
using ApiMeetignow.Domain.Entitys;

namespace ApiMeetignow.Domain.Services
{
    public class ServiceAgenda :ServiceBase<Agenda>, IServiceAgenda
    {
        private readonly IRepositoryAgenda repositoryAgenda;

        public ServiceAgenda(IRepositoryAgenda repositoryAgenda) : base(repositoryAgenda)
        {
            this.repositoryAgenda = repositoryAgenda;
        }
    }
}

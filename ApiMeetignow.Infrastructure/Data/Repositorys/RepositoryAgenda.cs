using System;
using ApiMeetignow.Domain.Core.Interfaces.Repositorys;
using ApiMeetignow.Domain.Entitys;

namespace ApiMeetignow.Infrastructure.Data.Repositorys
{
    public class RepositoryAgenda : RepositoryBase<Agenda>, IRepositoryAgenda
    {
        private readonly SqlContext sqlContext;

        public RepositoryAgenda(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}

using System;
using System.Collections.Generic;
using ApiMeetignow.Domain.Core.Interfaces.Repositorys;
using ApiMeetignow.Domain.Core.Interfaces.Services;

namespace ApiMeetignow.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public void Add(T obj)
        {
            repository.Add(obj);
        }

        public List<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(T obj)
        {
            repository.Remove(obj);
        }

        public void Update(T obj)
        {
            repository.Update(obj);
        }
    }
}

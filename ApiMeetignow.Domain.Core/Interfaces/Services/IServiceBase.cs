using System;
using System.Collections.Generic;

namespace ApiMeetignow.Domain.Core.Interfaces.Services
{
    public interface IServiceBase <T> where T : class
    {
        void Add(T obj);

        void Update(T obj);

        void Remove(T obj);

        List<T> GetAll();

        T GetById(int id);
    }
}

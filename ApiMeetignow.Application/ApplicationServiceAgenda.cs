using System;
using System.Collections.Generic;
using ApiMeetignow.Application.Dtos;
using ApiMeetignow.Application.Interfaces;
using ApiMeetignow.Application.Interfaces.Mappers;
using ApiMeetignow.Domain.Core.Interfaces.Services;

namespace ApiMeetignow.Application
{
    public class ApplicationServiceAgenda : IApplicationServiceAgenda
    {
        private readonly IServiceAgenda serviceAgenda;
        private readonly IMapperAgenda mapperAgenda;

        public ApplicationServiceAgenda(IServiceAgenda serviceAgenda,
            IMapperAgenda mapperAgenda)
        {
            this.serviceAgenda = serviceAgenda;
            this.mapperAgenda = mapperAgenda;
        }

        public void Add(AgendaDto agendaDto)
        {
            var agenda = mapperAgenda.MapperDtoToEntity(agendaDto);
            serviceAgenda.Add(agenda);
        }

        public List<AgendaDto> GetAll()
        {
            var agendas = serviceAgenda.GetAll();
            return mapperAgenda.MapperListAgendaDto(agendas);
        }

        public AgendaDto GetById(int id)
        {
            var agenda = serviceAgenda.GetById(id);
            return mapperAgenda.MapperEntityToDto(agenda);
        }

        public void Remove(AgendaDto agendaDto)
        {
            var agenda = mapperAgenda.MapperDtoToEntity(agendaDto);
            serviceAgenda.Remove(agenda);
        }

        public void Update(AgendaDto agendaDto)
        {
            var agenda = mapperAgenda.MapperDtoToEntity(agendaDto);
            serviceAgenda.Update(agenda);
        }
    }
}

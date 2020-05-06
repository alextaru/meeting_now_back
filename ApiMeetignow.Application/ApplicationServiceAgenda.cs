using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Add(AgendaDto agendaDto)
        {
            var result = serviceAgenda.GetAll();
            var agendas = mapperAgenda.MapperListAgendaDto(result).Where(x => x.Sala == agendaDto.Sala);

            bool valido = true;

            foreach (AgendaDto item in agendas){
                int resultInit = DateTime.Compare(agendaDto.DataInit, item.DataInit);
                int resultEnd = DateTime.Compare(agendaDto.DataInit, item.DataEnd);

                if ((resultInit == 0) || (resultInit > 0 && resultEnd < 0))
                {
                    valido = false;
                }

                resultInit = DateTime.Compare(agendaDto.DataEnd, item.DataInit);
                resultEnd = DateTime.Compare(agendaDto.DataEnd, item.DataEnd);

                if (resultEnd == 0 || (resultInit > 0 && resultEnd < 0))
                {
                    valido = false;
                }

                resultInit = DateTime.Compare(agendaDto.DataInit, item.DataInit);
                resultEnd = DateTime.Compare(agendaDto.DataEnd, item.DataEnd);

                if (resultInit < 0 && resultEnd > 0)
                {
                    valido = false;
                }
            }

            if(valido){
                var agenda = mapperAgenda.MapperDtoToEntity(agendaDto);
                serviceAgenda.Add(agenda);
            }

            return valido;
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

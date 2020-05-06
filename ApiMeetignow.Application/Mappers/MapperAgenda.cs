using System;
using System.Collections.Generic;
using System.Linq;
using ApiMeetignow.Application.Dtos;
using ApiMeetignow.Application.Interfaces.Mappers;
using ApiMeetignow.Domain.Entitys;

namespace ApiMeetignow.Application.Mappers
{
    public class MapperAgenda : IMapperAgenda
    {
        public Agenda MapperDtoToEntity(AgendaDto agendaDto)
        {
            var agenda = new Agenda()
            {
                Id = agendaDto.Id.Value,
                Sala = agendaDto.Sala,
                Responsavel = agendaDto.Responsavel,
                Tema = agendaDto.Tema,
                DataInit = agendaDto.DataInit,
                DataEnd = agendaDto.DataEnd
            };

            return agenda;
        }

        public AgendaDto MapperEntityToDto(Agenda agenda)
        {
            var agendaDto = new AgendaDto()
            {
                Id = agenda.Id,
                Sala = agenda.Sala,
                Responsavel = agenda.Responsavel,
                Tema = agenda.Tema,
                DataInit = agenda.DataInit,
                DataEnd = agenda.DataEnd
            };

            return agendaDto;
        }

        public List<AgendaDto> MapperListAgendaDto(List<Agenda> agendas)
        {
            List<AgendaDto> dto = agendas.Select(a => new AgendaDto
            {
                Id = a.Id,
                Sala = a.Sala,
                Responsavel = a.Responsavel,
                Tema = a.Tema,
                DataInit = a.DataInit,
                DataEnd = a.DataEnd
            }).ToList();
            return dto;
        }
    }
}

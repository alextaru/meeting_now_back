using System;
using System.Collections.Generic;
using ApiMeetignow.Application.Dtos;
using ApiMeetignow.Domain.Entitys;

namespace ApiMeetignow.Application.Interfaces.Mappers
{
    public interface IMapperAgenda
    {
        Agenda MapperDtoToEntity(AgendaDto agendaDto);

        List<AgendaDto> MapperListAgendaDto(List<Agenda> agendas);

        AgendaDto MapperEntityToDto(Agenda agenda);
    }
}

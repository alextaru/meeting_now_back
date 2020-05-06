using System;
using System.Collections.Generic;
using ApiMeetignow.Application.Dtos;

namespace ApiMeetignow.Application.Interfaces
{
    public interface IApplicationServiceAgenda
    {
        bool Add(AgendaDto agendaDto);

        void Update(AgendaDto agendaDto);

        void Remove(AgendaDto agendaDto);

        List<AgendaDto> GetAll();

        AgendaDto GetById(int id);
    }
}

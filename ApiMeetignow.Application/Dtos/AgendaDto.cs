using System;
namespace ApiMeetignow.Application.Dtos
{
    public class AgendaDto
    {
        public int? Id { get; set; }
        public int Sala { get; set; }
        public string Tema { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataInit { get; set; }
        public DateTime DataEnd { get; set; }
    }
}

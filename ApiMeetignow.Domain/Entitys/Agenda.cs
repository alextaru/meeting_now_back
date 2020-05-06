using System;
namespace ApiMeetignow.Domain.Entitys
{
    public class Agenda
    {
        public int Id { get; set; }
        public int Sala { get; set; }
        public string Tema { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataInit { get; set; }
        public DateTime DataEnd { get; set; }
    }
}

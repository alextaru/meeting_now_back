﻿using System.ComponentModel.DataAnnotations;

namespace ApiMeetignow.API.Models
{
    public class AgendaModel
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int Sala { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Responsavel { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string DataInit { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string DataEnd { get; set; }
    }
}

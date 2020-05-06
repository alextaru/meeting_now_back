using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApiMeetignow.API.Models;
using ApiMeetignow.Application.Dtos;
using ApiMeetignow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiMeetignow.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {

        private readonly IApplicationServiceAgenda applicationServiceAgenda;

        public AgendaController(IApplicationServiceAgenda applicationServiceAgenda)
        {
            this.applicationServiceAgenda = applicationServiceAgenda;
        }

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(applicationServiceAgenda.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceAgenda.GetById(id));
        }

        [HttpGet("sala/{id}")]
        public ActionResult<string> GetSala(int id)
        {
            return Ok(applicationServiceAgenda.GetAll().Where(x => x.Sala == id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] AgendaModel agendaModel)
        {

            if (ModelState.IsValid) {
                string format = "yyyy-MM-dd HH:mm";
                CultureInfo provider = CultureInfo.InvariantCulture;

                DateTime dataInit = DateTime.ParseExact(agendaModel.DataInit, format, provider);
                DateTime dataEnd = DateTime.ParseExact(agendaModel.DataEnd, format, provider);

                int result = DateTime.Compare(dataEnd, dataInit);
                if (result < 0 || result == 0)
                {
                    return BadRequest("data invalida");
                }
                else
                {
                    AgendaDto agendaDto = new AgendaDto()
                    {
                        Id = 0,
                        Sala = agendaModel.Sala,
                        Responsavel = agendaModel.Responsavel,
                        Tema = agendaModel.Tema,
                        DataInit = dataInit,
                        DataEnd = dataEnd
                    };


                    try
                    {
                        var resultado = applicationServiceAgenda.Add(agendaDto);
                        if(resultado){
                            return Ok(applicationServiceAgenda.GetAll());       
                        }else{
                            return BadRequest("data invalida");
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
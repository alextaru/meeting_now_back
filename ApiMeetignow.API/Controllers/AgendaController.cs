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
                    var agendas = applicationServiceAgenda.GetAll().Where(x => x.Sala == agendaModel.Sala);

                    bool valido = true;

                    foreach (AgendaDto item in agendas)
                    {
                       

                        int resultInit = DateTime.Compare(dataInit, item.DataInit);
                        int resultEnd = DateTime.Compare(dataInit, item.DataEnd);

                        if ((resultInit == 0) || (resultInit > 0 && resultEnd < 0))
                        {
                            valido = false;
                        }

                        resultInit = DateTime.Compare(dataEnd, item.DataInit);
                        resultEnd = DateTime.Compare(dataEnd, item.DataEnd);

                        if (resultEnd == 0 || (resultInit > 0 && resultEnd < 0))
                        {
                            valido = false;
                        }

                        resultInit = DateTime.Compare(dataInit, item.DataInit);
                        resultEnd = DateTime.Compare(dataEnd, item.DataEnd);

                        if (resultInit < 0 && resultEnd > 0)
                        {
                            valido = false;
                        }

                    }
                    if (valido)
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
                            applicationServiceAgenda.Add(agendaDto);
                            return Ok(applicationServiceAgenda.GetAll());
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex);
                        }
                    }
                    else
                    {
                        return BadRequest("data invalida");
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
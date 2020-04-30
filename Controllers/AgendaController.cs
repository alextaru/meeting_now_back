using Microsoft.AspNetCore.Mvc;
using MeetingNow.Model;
using MeetingNow.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Cors;

namespace MeetingNow.Controllers{
    
    [EnableCors("AnotherPolicy")]    
    [ApiController]
    [Route("v1/agenda")]
    public class AgendaController : ControllerBase{

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Agenda>>> Get([FromServices] DataContext context){
            var agenda = await context.Agendas.ToListAsync();
            return agenda;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Agenda>>> Post(
            [FromServices] DataContext context,
            [FromBody] Agenda model
        ){
            if(ModelState.IsValid){

                string format = "yyyy-MM-dd HH:mm";
                CultureInfo provider = CultureInfo.InvariantCulture;
                
                DateTime dataInit = DateTime.ParseExact(model.DataInit, format, provider);
                DateTime dataEnd = DateTime.ParseExact(model.DataEnd, format, provider);


                int result = DateTime.Compare(dataEnd, dataInit);

                if(result < 0 || result == 0){
                    return BadRequest("data invalida");
                }else{

                    var agenda = await context.Agendas.Where(x =>x.Sala == model.Sala).ToListAsync();

                    bool valido = true;

                    foreach (Agenda item in agenda){
                        DateTime init = DateTime.ParseExact(item.DataInit, format, provider);
                        DateTime end = DateTime.ParseExact(item.DataEnd, format, provider);

                        int resultInit = DateTime.Compare(dataInit, init);
                        int resultEnd = DateTime.Compare(dataInit, end);

                        if((resultInit == 0) || (resultInit > 0 && resultEnd < 0) ){
                            valido = false;
                        }

                        resultInit = DateTime.Compare(dataEnd, init);
                        resultEnd = DateTime.Compare(dataEnd, end);

                        if( resultEnd == 0 || (resultInit > 0 && resultEnd < 0) ){
                            valido = false;
                        }

                        resultInit = DateTime.Compare(dataInit, init);
                        resultEnd = DateTime.Compare(dataEnd, end);

                        if( resultInit < 0 && resultEnd > 0 ){
                            valido = false;
                        }
                        
                    }

                    if(valido){
                        context.Agendas.Add(model);
                        await context.SaveChangesAsync();
                        agenda.Add(model);
                        return agenda;  
                    }else{
                        return BadRequest("data invalida");
                    }
                                     
                }
                
            }else{
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Agenda>>> GetBySala([FromServices] DataContext context, int id){
            var agenda = await context.Agendas.Where(x => x.Sala == id).ToListAsync();
            return agenda;
        }
        
    }
}
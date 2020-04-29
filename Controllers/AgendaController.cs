using Microsoft.AspNetCore.Mvc;
using MeetingNow.Model;
using MeetingNow.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeetingNow.Controllers{
    
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
        public async Task<ActionResult<Agenda>> Post(
            [FromServices] DataContext context,
            [FromBody] Agenda model
        ){
            if(ModelState.IsValid){
                context.Agendas.Add(model);
                await context.SaveChangesAsync();
                return model;
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
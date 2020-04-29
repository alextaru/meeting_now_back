using MeetingNow.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetingNow.Data{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options): base(options){

        }

        public DbSet<Agenda> Agendas {get; set;}

    }
}
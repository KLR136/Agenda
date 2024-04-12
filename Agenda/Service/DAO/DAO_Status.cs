using agenda.agendaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Service.DAO
{
    public class DAO_Status
    {
        AgendaContextDB Context;
        public DAO_Status()
        {
            Context = new AgendaContextDB();
        }
        public IEnumerable<StatusDB> GetAllStatus()
        {
            using (var Context = new AgendaContextDB())
            {
                var AllStatus = Context.Statuses.ToList();
                return AllStatus;
            }
        }
        public StatusDB GetStatusbyID(int id) 
        {
            using(var Context = new AgendaContextDB())
            {
                var Status = Context.Statuses.SingleOrDefault(x => x.Id == id);
                return Status;
            }
        }
        public StatusDB GetStatusbyName(string name)
        {
            using ( var Context = new AgendaContextDB())
            {
                var Status = Context.Statuses.SingleOrDefault(x => x.Nom == name);
                return Status;
            }
        }
    }
}

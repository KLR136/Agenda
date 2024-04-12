using agenda.agendaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Service.DAO
{
    public class DAO_Task
    {
        AgendaContextDB Context;
        public DAO_Task()
        {
            Context = new AgendaContextDB();
        }
        public IEnumerable<TaskDB> GetAllTask()
        {
            using (var Context = new AgendaContextDB())
            {
                var AllTasks = Context.Tasks.ToList();
                return AllTasks;
            }
        }
        public TaskDB GetTaskbyID(int id)
        {
            using ( var Context = new AgendaContextDB())
            {
                var Tasks = Context.Tasks.SingleOrDefault(x => x.Id == id);
                return Tasks;
            }
        }
        public List<TaskDB> GetTasksbyName(string name) 
        {
            using (var Context = new AgendaContextDB())
            {
                var Tasks = Context.Tasks.Where(x => x.Nom.StartsWith(name)).ToList();
                return Tasks;
            }
        }
        public List<TaskDB> GetTasksbyCheck(byte Checked) 
        {
            using (var Context = new AgendaContextDB())
            {
                var Tasks = Context.Tasks.Where(task => task.Check != null && task.Check.Length > 0 && task.Check[0] == Checked).ToList();
                return Tasks;
            }
        }
    }
}

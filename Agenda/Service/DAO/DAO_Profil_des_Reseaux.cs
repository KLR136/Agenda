using agenda.agendaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Service.DAO
{
    public class DAO_Reseaux
    {
        AgendaContextDB Context;

        public DAO_Reseaux()
        {
            Context = new AgendaContextDB();
        }

        public IEnumerable<ReseauxSociauxDB> GetAllReseaux()
        {
            using (Context = new AgendaContextDB())
            {
                var AllReseaux = Context.ReseauxSociauxes.ToList();
                return AllReseaux;
            }
        }

        public List<ReseauxSociauxDB> GetReseauxbyID(int id)
        {
            using (var Context = new AgendaContextDB())
            {
                var Reseaux = Context.ReseauxSociauxes.Where(x => x.Id == id).ToList();
                return Reseaux;
            }
        }
        public List<ReseauxSociauxDB> GetReseauxbyName(string Name)
        {
            using (var Context= new AgendaContextDB())
            {
                var Reseaux = Context.ReseauxSociauxes.Where(x => x.Nom.StartsWith(Name)).ToList();
                return Reseaux;
            }
        }
        public void AddReseaux(ReseauxSociauxDB reseaux)
        {
            using (var Context = new AgendaContextDB())
            {
                Context.ReseauxSociauxes.Add(reseaux);
                Context.SaveChanges();
            }
        }
        public void UpdateReseaux(ReseauxSociauxDB reseaux)
        {
            using (var Context = new AgendaContextDB())
            {
                var Reseaux = Context.ReseauxSociauxes.SingleOrDefault(x => x.Id == reseaux.Id);
                Reseaux.Nom = reseaux.Nom;
                Reseaux.Url = reseaux.Url;
                Context.SaveChanges();
            }
        }
        public void DeleteReseaux(int id)
        {
            using (var Context = new AgendaContextDB())
            {
                var Reseaux = Context.ReseauxSociauxes.SingleOrDefault(x => x.Id == id);
                Context.ReseauxSociauxes.Remove(Reseaux);
                Context.SaveChanges();
            }
        }
    }
}

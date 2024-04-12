using agenda.agendaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace agenda.Service.DAO
{
    public class DAO_Contact
    {
        AgendaContextDB Context;

        public DAO_Contact()
        {
            Context = new AgendaContextDB();
        }

        public IEnumerable<ContactDB> GetAllContact()
        {
            using (Context = new AgendaContextDB())
            {
                var AllContact = Context.Contacts.ToList();
                return AllContact;
            }
        }

        public ContactDB GetContactbyID(int id)
        {
            using(Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.SingleOrDefault(x => x.Id == id);
                return Contact;
            }
        }

        public List<ContactDB> GetContactsbyName(string name)
        {
            using (Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.Where(a => a.Nom.StartsWith(name)).ToList();
                return Contact;
            }
        }
        public List<ContactDB> GetContactbyPrenom(string forename)
        {
            using (Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.Where(x => x.Prenom == forename).ToList();
                return Contact;
            }
        }

        public List<ContactDB> GetContactbyGenre(string genre)
        {
            using (var Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.Where(x => x.Genre == genre).ToList();
                return Contact;
            }
        }
        public List<ContactDB> GetContactbyTelephone(string telephone)
        {
            using (var Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.Where(x => x.Telephone.StartsWith(telephone)).ToList();
                return Contact;
            }
        }
        public List<ContactDB> GetContactbyAdresse(string address)
        {
            using (var Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.Where(x => x.Adresse.StartsWith(address)).ToList();
                return Contact;
            }
        }
        public void AddContact(ContactDB contact)
        {
            using (var Context = new AgendaContextDB())
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
            }
        }

        public void DeleteContact(int id)
        {
            using (var Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.SingleOrDefault(x => x.Id == id);
                Context.Contacts.Remove(Contact);
                Context.SaveChanges();
            }
        }

        public void UpdateContact(ContactDB contact)
        {
            using (var Context = new AgendaContextDB())
            {
                var Contact = Context.Contacts.SingleOrDefault(x => x.Id == contact.Id);
                Contact.Nom = contact.Nom;
                Contact.Prenom = contact.Prenom;
                Contact.Anniversaire = contact.Anniversaire;
                Contact.Genre = contact.Genre;
                Contact.Telephone = contact.Telephone;
                Contact.Adresse = contact.Adresse;
                Context.SaveChanges();
            }
        }
    }
}

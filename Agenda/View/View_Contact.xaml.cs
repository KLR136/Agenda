using agenda.agendaDB;
using agenda.Service.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace agenda.View
{
    /// <summary>
    /// Logique d'interaction pour View_Contact.xaml
    /// </summary>
    public partial class View_Contact : UserControl
    {
        DAO_Contact dao_contacts;
        public View_Contact()
        {
            InitializeComponent();
            dao_contacts = new DAO_Contact();
            DG_Contacts.DataContext = dao_contacts.GetAllContact();
        }


        private void Calendrier_Click(object sender, RoutedEventArgs e)
        {
            Grille_Contacts.Children.Clear();
            View_Calendar calendarPage = new View_Calendar();
            Grille_Contacts.Children.Add(calendarPage);
        }

        private void Reseaux_sociaux_Click(object sender, RoutedEventArgs e)
        {
            Grille_Contacts.Children.Clear();
            View_Réseaux view_Reseaux = new View_Réseaux();
            Grille_Contacts.Children.Add(view_Reseaux);
        }


        private void Supprimer_Contact_Click(object sender, RoutedEventArgs e)
        {
            while (DG_Contacts.SelectedItems.Count > 0)
            {
                DG_Contacts.Items.Remove(DG_Contacts.SelectedItems[0]);
            }
        }



        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Grille_Contacts.Children.Clear();
            View_Page_Principale page_Principale = new View_Page_Principale();
            Grille_Contacts.Children.Add(page_Principale);
        }

        private void BTN_AddContact_Click(object sender, RoutedEventArgs e)
        {
            DAO_Contact contact = new DAO_Contact();

            if (TB_Nom.Text != null)
            {
                contact.Nom = TB_Nom.Text;
            }
            if (TB_Prenom.Text != null)
            {
                contact.Prenom = TB_Prenom.Text;
            }
            if (TB_Email.Text != null)
            {
                contact.Mail = TB_Email.Text;
            }
            if (TB_Genre.Text != null)
            {
                contact.Genre = TB_Genre.Text;
            }
            if (TB_Adresse.Text != null)
            {
                contact.Adresse = TB_Adresse.Text;
            }

            if (TB_DateNaissance.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = date.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                contact.Birth = selectedDate;
            }
            DAOContact.addContact(contact);
        }
    }
}

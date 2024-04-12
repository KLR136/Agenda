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

namespace agenda.View
{
    /// <summary>
    /// Logique d'interaction pour View_Réseaux.xaml
    /// </summary>
    public partial class View_Réseaux : UserControl
    {
        public View_Réseaux()
        {
            InitializeComponent();
        }


        private void Calendrier_Reseaux_Click(object sender, RoutedEventArgs e)
        {
            Grille_Reseaux.Children.Clear();
            View_Calendar calendarPage = new View_Calendar();
            Grille_Reseaux.Children.Add(calendarPage);
        }

        private void Contacts_Reseaux_Click(object sender, RoutedEventArgs e)
        {
            Grille_Reseaux.Children.Clear();
            View_Réseaux view_Reseaux = new View_Réseaux();
            Grille_Reseaux.Children.Add(view_Reseaux);
        }

        private void Supprimer_Reseaux_Click(object sender, RoutedEventArgs e)
        {
            while (DG_Reseaux.SelectedItems.Count > 0)
            {
                DG_Reseaux.Items.Remove(DG_Reseaux.SelectedItems[0]);
            }
        }


        private void BTN_Contacts_Click(object sender, RoutedEventArgs e)
        {
            Grille_Reseaux.Children.Clear();
            View_Page_Principale page_Principale = new View_Page_Principale();
            Grille_Reseaux.Children.Add(page_Principale);
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Grille_Reseaux.Children.Clear();
            View_Page_Principale page_Principale = new View_Page_Principale();
            Grille_Reseaux.Children.Add(page_Principale);
        }
    }
}

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
    /// Logique d'interaction pour View_Calendar.xaml
    /// </summary>
    public partial class View_Calendar : UserControl
    {
        public View_Calendar()
        {
            InitializeComponent();
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            Grille_Calendrier.Children.Clear();
            View_Contact view_Contact = new View_Contact();
            Grille_Calendrier.Children.Add(view_Contact);
        }

        private void Reseaux_sociaux_Click(object sender, RoutedEventArgs e)
        {
            Grille_Calendrier.Children.Clear();
            View_Réseaux view_Reseaux = new View_Réseaux();
            Grille_Calendrier.Children.Add(view_Reseaux);
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Grille_Calendrier.Children.Clear();
            View_Page_Principale page_Principale = new View_Page_Principale();
            Grille_Calendrier.Children.Add(page_Principale);
        }
    }
}

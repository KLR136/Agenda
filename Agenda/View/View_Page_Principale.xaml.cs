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
    /// Logique d'interaction pour View_Page_Principale.xaml
    /// </summary>
    public partial class View_Page_Principale : UserControl
    {
        public View_Page_Principale()
        {
            InitializeComponent();
        }


        private void Calendrier_Click(object sender, RoutedEventArgs e)
        {
            Page_Principale.Children.Clear();
            View_Calendar calendarPage = new View_Calendar();
            Page_Principale.Children.Add(calendarPage);
        }


        private void Reseaux_sociaux_Click(object sender, RoutedEventArgs e)
        {
            Page_Principale.Children.Clear();
            View_Réseaux view_Reseaux = new View_Réseaux();
            Page_Principale.Children.Add(view_Reseaux);
        }


        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Page_Principale.Children.Clear();
            View_Contact view_Contact = new View_Contact();
            Page_Principale.Children.Add(view_Contact);
        }
    }
}

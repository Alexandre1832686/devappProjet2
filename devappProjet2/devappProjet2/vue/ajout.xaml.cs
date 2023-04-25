using devappProjet2.vue_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace devappProjet2.vue
{
    /// <summary>
    /// Logique d'interaction pour ajout.xaml
    /// </summary>
    public partial class ajout : Window
    {
        AjoutVM vm;
        
        public ajout()
        {
            InitializeComponent();
            vm = new AjoutVM();
            this.DataContext = vm;
            
        }

        private void Enregistrer(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

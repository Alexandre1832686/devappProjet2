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
using System.Windows.Shapes;
using devappProjet2.vue_model;

namespace devappProjet2.vue
{
    /// <summary>
    /// Logique d'interaction pour liste.xaml
    /// </summary>
    public partial class liste : Window
    {
        ListVM vm;
        public liste()
        {
            InitializeComponent();
            vm= new ListVM();
            this.DataContext = vm;
        }

        private void Creer(object sender, RoutedEventArgs e)
        {
            ajout a = new ajout(vm);
            a.Show();
        }
    }
}

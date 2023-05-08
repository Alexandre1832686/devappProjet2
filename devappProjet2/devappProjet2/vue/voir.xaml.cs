using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
using devappProjet2.model;
using devappProjet2.vue_model;
using BibliothèqueDeClasse;

namespace devappProjet2.vue
{
    /// <summary>
    /// Logique d'interaction pour voir.xaml
    /// </summary>
    public partial class voir : Window
    {
        public voir(calcul c)
        {
           
            voirVM vm = new voirVM();
            this.DataContext = vm;
            vm.Calcul = c;
            InitializeComponent();
        }

  

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

﻿using System;
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

namespace devappProjet2.vue
{
    /// <summary>
    /// Logique d'interaction pour Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message(string message)
        {
            InitializeComponent();
            Mes.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

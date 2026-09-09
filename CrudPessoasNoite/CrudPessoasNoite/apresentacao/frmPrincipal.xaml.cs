using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrudPessoasNoite.apresentacao
{
    /// <summary>
    /// Lógica interna para frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mniCadastrar_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrar frmC = new frmCadastrar();
            frmC.ShowDialog();
        }

        private void mniPEE_Click(object sender, RoutedEventArgs e)
        {
            frmPEE frmPee = new frmPEE();
            frmPee.ShowDialog();
        }
    }
}

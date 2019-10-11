using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeListViewSample.ViewModels;
using TreeListViewSample.Models;

namespace TreeListViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = vm;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.ChangeNode1Value();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.ChangeNode2Value();
        }
    }
}

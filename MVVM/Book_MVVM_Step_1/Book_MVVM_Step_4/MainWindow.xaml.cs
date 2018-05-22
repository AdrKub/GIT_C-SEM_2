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
using Book_MVVM_Step_4.ViewModel;

namespace Book_MVVM_Step_4
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSetTitle_Click(object sender, RoutedEventArgs e)
        {
            BookViewModel viewModel = this.DataContext as BookViewModel;
            viewModel.Title = "FiftyShadesOfGrey";
            viewModel.Author = "Hansruedi";
            viewModel.Price = 69.69;
        }
    }
}

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

namespace DXExampleUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logger.RegisterLogAction((s) => tbLog.AppendText(s));
        }

        
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            await CreateInstance().PreProcessExample();
        }

        private ExampleProcessor CreateInstance()
        {
            return new ExampleProcessor(tbId.Text);
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            CreateInstance().Commit(tbCommitMessage.Text);
        }
    }
}

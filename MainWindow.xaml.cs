using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Semafor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MyThreadInfo> ListDataCreated = new List<MyThreadInfo> { };
        List<MyThreadInfo> ListDataWaiting = new List<MyThreadInfo> { };
        List<MyThreadInfo> ListDataWorking = new List<MyThreadInfo> { };
        static Semaphore sem = new Semaphore(0, 3);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreateThread_Click(object sender, RoutedEventArgs e)
        {
            MyThreadInfo newTr = new MyThreadInfo();
            //Thread myThread = new Thread(new ThreadStart(newTr.Run));
            ListDataCreated.Insert(0, newTr); // addition item with info to list 
            lstCreatedThreads.Items.Insert(0, newTr.InfoToString());
            //myThread.Start();

        }

        private void lstCreatedThreads_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int Index = this.lstCreatedThreads.SelectedIndex; //definition of selected index

            //update list of Waiting 
            MyThreadInfo SelectedInfo = ListDataCreated.ElementAt(Index);
            SelectedInfo.SetWaiting();

            ListDataWaiting.Insert(0, SelectedInfo);
            lstWaitingThreads.Items.Insert(0, SelectedInfo.InfoToString());

            //update list of Created
            lstCreatedThreads.Items.RemoveAt(Index);
            ListDataCreated.RemoveAt(Index);
        }

        private void lstWaitingThreads_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int Index = this.lstWaitingThreads.SelectedIndex; //definition of selected index

            //update list of Working 
            MyThreadInfo SelectedInfo = ListDataWaiting.ElementAt(Index);
            SelectedInfo.SetWorking();

            ListDataWorking.Insert(0, SelectedInfo);
            ListDataWorking[0].Run();
            lstWorkingThreads.Items.Insert(0, SelectedInfo.InfoToString());

            //update list of Waiting
            lstWaitingThreads.Items.RemoveAt(Index);
            ListDataWaiting.RemoveAt(Index);

        }
    }
}

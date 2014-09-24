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
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Management;



namespace Copy_IT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        //Global Declations
        public int CComplet = 0;
        public int Step { get; set; }
        public int SDirCount;
        public int DirCount;
        public int totelCount;
        public int JobCount = 1;
        public int OverallTotel;
        public String Dest_FBDResults;
        private FolderBrowserDialog openFolder = new FolderBrowserDialog();
        public string Source_FBDResults;
        public bool Overwrite = false;

        string _CurrentExpanded;
        public string CurrentExpanded
        {
            get
            {
                return _CurrentExpanded;
            }
            set
            {
                if (_CurrentExpanded != value)
                {
                    _CurrentExpanded = value;
                    RaisePropertyChanged("CurrentExpanded");
                }
            }
        }
        

        string _CurrentExpanded2;
        public string CurrentExpanded2
        {
            get
            {
                return _CurrentExpanded2;
            }
            set
            {
                if (_CurrentExpanded2 != value)
                {
                    _CurrentExpanded2 = value;
                    RaisePropertyChanged("CurrentExpanded2");
                }
            }
        }

        string _CurrentExpanded3 = "1";
        public string CurrentExpanded3
        {
            get
            {
                return _CurrentExpanded3;
            }
            set
            {
                if (_CurrentExpanded3 != value)
                {
                    _CurrentExpanded3 = value;
                    RaisePropertyChanged("CurrentExpanded3");
                }
            }
        }


        //public ObservableCollection<ExpanderItem> Expanders { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Load();

        }

        public void Load()
        {

            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                CB_Owner.Items.Add(envVar["Name"]);
            }
            
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string SourceDir = TB_SorceDir.Text;
            //string DestDir = TB_DestDir.Text;
            //CopyMashine CopyM = new CopyMashine();

            if (TB_SorceDir.Text == "")
            {
                if (TB_DestDir.Text == "")
                {
                    System.Windows.MessageBox.Show("Error: You need a Source and Destanation to Copy Files.", "Copy Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    System.Windows.MessageBox.Show("Error: You need a Source to Copy the Files from.", "Copy Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                if (TB_DestDir.Text == "")
                {
                    System.Windows.MessageBox.Show("Error: You need a Destasnation to Copy the Files to.", "Copy Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {

                    WarrningMessage();
                    //System.Threading.Thread.Sleep(5000);
                    //SleepTimer();
                    CopyMashine();
                }
            }
            
            
        }

        private void WarrningMessage()
        {
            RTBOutput.AppendText(Environment.NewLine + "You Hit the Big Red Button!! Do you know what you just DID?");
            RTBOutput.AppendText(Environment.NewLine + "Begining the File Copy Proccess ... ");
            RTBOutput.AppendText(Environment.NewLine + "Please Wait for the Proccess to Finish");
        }

        

        public void CopyMashine()
        {

            PBPrep();

            DateTime CurrentTime = DateTime.Now;
            TB_StartTime.Text = CurrentTime.ToString();

            if (CB_Recursive.IsChecked == true)
            {
                DirectoryInfo directory = new DirectoryInfo(Source_FBDResults);
                FileInfo[] files = directory.GetFiles( "*.*", SearchOption.AllDirectories);

                PreMakeDir();

                foreach( var f in files)
                {
                    var f2 = f.FullName;

                    copyer(f2.ToString(), f.ToString());
                    
                    //RTBOutput.AppendText(Environment.NewLine + f2);
                    RTBOutput.ScrollToEnd();
                    CComplet = CComplet + 1;
                    TB_CompletedCount.Text = CComplet.ToString();
                    MainPB.Value = CComplet;

                }
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(Source_FBDResults);
                FileInfo[] files = directory.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (var f in files)
                {
                    var f2 = f.FullName;

                    copyer(f2.ToString(), f.ToString());

                    //RTBOutput.AppendText(Environment.NewLine + f2);
                    RTBOutput.ScrollToEnd();
                    CComplet = CComplet + 1;
                    TB_CompletedCount.Text = CComplet.ToString();
                    MainPB.Value = CComplet;

                }
            }

        }

        public void PBPrep()
        {
             //Setting up the Proggress Bar for the task
            MainPB.Minimum = 0;
            MainPB.Maximum = totelCount;
            MainPB.Value = 0;
            
        }

        public void OverAllPBPrep()
        {
            //Setting up the Over all Progress bar
            PBOverAll.Minimum = 0;
            PBOverAll.Maximum = OverallTotel;
            PBOverAll.Value = 0;
        }

        public void copyer(string ffname, string fname)
        {
            DirectoryInfo DestDir = new DirectoryInfo(Dest_FBDResults);
            DirectoryInfo SorceDir = new DirectoryInfo(Source_FBDResults);
            string SNameDir1 = ffname.Replace(fname, "");
            string SNamedir2 = SNameDir1.Replace(SorceDir.ToString(), DestDir.ToString());
            string NFName = SNamedir2 + fname;
            if (System.IO.Directory.Exists(SNamedir2))
            {
                System.IO.File.Copy(ffname, NFName, Overwrite);
                RTBOutput.AppendText(Environment.NewLine + ffname + " Copy to " + NFName);
            }

        }

        public void PreMakeDir()
        {
            DirectoryInfo directory = new DirectoryInfo(Source_FBDResults);
            DirectoryInfo DestDir = new DirectoryInfo(Dest_FBDResults);
            DirectoryInfo[] DList = directory.GetDirectories("*", SearchOption.AllDirectories);
            foreach(var D in DList)
            {
                string D2 = D.FullName;

                string D3 = D2.Replace(directory.ToString(), DestDir.ToString());

                string D4 = D2.Replace(directory.ToString(), "");

                DirectoryInfo mdir = new DirectoryInfo(D3);

                mdir.Create();

                RTBOutput.AppendText(Environment.NewLine + D2 + " making " + D3 );
                RTBOutput.ScrollToEnd();
                CComplet = CComplet + 1;
                TB_CompletedCount.Text = CComplet.ToString();
                MainPB.Value = CComplet;
            }
        }

        public void SleepTimer()
        {
            Stopwatch sw = new Stopwatch(); // sw cotructor
            sw.Start(); // starts the stopwatch
            for (int i = 0; ; i++)
            {
                if (i % 100000 == 0) // if in 100000th iteration (could be any other large number
                // depending on how often you want the time to be checked) 
                {
                    sw.Stop(); // stop the time measurement
                    if (sw.ElapsedMilliseconds > 5000) // check if desired period of time has elapsed
                    {
                        break; // if more than 5000 milliseconds have passed, stop looping and return
                        // to the existing code
                    }
                    else
                    {
                        sw.Start(); // if less than 5000 milliseconds have elapsed, continue looping
                        // and resume time measurement
                    }
                }
            }
        }
        


        private void BTExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        


        private void BT_Sorce_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = openFolder.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                TB_SorceDir.Text = openFolder.SelectedPath;
                Source_FBDResults = openFolder.SelectedPath;
                Filecount();
                //BindingExpression be = GetBindingExpression(TextProperty);
                //if (be != null)
                //    be.UpdateSource();
            }

        }


        public void JobTotel()
        {
            OverallTotel = JobCount * totelCount;
        }

        public void Filecount()
        {
           
            if (CB_Recursive.IsChecked == true)
            {
                try
                    {
                        SDirCount = Directory.GetFiles(Source_FBDResults, "*.*", SearchOption.AllDirectories).Length;
                        DirCount = Directory.GetDirectories(Source_FBDResults,"*", SearchOption.AllDirectories).Length;
                        totelCount = SDirCount + DirCount;
                    }
                catch (UnauthorizedAccessException)
                    {
                        string logMsg = string.Format("Unable to access directory {0}", Source_FBDResults);
                        RTBOutput.AppendText(Environment.NewLine + logMsg);
                        RTBOutput.AppendText(Environment.NewLine + "Please try Running me as Adminstrator");
                        

                    }
                catch(ArgumentNullException)
                {

                }
            }
            else
            {
                try
                {
                    totelCount = Directory.GetFiles(Source_FBDResults, "*.*", SearchOption.TopDirectoryOnly).Length;

                }
                catch (UnauthorizedAccessException)
                {
                    string logMsg = string.Format("Unable to access all the files in directory {0}", Source_FBDResults);
                    RTBOutput.AppendText(Environment.NewLine + logMsg);
                    RTBOutput.AppendText(Environment.NewLine + "Please try Running me as Adminstrator" );

                }
                catch (ArgumentNullException)
                {

                }
            }

            TBFileCount.Text = totelCount.ToString();
        }

        

        private void BT_Dest_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = openFolder.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                TB_DestDir.Text = openFolder.SelectedPath;
                Dest_FBDResults = openFolder.SelectedPath;
               
                //BindingExpression be = GetBindingExpression(TextProperty);
                //if (be != null)
                //    be.UpdateSource();
            }
        }

        private void CB_Recursive_Checked(object sender, RoutedEventArgs e)
        {
            Filecount();
        }

        private void CB_Recursive_UnChecked(object sender, RoutedEventArgs e)
        {
            Filecount();
        }

        private void ChBOwner_Checked(object sender, RoutedEventArgs e)
        {
            CB_Owner.IsEnabled = true;
        }

        private void ChBOwner_UnChecked(object sender, RoutedEventArgs e)
        {
            CB_Owner.IsEnabled = false;
        }

        private void CB_OverW_Checked(object sender, RoutedEventArgs e)
        {
            Overwrite = true;
        }

        private void CB_OverW_UnChecked(object sender, RoutedEventArgs e)
        {
            Overwrite = false;
        }
    }
}
    


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static System.Net.Mime.MediaTypeNames;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        ObservableCollection<string> items = new ObservableCollection<string>();
        ViewModel model = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            LoadImage();
            DataContext = model;
            //Step.StepC = 0;
            model.img = items[Step.StepC = 0];
        }
        private void LoadImage()
        {
            items.Add($@"image/0.png");
            items.Add($@"image/1.png");
            items.Add($@"image/2.png");
            items.Add($@"image/3.png");
            items.Add($@"image/4.png");
            items.Add($@"image/5.png");
            items.Add($@"image/6.png");
            items.Add($@"image/7.png");
        }

        private void Previous_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Step.StepC >= 0)
                    Step.StepC--;
                model.img = items[Step.StepC];
                if (Step.StepC == 0)
                    PreviousBtn.IsEnabled = false;
                else
                    PreviousBtn.IsEnabled = true;
                if (Step.StepC == 7)
                    NextBtn.IsEnabled = false;
                else
                    NextBtn.IsEnabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Next_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Step.StepC < 7)
                    Step.StepC++;
                model.img = items[Step.StepC];
                if (Step.StepC == 0)
                    PreviousBtn.IsEnabled = false;
                else
                    PreviousBtn.IsEnabled = true;
                if (Step.StepC == 7)
                    NextBtn.IsEnabled = false;
                else
                    NextBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
    public class ViewModel : INotifyPropertyChanged
    {
        private string _img;
        public string img
        {
            get { return _img; }
            set
            {
                _img = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    static public class Step
    {
        static public int StepC { set; get; }
    }
}

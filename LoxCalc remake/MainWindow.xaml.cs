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

namespace LoxCalc_remake
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point First = new Point();
        Point Second = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnlyDigits_input(object sender, TextCompositionEventArgs e)
        {
            if (!Int32.TryParse(e.Text, out int digit))
                e.Handled = true;
        }
        private void NoSpaceBar_input(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            LoxMath.Calculate(First, Second);
            ResultCourse.Text = LoxMath.course.ToString();
            ResultDistKm.Text = LoxMath.distance.ToString();
            ResultDistMi.Text = (LoxMath.distance * 0.53995680346).ToString();
        }

        private void Lat1Deg_TextChanged(object sender, TextChangedEventArgs e)
        {
            First.latitudeDegrees = double.Parse(Lat1Deg.Text);
        }
        private void Lat1Min_TextChanged(object sender, TextChangedEventArgs e)
        {
            First.latitudeMinutes = double.Parse(Lat1Min.Text);
        }
        private void Lat1Sec_TextChanged(object sender, TextChangedEventArgs e)
        {
            First.latitudeSeconds = double.Parse(Lat1Sec.Text);
        }
        private void Lat1North_Checked(object sender, RoutedEventArgs e)
        {
            First.isNorth = true;
        }
        private void Lat1South_Checked(object sender, RoutedEventArgs e)
        {
            First.isNorth = false;
        }

        private void Long1Deg_TextChanged(object sender, TextChangedEventArgs e)
        {
            First.longitudeDegrees = double.Parse(Long1Deg.Text);
        }
        private void Long1Min_TextChanged(object sender, TextChangedEventArgs e)
        {
            First.longitudeMinutes = double.Parse(Long1Min.Text);
        }
        private void Long1Sec_TextChanged(object sender, TextChangedEventArgs e)
        {
            First.longitudeSeconds = double.Parse(Long1Sec.Text);
        }
        private void Long1East_Checked(object sender, RoutedEventArgs e)
        {
            First.isEast = true;
        }
        private void Long1West_Checked(object sender, RoutedEventArgs e)
        {
            First.isEast = false;
        }

        private void Lat2Deg_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second.latitudeDegrees = double.Parse(Lat2Deg.Text);
        }
        private void Lat2Min_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second.latitudeMinutes = double.Parse(Lat2Min.Text);
        }
        private void Lat2Sec_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second.latitudeSeconds = double.Parse(Lat2Sec.Text);
        }
        private void Lat2North_Checked(object sender, RoutedEventArgs e)
        {
            Second.isNorth = true;
        }
        private void Lat2South_Checked(object sender, RoutedEventArgs e)
        {
            Second.isNorth = false;
        }

        private void Long2Deg_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second.longitudeDegrees = double.Parse(Long2Deg.Text);
        }
        private void Long2Min_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second.longitudeMinutes = double.Parse(Long2Min.Text);
        }
        private void Long2Sec_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second.longitudeSeconds = double.Parse(Long2Sec.Text);
        }
        private void Long2East_Checked(object sender, RoutedEventArgs e)
        {
            Second.isEast = true;
        }
        private void Long2West_Checked(object sender, RoutedEventArgs e)
        {
            Second.isEast = false;
        }
    }
}

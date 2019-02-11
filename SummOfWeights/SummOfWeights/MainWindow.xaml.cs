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

namespace SummOfWeights
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Объекты класса Complex. Нужны для вычисления операций над грузами.
        Complex[] complexWeights = new Complex[8] {new Complex(), new Complex(), new Complex(), new Complex(), new Complex(), new Complex(), new Complex(), new Complex() };
        //Вес каждого из грузов в массиве
        double[] weights = new double[8];
        //массив с номерами выбранных CheckBox'ов
        int[] checkedBoxes = new int[8];      
        

        double sumWeight;
        CheckBox[] boxes;        

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            boxes = new CheckBox[] {chkWeight1, chkWeight2, chkWeight3, chkWeight4, chkWeight5, chkWeight6, chkWeight7, chkWeight8 };
        }        
        private void btnSummWeight_Click(object sender, RoutedEventArgs e)
        {
            Complex sumComplex = new Complex();
            for (int i = 0; i < 8; i++)
            {
                if (boxes[i].IsChecked == true)
                {
                    checkedBoxes[i] = i;
                    sumComplex = Complex.Plus(sumComplex, complexWeights[checkedBoxes[i]]);
                }
            }
            sumWeight = Complex.Module(sumComplex);

            //Вывод массы грузов
            lblSummWeight.Content = string.Format($"{sumWeight}");            
            lblSummAngle.Content = Math.Abs((Math.Atan((sumComplex.Im/sumComplex.Re))) / (Math.PI / 180));

            //Обнуление суммарного веса, чтобы при повторном нажатии выводилась корректная информация
            sumWeight = 0;
            sumComplex = new Complex();            
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtWeight1.Text.Length == 0 && txtWeight2.Text.Length == 0 && 
                txtWeight3.Text.Length == 0 && txtWeight4.Text.Length == 0 && 
                txtWeight5.Text.Length == 0 && txtWeight6.Text.Length == 0 &&
                txtWeight7.Text.Length == 0 && txtWeight8.Text.Length == 0)
            {
                chkWeight1.Visibility = Visibility.Hidden;
                chkWeight2.Visibility = Visibility.Hidden;
                chkWeight3.Visibility = Visibility.Hidden;
                chkWeight4.Visibility = Visibility.Hidden;
                chkWeight5.Visibility = Visibility.Hidden;
                chkWeight6.Visibility = Visibility.Hidden;
                chkWeight7.Visibility = Visibility.Hidden;
                chkWeight8.Visibility = Visibility.Hidden;
            }            

        }

        #region Обработка события закрытия программы
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {            
            string msg = "Вы действительно хотите завершить приложение?";
            MessageBoxResult result = MessageBox.Show(msg, "Сложение грузов", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Вычисление вещественной и мнимой части комплексного числа
        /// <summary>
        /// Метод вычисления вещественной и мнимой части комплексного числа
        /// </summary>
        /// <param name="weight">Вес (модуль комплексного числа)</param>
        /// <param name="angle">Угол (аргумент комплексного числа)</param>
        private static void ComplexNumbers(int weight, double angle, out double radianAng, out double re, out double im)
        {
            //Угол в радианах. Формула fi = angle * (3.14 / 180)
            double fi = angle * (Math.PI / 180);
            radianAng = fi;            
            //Действительная часть комплексного числа. Формула x = weight * cos(fi)
            double x = weight * Math.Cos(fi);
            re = x;            
            //Мнимая часть комплексного числа. Формула y = weight * sin(fi)
            double y = weight * Math.Sin(fi);
            im = y;
        }
        #endregion

        #region Обработка событий checked для CheckBox'ов
        private void chkWeight1_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight1.Text);
            double angle = double.Parse(txtAngle1.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[0] = new Complex(x, y); // Комплексное число для "Груза 1"
            //MessageBox.Show(c1.ToString());      
            weights[0] = Complex.Module(complexWeights[0]);            
        }    
        private void chkWeight2_Checked(object sender, RoutedEventArgs e)
        {            
            int weight = int.Parse(txtWeight2.Text);
            double angle = double.Parse(txtAngle2.Text);            
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[1] = new Complex(x, y); // Комплексное число для "Груза 2"            
            weights[1] = Complex.Module(complexWeights[1]);            
        }
        private void chkWeight3_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight3.Text);
            double angle = double.Parse(txtAngle3.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[2] = new Complex(x, y); // Комплексное число для "Груза 3"            
            weights[2] = Complex.Module(complexWeights[2]);            
        }
        private void chkWeight4_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight4.Text);
            double angle = double.Parse(txtAngle4.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[3] = new Complex(x, y); // Комплексное число для "Груза 4"            
            weights[3] = Complex.Module(complexWeights[3]);            
        }

        private void chkWeight5_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight5.Text);
            double angle = double.Parse(txtAngle5.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[4] = new Complex(x, y); // Комплексное число для "Груза 5"            
            weights[4] = Complex.Module(complexWeights[4]);            
        }
        private void chkWeight6_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight6.Text);
            double angle = double.Parse(txtAngle6.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[5] = new Complex(x, y); // Комплексное число для "Груза 6"            
            weights[5] = Complex.Module(complexWeights[5]);            
        }
        private void chkWeight7_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight7.Text);
            double angle = double.Parse(txtAngle7.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[6] = new Complex(x, y); // Комплексное число для "Груза 7"            
            weights[6] = Complex.Module(complexWeights[6]);            
        }
        private void chkWeight8_Checked(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(txtWeight8.Text);
            double angle = double.Parse(txtAngle8.Text);
            double fi, x, y;
            //Вычисление вещественной и мнимой части комплексного числа
            ComplexNumbers(weight, angle, out fi, out x, out y);
            complexWeights[7] = new Complex(x, y); // Комплексное число для "Груза 8"            
            weights[7] = Complex.Module(complexWeights[7]);            
        }
        #endregion
        

        #region Изменить цвет TextBox'ов при изменении содержимого
        #region Масса
        private void txtWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight1.Background = (txtWeight1.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight1.Visibility = (txtWeight1.Text.Length != 0 && txtAngle1.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;            
        }
        private void txtWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight2.Background = (txtWeight2.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight2.Visibility = (txtWeight2.Text.Length != 0 && txtAngle2.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight3.Background = (txtWeight3.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight3.Visibility = (txtWeight3.Text.Length != 0 && txtAngle3.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight4.Background = (txtWeight4.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight4.Visibility = (txtWeight4.Text.Length != 0 && txtAngle4.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight5.Background = (txtWeight5.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight5.Visibility = (txtWeight5.Text.Length != 0 && txtAngle5.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtWeight6_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight6.Background = (txtWeight6.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight6.Visibility = (txtWeight6.Text.Length != 0 && txtAngle6.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtWeight7_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight7.Background = (txtWeight7.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight7.Visibility = (txtWeight7.Text.Length != 0 && txtAngle7.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtWeight8_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWeight8.Background = (txtWeight8.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight8.Visibility = (txtWeight8.Text.Length != 0 && txtAngle8.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion
        #region Угол
        private void txtAngle1_TextChanged(object sender, TextChangedEventArgs e)
        {            
            txtAngle1.Background = (txtAngle1.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight1.Visibility = (txtWeight1.Text.Length != 0 && txtAngle1.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle2_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle2.Background = (txtAngle2.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight2.Visibility = (txtWeight2.Text.Length != 0 && txtAngle2.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle3_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle3.Background = (txtAngle3.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight3.Visibility = (txtWeight3.Text.Length != 0 && txtAngle3.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle4_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle4.Background = (txtAngle4.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight4.Visibility = (txtWeight4.Text.Length != 0 && txtAngle4.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle5_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle5.Background = (txtAngle5.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight5.Visibility = (txtWeight5.Text.Length != 0 && txtAngle5.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle6_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle6.Background = (txtAngle6.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight6.Visibility = (txtWeight6.Text.Length != 0 && txtAngle6.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle7_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle7.Background = (txtAngle7.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight7.Visibility = (txtWeight7.Text.Length != 0 && txtAngle7.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        private void txtAngle8_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAngle8.Background = (txtAngle8.Text.Length != 0) ? Brushes.LightGreen : Brushes.White;
            chkWeight8.Visibility = (txtWeight8.Text.Length != 0 && txtAngle8.Text.Length != 0) ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion
        #endregion


    }
}

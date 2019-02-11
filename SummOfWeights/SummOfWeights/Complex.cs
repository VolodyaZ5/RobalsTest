using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummOfWeights
{
    class Complex
    {
        private double re, im;
        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public Complex()
        {
            this.re = 0;
            this.im = 0;
        }
        /// <summary>
        /// Кастомный конструктор с двумя параметрами
        /// </summary>
        /// <param name="re">Действительная часть комплексного числа</param>
        /// <param name="im">Мнимая часть комплексного числа</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }        

        //Свойство поля re
        public double Re
        {
            get { return re; }
            set { re = value; }
        }

        //Свойство поля im
        public double Im
        {
            get { return im; }
            set { im = value; }
        } 

        /// <summary>
        /// Сумма 2х комплексных чисел
        /// </summary>
        /// <param name="c1">Первое комплексное число</param>
        /// <param name="c2">Второе комплексное число</param>
        /// <returns></returns>
        public static Complex Plus(Complex c1, Complex c2)
        {
            return new Complex(c1.re + c2.re, c1.im + c2.im);
        }        

        /// <summary>
        /// Модуль комплексного числа (в нашем случае масса груза)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Module(Complex c)
        {
            return Math.Sqrt(Math.Pow(c.re, 2) + Math.Pow(c.im, 2));
        }

        /// <summary>
        /// Разность 2х комплексных чисел
        /// </summary>
        /// <param name="c1">Первое комплексное число</param>
        /// <param name="c2">Второе комплексное число</param>
        /// <returns></returns>
        public static Complex Minus(Complex c1, Complex c2)
        {
            return new Complex(c1.re - c2.re, c1.im - c2.im);
        }
        //public override string ToString()
        //{
        //    return string.Format($"{re:F1} + {im:F1}i");
        //}
    }
}

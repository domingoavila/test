using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prueba
{
    public class Calculator
    {
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private static int _pi;

        public static int PI
        {
            get { return 3; }
        }

        public Calculator()
        {

        }

        public double Add(double d, double e)
        {
            return d + e;
        }

        private void Mensaje()
        {
            Console.WriteLine("Prueba");
        }
    }
}

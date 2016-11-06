using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplication2
{
    public class Test
    {
        public delegate void mitask(int i);

        public static void Main(string[] args)
        {
            //Aseembly
            Assembly testAssembly = Assembly.LoadFile(@"C:\Users\Admin\Source\Repos\test\Reflection\ReflectionClass\bin\Debug\ReflectionClass.dll");
            Type calcType = testAssembly.GetType("prueba.Calculator");

            //Public method
            object calcInstance = Activator.CreateInstance(calcType);
            double value = (double)calcType.InvokeMember("Add", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
            null, calcInstance, new object[] { 20.0, 10.0 });

            //Public properties
            PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");
            numberPropertyInfo.SetValue(calcInstance, 10, null);
            int mivalor = (int)numberPropertyInfo.GetValue(calcInstance, null);

            //Private properties
            double miprivatevalue = (Int32)calcType.InvokeMember("_number",
            BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
            null, calcInstance, null);

            
            //public static properties
            PropertyInfo piPropertyInfo = calcType.GetProperty("PI");
            int piValue = (int)piPropertyInfo.GetValue(null, null);


            // invoke private instance method: private void DoClear()
            calcType.InvokeMember("Mensaje",
                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
                null, calcInstance, null);



            Task mitask = new Task();

            mitask objdelegado = new mitask(mitask.metodo1);
            objdelegado += new mitask(mitask.metodo2);

            objdelegado(6);
            Console.ReadKey();
            objdelegado -= new mitask(mitask.metodo1);
            objdelegado += new mitask(metodo3);
            objdelegado(2);
            Console.ReadKey();

        }

        public static void metodo3(int i)
        {
            Console.WriteLine("metodo2 {0}", i * i*i);
        }

    }
    public class Task
    {
        public void metodo1(int i)
        {
            Console.WriteLine("metodo1 {0}",i);
        }

        public void metodo2(int i)
        {
            Console.WriteLine("metodo2 {0}",i*i);
        }
    }
}




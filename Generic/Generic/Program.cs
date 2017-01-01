using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.ac = new C();
            a.ac.cname = "Hola";
            B b = new B();
            C c = con<A>(a);
            C cc = con<B>(b);

        }

        static C con<T>(object o)
        {
            var a = (I)o;
            return a.retornaC();            
        }
    }

    public class A:I
    {
        public C ac { get; set; }
        public C retornaC()
        {
            return ac;
        }
    }

    public class B:I
    {
        public string nombre { get; set; }
        public C retornaC()
        {
            return null;
        }
    }

    public class C
    {
        public string cname { get; set; }

    }

    public interface I
    {
        C retornaC();
    }
}

using BackgroundWorker;
using System;
using System.ComponentModel;
 
class Program
{
    static MiClase miClase;
 
    static void Main()
    {
        // Configuramos nuestra clase a través del constructor.
        miClase = new MiClase(1, "Cualquier cosa");
        miClase.ProgressChanged += new ProgressChangedEventHandler(miClase_ProgressChanged);
        miClase.RunWorkerCompleted += new RunWorkerCompletedEventHandler(miClase_RunWorkerCompleted);
        miClase.RunWorkerAsync("¡Hola, hilo de trabajo!");
 
        Console.WriteLine("Presiona ENTER dentro de los próximos 5 segundos para cancelar.");
 
        Console.ReadLine();
 
        if (miClase.IsBusy)
            miClase.CancelAsync();
 
        Console.ReadLine();
    }
 
    static void miClase_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Console.WriteLine("Completado " + e.ProgressPercentage + "%");
    }
 
    static void miClase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
            Console.WriteLine("Tu cancelaste la operación!");
        else if (e.Error != null)
            Console.WriteLine("Excepción en el hilo de trabajo: " +
                              e.Error.ToString());
        else
            // Desde el método DoWork
            Console.WriteLine("Completado - " + e.Result);
    }
}

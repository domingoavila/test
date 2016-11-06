using System.ComponentModel;
using System.Threading;

namespace BackgroundWorker
{
    class MiClase : System.ComponentModel.BackgroundWorker
    {
        public MiClase()
        {
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        public MiClase(int unDato,
                       string otroDato)
            : this()
        {

        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            // Cuando hemos llamado a bw.RunWorkerAsync()
            // hemos pasado información al hilo de trabajo.
            // Eso suele ser usado para suministrar al hilo de trabajo
            // información necesaria para que él sea capaz de hacer su tarea.
            string desdeHiloPrincipal = e.Argument.ToString();

            for (int i = 0; i <= 100; i += 20)
            {
                // Cada vez que iteramos,
                // comprobamos si nos han mandado salirnos.
                if (this.CancellationPending)
                {
                    // Si es así, informamos...
                    e.Cancel = true;
                    // y nos salimos.
                    return;
                }

                // Informamos desde aquí acerca del progreso de la operación.
                this.ReportProgress(i);

                // Aunque estemos en otro hilo diferente,
                // si no ponemos este Sleep aquí,
                // podríamos poner de rodillas al microprocesador,
                // la aplicación podría no responder,
                // obtendríamos justo lo que queremos evitar.
                // Lo que tu pares aquí, es tiempo que concedes al micro
                // para atender al hilo principal de la aplicación.
                Thread.Sleep(1000);
            }
            // Esto se pasa al evento RunWorkerCompleted.
            // Digamos que es el resultado final de la operación.
            // Result es un object, podemos pasar cualquier cosa.
            e.Result = 123;
        }
    }
}

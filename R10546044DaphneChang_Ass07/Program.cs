using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R10546044DaphneChang_Ass07
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            int ii = 99;
            int[] iary = new int[30];
            double[] fit = new double[30];
            Random rnd = new Random();
            for(int i = 0; i < 21; i++)
            {
                iary[i] = i;
                fit[i] = rnd.NextDouble() * 100 - 50.0;
            }
            Array.Sort(fit, iary, 0, 15);
            Array.Reverse(iary, 0 ,15);
            Array.Reverse(fit, 0 ,15);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

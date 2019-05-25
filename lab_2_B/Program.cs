using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_2_B.MVP;
using lab_2_B.MVP.Model;
using lab_2_B.MVP.View;
namespace lab_2_B
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IModel model = new Model();
            IView view = new FormView();
            Presenter presenter = new Presenter(view, model);
        }
    }
}

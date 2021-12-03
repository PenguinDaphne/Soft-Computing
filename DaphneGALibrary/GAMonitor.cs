using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaphneGALibrary
{
    public partial class GAMonitor<S> : UserControl
    {
        GenericGASolver<S> theGASolver;

        public GAMonitor( GenericGASolver<S> theGASolver)
        {
            this.theGASolver = theGASolver;
            InitializeComponent();
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            theGASolver.RunOneIteration();
         }

        private void btnReset_Click(object sender, EventArgs e)
        {
            theGASolver.Reset();
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            theGASolver.RunToEnd();
        }
        
        private void btnGenerateDataToDGV_Click(object sender, EventArgs e)
        {
            theGASolver.dgvGenerateProblem();
        }


    }
 }


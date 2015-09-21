using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDelegates
{
    public partial class Form1 : Form
    {

        private delegate void StatusUpdateDelegate(int val);

        private delegate void ShowProgressDelegate(int val); 
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var max = 100;
            var updateStatus = new StatusUpdateDelegate(StartProcess);
            // this doesnt work because UI thread is being updated from 
            // a secondary thread. 
            
            updateStatus.BeginInvoke(max, null, null); 


        }

        // this is called async to keep the UI responsive while the update is happening. 
        private void StartProcess(int max)
        {
            this.pbStatus.Maximum = max;
            for (int i = 0; i <= max; i++)
            {
                Thread.Sleep(100);
                ShowProgress(i);
            }
        }

        private void ShowProgress(int i)
        {
            if (lblProgress.InvokeRequired)
            {
                var showProgressDel = new ShowProgressDelegate(ShowProgress);
                this.Invoke(showProgressDel, new object[]{i}); 
            }
            else
            {
                lblProgress.Text = String.Format("Progress {0} %", i);
                this.pbStatus.Value = i;
            }
            
        }
    }
}

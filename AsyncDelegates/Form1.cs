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
            // this doesnt work because if UI thread is being updated from 
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

            // here we check if the background thread tries to update an element on the 
            // gui thread if yes 
            // we redirect that activity to the ui thread by 
            // reinvocoking showProgress function using this (which is the form) 
            // then everything works as its supposed to be. 
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jeopardy.BL;

namespace Jeopardy.UI
{
    public partial class frmQuestion : Form
    {
        cQuestion oCurrentQuestion;

        public frmQuestion(cQuestion oQuest)
        {
            InitializeComponent();

            oCurrentQuestion = oQuest;
            oQuest.FillQuestion();
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            lblDescription.Text = oCurrentQuestion.Description;

            btnA.Text = oCurrentQuestion.Items[0].Description;
        }
    }
}

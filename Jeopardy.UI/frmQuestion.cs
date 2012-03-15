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
        private cQuestion oQuestion;

        private int iAnswerIndex;
        public int AnswerIndex
        {
            get { return iAnswerIndex; }
           // set { AnsweredCorrect = value; }
        }
        private Button[] arButtons;

        public frmQuestion(cQuestion oQuest, int viCost, bool bFinal)
        {
            InitializeComponent();

            this.Text = string.Format("${0} Question", viCost);
            oQuestion = oQuest;
            btnPass.Visible = !bFinal;

            arButtons = new Button[4];
            arButtons[0] = btn1;
            arButtons[1] = btn2;
            arButtons[2] = btn3;
            arButtons[3] = btn4;
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            oQuestion.FillQuestion();
            lblDescription.Text = oQuestion.Description;

            for (int x = 0; x < 4; x++ )
            {
                arButtons[x].Text = oQuestion[x].Description;
                if (oQuestion[x].Description.Length > 30)
                {
                    Font oFont = new Font(System.Drawing.FontFamily.GenericSansSerif, 10);

                    arButtons[x].Font = oFont;
                }
            }

            tmrClock.Start();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            tmrClock.Stop();
            //this.Close();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnAnswer = (Button)sender;

                int.TryParse(btnAnswer.Tag.ToString(), out iAnswerIndex);
            }
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jeopardy.DL;

namespace Jeopardy.Input
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            int iID;
            int bFinal = 0;
            string sDescription;
            int bUsed = 0;

            int.TryParse(txtCID.Text , out iID);
            if (chkCFinal.Checked)
                bFinal = 1;
            sDescription = txtCDescription.Text;
            if (chkCUsed.Checked)
                bUsed = 1;

            if (DBAccess.SQLInsert(string.Format("insert into tbl_category (category_is_final, category_description, category_used) values ( {0}, '{1}', {2});",
                                              bFinal, sDescription, bUsed)))
                slblStatus.Text = "Sucsess!";
            else
                slblStatus.Text = "Fail!";
        }

        private void btnAddQuest_Click(object sender, EventArgs e)
        {
            int iID;
            int iCID;
            string sDescription;
            int iCost;

            int.TryParse(txtQID.Text, out iID);
            int.TryParse(txtQCID.Text, out iCID);
            sDescription = txtQDescription.Text;
            int.TryParse(txtQCost.Text, out iCost);

            if (DBAccess.SQLInsert(string.Format("insert into tbl_question (category_id, question_description, question_cost) values ( {0}, '{1}', {2});",
                                              iCID, sDescription, iCost)))
                slblStatus.Text = "Sucsess!";
            else
                slblStatus.Text = "Fail!";
            
        }

        private void btnAddAns_Click(object sender, EventArgs e)
        {
            int iID;
            int iQID;
            string sDescription;
            int bCorrect = 0;

            int.TryParse(txtAID.Text, out iID);
            int.TryParse(txtAQID.Text, out iQID);
            sDescription = txtADescription.Text;
            if (chkACorrect.Checked)
                bCorrect = 1;

            if (DBAccess.SQLInsert(string.Format("insert into tbl_answer (question_id, answer_description, answer_is_correct) values ( {0}, '{1}', {2});",
                                              iQID, sDescription, bCorrect)))
                slblStatus.Text = "Sucsess!";
            else
                slblStatus.Text = "Fail!";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}

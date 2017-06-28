using ReactCalc.Models;
using RectCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class frmMain : Form
    {
        private Calc calc { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            calc = new Calc();

            var operations = calc.Operation;

            lbOperations.DataSource = operations;
            lbOperations.DisplayMember = "Name";
            lbOperations.SelectedIndex = 0;
        }

        private void ctnCalc_Click(object sender, EventArgs e)
        {
            
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDescription.Text = "";
            var displayOper = lbOperations.SelectedItem as IDisplayOperation;

            if(displayOper != null)
            {
                lbDescription.Text = string.Format("Автор:{0}{1}Описание:{2}", displayOper.Author, Environment.NewLine, !string.IsNullOrWhiteSpace(displayOper.Description) ? displayOper.Description : "нет описания");
            }

            tbX.Focus();
        }

        private void TextChanged(object sender, EventArgs e)
        {

            //определяем операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (oper == null)
            {
                lblResult.Text = "Выбери нормальную операцию";
                return;
            }
            //определяем входные данные
            var x = Calc.ToNumb(tbX.Text);
            var y = Calc.ToNumb(tbY.Text);
            try
            {
                //вычислям 
                var result = calc.Execute(oper.Execute, new[] { x, y });

                var displayOper = oper as IDisplayOperation;

                var LastOperationName = displayOper != null ? displayOper.DisplayName : oper.Name;

                //возвращаем результат
                lblResult.Text = string.Format("{0} {1} {2} = {3}", x, oper.Name, y, result);
            }
            catch (NotSupportedException ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        private void tbX_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbX.Text != "")
                if (e.KeyCode == Keys.Enter)
                    tbY.Focus();
        }
    }
}

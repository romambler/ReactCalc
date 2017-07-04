using CalcBase.Models;
using RectCalc;
using System;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class frmMain : Form
    {
        private Calc calc { get; set; }
        private IOperation operation { get; set; }
        private IOperation Operation
        {
            get { return operation; }
            set
            {
                operation = value;
                DispOperation = value as IDisplayOperation;
            }
        }

        private DateTime? lastPressTime { get; set; }

        private IDisplayOperation DispOperation;
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
            calc = new Calc(@"C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\WebCalc\bin");

            var operations = calc.Operations;

            lbOperations.DataSource = operations;
            lbOperations.DisplayMember = "Name";
            lbOperations.SelectedIndex = 0;
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDescription.Text = "";
            Operation = lbOperations.SelectedItem as IDisplayOperation;

            if (DispOperation != null)
            {
                lbDescription.Text = string.Format("Автор:{0}{1}Описание:{2}", DispOperation.Author, Environment.NewLine, !string.IsNullOrWhiteSpace(DispOperation.Description) ? DispOperation.Description : "нет описания");
            }

            tbX.Focus();
        }

        private void Calculate()
        {
            //определяем входные данные
            var x = Calc.ToNumb(tbX.Text);
            var y = Calc.ToNumb(tbY.Text);
            try
            {
                //вычислям 
                var result = calc.Execute(Operation.Execute, new[] { x, y });

                var LastOperationName = DispOperation != null ? DispOperation.DisplayName : Operation.Name;

                //возвращаем результат
                lblResult.Text = string.Format("{0} {1} {2} = {3}", x, Operation.Name, y, result);
            }
            catch (NotSupportedException ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {

            //определяем операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (Operation == null)
            {
                lblResult.Text = "Выбери нормальную операцию";
                return;
            }
            Calculate();
        }

        private void tbX_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbX.Text != "")
                if (e.KeyCode == Keys.Enter)
                    tbY.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lastPressTime.HasValue)
            {
                var diffTime = DateTime.Now - lastPressTime.Value;

                if (diffTime.TotalMilliseconds >= 300)
                {
                    Calculate();
                    lastPressTime = null;
                    timer1.Stop();
                }
            }
        }
    }
}

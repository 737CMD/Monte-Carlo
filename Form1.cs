namespace Monte_Carlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (EvalModeBox.Checked)
            {
                CalcTree ExprTree = new CalcTree(expressionTB.Text.Replace(" ", ""));
                EqRes.Text = "Result = " + (Math.Round(ExprTree.Eval(float.Parse(lowerLim.Text)), 4)).ToString();
            }
            else
            {
                float lowlimit = float.Parse(lowerLim.Text);
                float uplimit = float.Parse(upperLim.Text);
                float eps = float.Parse(resTb.Text);
                int points = pointsBar.Value;
                lowerLim.Enabled = false;
                upperLim.Enabled = false;
                resTb.Enabled = false;
                pointsBar.Enabled = false;
            }
            /*lowerLim.Enabled = true;
            upperLim.Enabled = true;
            resTb.Enabled = true;
            pointsBar.Enabled = true;*/
        }

        private void pointsBar_Scroll(object sender, EventArgs e)
        {
            Points_per_cycle.Text = "Points per cycle: " + (pointsBar.Value * 1000).ToString();
        }

        private void EvalModeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EvalModeBox.Checked) 
            {
                Limits_of_integration.Text = "x = ";
                upperLim.Visible = false;
                Residual.Visible = false;
                resTb.Visible = false;
                pointsBar.Visible = false;
                Points_per_cycle.Visible = false;
            }
            else
            {
                Limits_of_integration.Text = "Limits of integration: ";
                upperLim.Visible = true;
                Residual.Visible = true;
                resTb.Visible = true;
                pointsBar.Visible = true;
                Points_per_cycle.Visible = true;
            }
        }
    }
}

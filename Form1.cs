using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Monte_Carlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void DrawChart(CalcTree tree, float x1, float x2)
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.LegendText = "Plot of " + expressionTB.Text;
            Ichart.ChartAreas[0].AxisX.Minimum = x1 - (x2 - x1) / 10;
            Ichart.ChartAreas[0].AxisX.Maximum = x2 + (x2 - x1) / 10;
            Ichart.Series.Add(series);
            Series points = new Series();
            points.ChartType = SeriesChartType.Point;
            points.MarkerSize = 3;
            points.LegendText = "Random points";
            points.Color = Color.Black;
            series.Color = Color.Red;
            Ichart.Series.Add(points);
            // Calculate step size based on interval between x1 and x2
            float step = (x2 - x1) / 1000;

            // Add points to the series
            for (float x = x1; x <= x2; x += step)
            {
                if (x == 0) continue;
                double y = tree.Eval(x); // calculate y for each x
                series.Points.AddXY(x, y);
            }
        }
        internal void DrawPoint(List<mcPoint> points)
        {
            foreach (mcPoint p in points)
            {
                Ichart.Series[1].Points.AddXY(p.X, p.Y);
            }
        }
        private void Calculate_Click(object sender, EventArgs e)
        {
            Ichart.Series.Clear();
            CalcTree ExprTree = new CalcTree(expressionTB.Text.Replace(" ", ""));
            if (EvalModeBox.Checked)
            {
                if(lowerLim.Text != "") EqRes.Text = "Result = " + (Math.Round(ExprTree.Eval(float.Parse(lowerLim.Text)), 4)).ToString();
                else EqRes.Text = "Result = " + (Math.Round(ExprTree.Eval(), 4)).ToString();
            }
            else
            {
                float lowlimit = float.Parse(lowerLim.Text);
                float uplimit = float.Parse(upperLim.Text);
                float eps = float.Parse(resTb.Text);
                int points = pointsBar.Value;
                evalmode();
                Update();
                DrawChart(ExprTree, lowlimit, uplimit);
                if (threadNumb.Text != "") { Task MCeval = Task.Factory.StartNew(delegate () { MC_eval.Calc(lowlimit, uplimit, ExprTree, eps, points, this, demCB.Checked, haMode.Checked, int.Parse(threadNumb.Text)); }); }
                else { Task MCeval = Task.Factory.StartNew(delegate () { MC_eval.Calc(lowlimit, uplimit, ExprTree, eps, points, this, demCB.Checked, haMode.Checked); }); }
            }            
        }
        public void evalmode()
        {
            demCB.Enabled = !(demCB.Enabled);
            haMode.Enabled = !(haMode.Enabled);
            EvalModeBox.Enabled = !(EvalModeBox.Enabled);
            threadNumb.Enabled = !(threadNumb.Enabled);
            expressionTB.Enabled = !(expressionTB.Enabled);
            lowerLim.Enabled = !(lowerLim.Enabled);
            upperLim.Enabled = !(upperLim.Enabled);
            resTb.Enabled = !(resTb.Enabled);
            pointsBar.Enabled = !(pointsBar.Enabled);
            Calculate.Enabled = !(Calculate.Enabled);
        }
        private void pointsBar_Scroll(object sender, EventArgs e)
        {
            Points_per_cycle.Text = "Points per cycle per 1: " + (pointsBar.Value).ToString();
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
        public string EqResText
        {
            get => EqRes.Text; 
            set => EqRes.Text = value;
        }
        public string IterTickText
        {
            get => IterTicker.Text;
            set => IterTicker.Text = value;
        }
    }
}

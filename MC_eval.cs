using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Monte_Carlo
{
    internal static class MC_eval
    {
        public static (double min, double max) FindMinMax(float x1, float x2, CalcTree tree, float eps)
        {
            double minVal = double.MaxValue;
            double maxVal = double.MinValue;
            for (float x = x1; x <= x2; x += eps)
            {
                double y = tree.Eval(x);

                if (y < minVal)
                {
                    minVal = x;
                }

                if (y > maxVal)
                {
                    maxVal = x;
                }
            }
            return (minVal, maxVal);
        }
        public static void Calc(float lowlimit, float uplimit, CalcTree ExprTree, float eps, int points, Form1 form)
        {
            int iter = 0;
            while(iter < 10000)
            {
                Thread.Sleep(100);
                iter += 1;
                Action action = () => form.EqResText = iter.ToString();
                form.BeginInvoke(action);
            }
            form.evalmode();
        }
    }
}

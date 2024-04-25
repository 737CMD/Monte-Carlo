using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Monte_Carlo
{
    internal struct mcPoint
    {
        public mcPoint(float x, float y) { X = x; Y = y; }
        public float X, Y;
    }
    internal static class MC_eval
    {
        private static Semaphore _lacc = new Semaphore(1, 1);
        static Random rng = new Random();
        public static (double, double ) FindMinMax(float x1, float x2, CalcTree tree, float eps)
        {
            double minVal = double.MaxValue;
            double maxVal = double.MinValue;
            for (float x = x1; x <= x2; x += eps)
            {
                double y = tree.Eval(x);

                if (y < minVal)
                {
                    minVal = y;
                }

                if (y > maxVal)
                {
                    maxVal = y;
                }
            }
            return (minVal, maxVal);
        }
        public static void Calc(float lowlimit, float uplimit, CalcTree ExprTree, float eps, int pd, Form1 form)
        {
            double min, max;
            (min, max) = FindMinMax(lowlimit, uplimit, ExprTree, eps);
            double s = (max - min) * (uplimit - lowlimit);
            float p = 0;
            int points = 0;
            int spoints = 0;
            float delta = 0;
            int N = 3;
            int digits = 0;
            int iterpoints = (int)Math.Round((uplimit - lowlimit) * pd/N);
            while (Math.Pow(10, (-1) * digits) > eps) digits++;
            List<mcPoint> newPointlist = new List<mcPoint>();
            do
            {
                newPointlist.Clear(); 
                Task[] workers = new Task[N];
                for (int i = 0; i<workers.Length; i++)
                {
                    workers[i] = Task.Factory.StartNew(() => CheckIt(lowlimit, uplimit, ExprTree, min, max, iterpoints, newPointlist, ref spoints));
                    points += iterpoints;
                }
                Task.WaitAll(workers);
                delta = p - (float)spoints / points;
                p -= delta;s
                delta = Math.Abs(delta);
                Action formupd = delegate ()
                {
                    form.DrawPoint(newPointlist);
                    form.EqResText = "Points on plot: " + points.ToString();
                    form.IterTickText = "Current result " + Math.Round((s * p + min*(uplimit - lowlimit)), digits).ToString();
                };
                form.Invoke(formupd);
                //Thread.Sleep(100);
            }
            while(eps<delta);
            Action finish = form.evalmode;
            form.Invoke(finish);
        }
        private static void CheckIt(float lowlimit, float uplimit, CalcTree ExprTree, double min, double max, int howmuch, List<mcPoint> np, ref int spoints)
        {
            List<mcPoint> cp = new List<mcPoint>();
            int sp = 0;
            for (int i = 0; i<howmuch; i++)
            {
                cp.Add(new mcPoint((float)rng.NextDouble() * (uplimit - lowlimit) + lowlimit, (float)(rng.NextDouble() * (max - min) + min)));
                if (cp[i].Y < ExprTree.Eval(cp[i].X)) sp++;
            }
            _lacc.WaitOne();
            np.AddRange(cp);
            spoints += sp;
            _lacc.Release();
        }
    }
}

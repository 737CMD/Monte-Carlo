using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo
{
    abstract internal class Node
    {
        protected Node left;
        protected Node right;
        protected Node(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        abstract public double Eval(float x = 1); 
    }
    internal class Value : Node
    {
        float val;
        public Value(string val) : base (null, null)
        {
            this.val = float.Parse(val);
        }
        public override double Eval(float x = 1) { return val; }
    }
    internal class XArg : Node
    {
        public XArg(): base (null,null) {  }
        public override double Eval(float x) {  return x; }
    }
    internal class Plus : Node
    {
        public Plus(Node left, Node right) : base(left, right) { }
        public override double Eval(float x) { return left.Eval(x) + right.Eval(x); }
    }
    internal class Minus : Node
    {
        public Minus(Node left, Node right) : base(left, right) { }
        public override double Eval(float x) { return left.Eval(x) - right.Eval(x); }
    }
    internal class MulP : Node
    {
        public MulP(Node left, Node right) : base(left, right) { }
        public override double Eval(float x) { return left.Eval(x) * right.Eval(x); }
    }
    internal class Div : Node
    {
        public Div(Node left, Node right) : base(left, right) { }
        public override double Eval(float x) { return left.Eval(x) / right.Eval(x); }
    }
    internal class Pw : Node
    {
        public Pw(Node left, Node right) : base(left, right) { }
        public override double Eval(float x) { return Math.Pow(left.Eval(x), right.Eval(x)); }
    }

    internal class CalcTree
    {
        Node RootNode;
        public CalcTree(string expr) {
            RootNode = MakeTree(expr);
        }
        public double Eval(float x = 1)
        {
            return RootNode.Eval(x);
        }
        private static Node MakeTree(string expr)
        {
            int currprior = 50;
            int openPar = 0;
            int k = 0;
            for( int i = 0; i < expr.Length; i++ )
            {
                if (expr[i] == '(') { openPar++; continue; }
                if (expr[i] == ')') 
                { 
                    if (i == expr.Length - 1 && k == 0) return MakeTree(expr.Remove(expr.Length-1, 1).Remove(0,1));
                    else openPar--; continue; 
                }
                if (openPar != 0)  continue;
                if(Prior(expr[i]) <= currprior)
                {
                    k = i;
                    currprior = Prior(expr[i]);
                }
            }
            if(k == expr.Length-1)
            {
                if (expr[k] == 'x')
                {
                    return new XArg();
                }
                else return new Value(expr);
            }
            else
            {
                string sr = expr.Substring(0, k);
                string sl = expr.Substring(k + 1);
                switch (expr[k])
                {
                    case '+': return new Plus(MakeTree(sr), MakeTree(sl));
                    case '-': return new Minus(MakeTree(sr), MakeTree(sl));
                    case '*': return new MulP(MakeTree(sr), MakeTree(sl));
                    case '/': return new Div(MakeTree(sr), MakeTree(sl));
                    case '^': return new Pw(MakeTree(sr), MakeTree(sl));
                    default: Console.WriteLine("Error"); return null;
                }
            }

        }
        private static int Prior(char i)
        {
            switch (i)
            {
                case '+': case '-': return 1;
                case '*': case '/': return 2;
                case '^': return 3;
                default: return 50;
            }
        }
    }
}

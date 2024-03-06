using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    public abstract class OperatorNode : Node
    {
        public OperatorNode(char c)
        {
            Operator = c;
            Left = Right = null;
        }

        public char Operator { get; set; }

        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public enum associativityVals
        {
            L = 1,
            R = 2
        }
        public associativityVals associativity;
        public int precedence;
    }
}

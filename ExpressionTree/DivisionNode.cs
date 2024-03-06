using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    internal class DivisionNode : OperatorNode
    {
        public DivisionNode(char c) : base(c)
        {
            associativity = associativityVals.L;
            this.precedence = 2;
        }

        public override double evaluate()
        {
            return this.Left.evaluate() / this.Right.evaluate();
        }
    }
}

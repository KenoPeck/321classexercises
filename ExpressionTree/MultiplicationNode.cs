using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    internal class MultiplicationNode : OperatorNode
    {
        public MultiplicationNode(char c) : base(c)
        {
            associativity = associativityVals.L;
            this.precedence = 3;
        }

        public override double evaluate()
        {
            return this.Left.evaluate() * this.Right.evaluate();
        }
    }
}

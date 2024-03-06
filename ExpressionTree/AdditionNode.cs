using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    internal class AdditionNode : OperatorNode
    {
        public AdditionNode(char c) : base(c)
        {
            associativity = associativityVals.L;
            this.precedence = 1;
        }

        public override double evaluate()
        {
            return this.Left.evaluate() + this.Right.evaluate();
        }
    }
}

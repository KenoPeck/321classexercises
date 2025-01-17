﻿// <copyright file="MultiplicationNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OperatorLibrary
{
    /// <summary>
    /// Multiplication node class.
    /// </summary>
    internal class MultiplicationNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationNode"/> class.
        /// </summary>
        /// <param name="c">operator char value.</param>
        public MultiplicationNode(char c)
            : base(c)
        {
            this.Associativity = AssociativityVals.L;
            this.Precedence = 3;
        }

        /// <summary>
        /// Evaluates the multiplication node.
        /// </summary>
        /// <returns>evaluated double value of self + children.</returns>
        public override double Evaluate()
        {
            if (this.Right == null || this.Left == null)
            {
                throw new System.Exception("Invalid expression");
            }

            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}

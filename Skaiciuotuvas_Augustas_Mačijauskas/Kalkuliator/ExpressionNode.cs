using System.Collections.Generic;
using System.Windows.Forms;

namespace Kalkuliator
{
    public class ExpressionNode
    {
        public string Symbol { get; set; }

        public TreeNodeType TreeNodeType { get; set; }

        public List<ExpressionNode> Children { get; set; }

        public ExpressionNode()
        {
            Children = new List<ExpressionNode>();
        }

        public static explicit operator ExpressionNode(char node)
        {
            if (char.IsDigit(node))
            {
                return new ExpressionNode()
                {
                    Symbol = node.ToString(),
                    TreeNodeType = TreeNodeType.DIGIT
                };
            }

            if (node == '+' || node == '-' || node == '*' || node == '/' || node == '^')
            {
                return new ExpressionNode()
                {
                    Symbol = node.ToString(),
                    TreeNodeType = TreeNodeType.ARITHMETIC_OPERATOR
                };
            }

            if (node == '(' || node == ')')
            {
                return new ExpressionNode()
                {
                    Symbol = node.ToString(),
                    TreeNodeType = TreeNodeType.GROUP
                };
            }

            if (node == ',')
            {
                return new ExpressionNode()
                {
                    Symbol = ",",
                    TreeNodeType = TreeNodeType.DIGIT
                };
            }

            throw new InvalidExpressionException();
        }
    }
}

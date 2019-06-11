using System.Collections.Generic;

namespace Skaiciuokle
{
    public class SyntaxNode
    {
        public string Symbol { get; set; }
        
        public NodeType NodeType { get; set; }
        
        public List<SyntaxNode> Children { get; set; }

        public SyntaxNode()
        {
            Children = new List<SyntaxNode>();
        }

        public static explicit operator SyntaxNode(char node)
        {
            if (char.IsDigit(node))
            {
                return new SyntaxNode()
                {
                    Symbol = node.ToString(),
                    NodeType = NodeType.Digit
                };
            }

            if (node == '+' || node == '-' || node == '*' || node == '/' || node == '^')
            {
                return new SyntaxNode()
                {
                    Symbol = node.ToString(),
                    NodeType = NodeType.ArithmeticOperator
                };
            }

            if (node == '(' || node == ')')
            {
                return new SyntaxNode()
                {
                    Symbol = node.ToString(),
                    NodeType = NodeType.Group
                };
            }

            if (node == ',')
            {
                return new SyntaxNode()
                {
                    Symbol = ",",
                    NodeType = NodeType.Digit,
                };
            }
            
            throw new CompileErrorException();
        }
    }
}
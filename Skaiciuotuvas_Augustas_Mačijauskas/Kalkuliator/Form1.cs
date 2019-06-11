using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Kalkuliator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<ExpressionNode> GetAbstractSyntaxTree(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new InvalidExpressionException();
            }

            if (Regex.IsMatch(input, @"^-?\d(,?\d+|\d*)$"))
            {
                return new List<ExpressionNode>()
                {
                    new ExpressionNode()
                    {
                        Symbol = input,
                        TreeNodeType = TreeNodeType.DIGIT
                    }
                };
            }

            List<ExpressionNode> tree = new List<ExpressionNode>();
            List<ExpressionNode> nodes = new List<ExpressionNode>();
            int bracketsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                ExpressionNode current = (ExpressionNode)input[i];

                Action<ExpressionNode> compileGroup = (node) =>
                {
                    i++;
                    int index = i;
                    bracketsCount++;

                    while (bracketsCount != 0 && index < input.Length)
                    {
                        if (input[index] == '(')
                        {
                            bracketsCount++;
                        }
                        else if (input[index] == ')')
                        {
                            bracketsCount--;
                        }

                        nodes.Add((ExpressionNode)input[index]);
                        index++;
                    }

                    node.Children.AddRange(GetAbstractSyntaxTree(input.Substring(i, index - i - 1)));
                    i = index - 1;
                };

                Action<ExpressionNode> compileDigit = (node) =>
                {
                    int start = i + 1;

                    if (node.Symbol == "-")
                    {
                        node.TreeNodeType = TreeNodeType.DIGIT;
                    }

                    while (i + 1 < input.Length && (Char.IsDigit(input[i + 1]) || input[i + 1] == ','))
                    {
                        node.Symbol += input[i + 1];
                        nodes.Add(node);
                        i++;
                    }

                    if (node.Symbol.Count(x => x == ',') > 1)
                    {
                        throw new InvalidExpressionException();
                    }
                };

                if (current.TreeNodeType == TreeNodeType.GROUP)
                {
                    compileGroup(current);
                    tree.Add(current);

                    if (i + 1 < input.Length && ((ExpressionNode)input[i + 1]).TreeNodeType != TreeNodeType.ARITHMETIC_OPERATOR)
                    {
                        throw new InvalidExpressionException();
                    }
                }

                if (i != 0 && current.TreeNodeType == TreeNodeType.ARITHMETIC_OPERATOR)
                {
                    if (i == input.Length - 1)
                    {
                        throw new InvalidExpressionException();
                    }

                    ExpressionNode next = (ExpressionNode)input[i + 1];

                    if (next.TreeNodeType != TreeNodeType.DIGIT && next.TreeNodeType != TreeNodeType.GROUP)
                    {
                        throw new InvalidExpressionException();
                    }

                    if (nodes[i - 1].TreeNodeType != TreeNodeType.DIGIT && nodes[i - 1].TreeNodeType != TreeNodeType.GROUP)
                    {
                        throw new InvalidExpressionException();
                    }

                    current.Children.Add(nodes[i - 1]);
                    i++;

                    if (next.TreeNodeType == TreeNodeType.GROUP)
                    {
                        compileGroup(next);
                        tree.Add(current);
                        tree.Add(next);

                        nodes.Add(current);
                        nodes.Add(next);
                    }
                    else if (next.TreeNodeType == TreeNodeType.DIGIT)
                    {
                        nodes.Add(current);
                        nodes.Add(next);

                        compileDigit(next);

                        tree.Add(current);
                    }
                    else
                    {
                        throw new InvalidExpressionException();
                    }

                    current.Children.Add(next);

                    continue;
                }

                if (i == 0 || current.TreeNodeType == TreeNodeType.DIGIT)
                {
                    compileDigit(current);
                }

                nodes.Add(current);
            }

            if (tree.Any(x => x.TreeNodeType == TreeNodeType.ARITHMETIC_OPERATOR))
            {
                return tree.Where(x => x.TreeNodeType == TreeNodeType.ARITHMETIC_OPERATOR).ToList();
            }

            if (tree.Count == 0 || tree.Count == 1)
            {
                return tree;
            }

            throw new InvalidExpressionException();
        }

        public static bool IsOperatorImportant(string op)
        {
            return op == "^" || op == "*" || op == "/";
        }

        public static double ArithmeticOperation(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;

                case "-":
                    return num1 - num2;

                case "*":
                    return num1 * num2;

                case "/":
                    if (num2 == 0.0)
                    {
                        throw new InvalidExpressionException();
                    }
                    return num1 / num2;

                case "^":
                    //MessageBox.Show(string.Format("num1: {0}; num2: {1}", num1, num2));
                    if (num2 > 0 && num2 < 1)
                    {
                        if (num1 >= 0)
                        {
                            return Math.Pow(num1, num2);
                        }
                        else
                        {
                            double exp = 1 / num2;
                            if (exp % 2 != 0)
                            {
                                return -Math.Pow(-num1, num2);
                            }
                        }
                        

                        throw new InvalidExpressionException();
                    }
                    else
                    {
                        if (num1 >= 0)
                        {
                            return Math.Pow(num1, num2);
                        }
                        else
                        {
                            return -Math.Pow(-num1, num2);
                        }
                    }


                default:
                    throw new InvalidExpressionException();
            }
        }

        public static double CompileNode(ExpressionNode node)
        {
            switch(node.TreeNodeType)
            {
                case TreeNodeType.DIGIT:
                    return double.Parse(node.Symbol);

                case TreeNodeType.ARITHMETIC_OPERATOR:
                    return ArithmeticOperation(CompileNode(node.Children[0]), CompileNode(node.Children[1]), node.Symbol);

                case TreeNodeType.GROUP:
                    return CompileAbstractSyntaxTree(node.Children);

                default:
                    throw new InvalidExpressionException();
            }
        }

        public static double CompileAbstractSyntaxTree(List<ExpressionNode> tree)
        {
            /*
            MessageBox.Show(tree.Count.ToString());   
            tree.ForEach(x => {
                MessageBox.Show("Operator: " + x.Symbol);
                x.Children.ForEach(y => { MessageBox.Show("Child" + y.Symbol); });
            });
            */
            
            int firstImportant = tree.FindIndex(x => IsOperatorImportant(x.Symbol));
            double result;

            Func<int, double> compileMostImportant = (index) =>
            {
                int lastImportant = index + 1;

                if (lastImportant == tree.Count || tree[lastImportant].Symbol != "^")
                {
                    double rez = CompileNode(tree[index]);
                    tree[index] = null;
                    return rez;
                }

                while (lastImportant < tree.Count && tree[lastImportant].Symbol == "^")
                {
                    lastImportant++;
                }

                if (lastImportant == tree.Count)
                {
                    lastImportant--;
                }

                double tempResult = CompileNode(tree[lastImportant]);
                tree[lastImportant] = null;

                for (int i = lastImportant - 1; i >= index; i--)
                {
                    tempResult = ArithmeticOperation(
                        CompileNode(tree[i].Children.First()),
                        tempResult,
                        "^"
                    );

                    tree[i] = null;
                }

                return tempResult;
            };

            if (firstImportant < 0)
            {
                firstImportant = 0;
                result = CompileNode(tree[firstImportant]);
            }
            else
            {
                double first = CompileNode(tree[firstImportant].Children.First());
                double second = CompileNode(tree[firstImportant].Children.Last());

                if (firstImportant > 0 && tree[firstImportant - 1].Symbol == "-")
                {
                    first *= -1;
                }

                if (firstImportant + 1 == tree.Count || tree[firstImportant + 1].Symbol != "^")
                {
                    result = ArithmeticOperation(first, second, tree[firstImportant].Symbol);
                }
                else
                {
                    result = ArithmeticOperation(first, compileMostImportant(firstImportant + 1), tree[firstImportant].Symbol);
                }
            }

            for (int i = firstImportant + 1; i < tree.Count; i++)
            {
                if (tree[i] == null)
                {
                    continue;
                }

                string previousSymbol = i - 2 >= 0 && i != firstImportant + 1 ? tree[i - 2]?.Symbol : null;

                if (i + 1 < tree.Count && IsOperatorImportant(tree[i + 1].Symbol))
                {
                    double current = CompileNode(tree[i + 1]);
                    string currentSymbol = tree[i].Symbol;

                    i++;

                    while (i + 1 < tree.Count && IsOperatorImportant(tree[i + 1].Symbol))
                    {
                        if (i + 2 < tree.Count && tree[i + 2].Symbol == "^")
                        {
                            current = ArithmeticOperation(
                                current,
                                compileMostImportant(i + 2),
                                tree[i + 1].Symbol
                            );
                        }
                        else
                        {
                            current = ArithmeticOperation(
                                current,
                                CompileNode(tree[i + 1].Children.Last()),
                                tree[i + 1].Symbol
                            );
                        }

                        i++;
                    }

                    if (previousSymbol == "-" && currentSymbol != "-")
                    {
                        current *= -1;
                    }

                    result = ArithmeticOperation(
                        result,
                        current,
                        currentSymbol
                    );
                }
                else
                {
                    double rez = CompileNode(tree[i].Children.Last());

                    if (previousSymbol == "-" && tree[i].Symbol != "-")
                    {
                        rez *= -1;
                    }

                    result = ArithmeticOperation(
                        result,
                        rez,
                        tree[i].Symbol
                    );
                }
            }

            for (int i = firstImportant - 1; i >= 0; i--)
            {
                result = ArithmeticOperation(
                    result,
                    CompileNode(tree[i].Children.First()),
                    i - 1 >= 0 ? tree[i - 1].Symbol : "+"
                );
            }

            return result;
        }

        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            try
            {
                if (input.Text.Length == 0)
                {
                    output.Text = "";
                    return;
                }

                string stringInput = Regex.Replace(input.Text, @"\s", "");

                if (stringInput.Count(x => x == '(') != stringInput.Count(x => x == ')'))
                {
                    throw new InvalidExpressionException();
                }

                var tree = GetAbstractSyntaxTree(stringInput);
                var result = CompileAbstractSyntaxTree(tree);

                output.Text = result.ToString();
            }
            catch
            {
                output.Text = "Klaida";
            }
        }
    }
}

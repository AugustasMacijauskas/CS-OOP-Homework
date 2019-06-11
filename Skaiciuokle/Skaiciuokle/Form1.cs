using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Skaiciuokle
{
    public partial class Form1 : Form
    {
        public static List<SyntaxNode> GetSyntaxTree(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new CompileErrorException();
            }

            if (Regex.IsMatch(input, @"^-?\d(,?\d+|\d*)$"))
            {
                return new List<SyntaxNode>()
                {
                    new SyntaxNode()
                    {
                        Symbol = input,
                        NodeType = NodeType.Digit
                    }
                };
            }

            List<SyntaxNode> tree = new List<SyntaxNode>();
            List<SyntaxNode> nodes = new List<SyntaxNode>();
            int bracketsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                SyntaxNode current = (SyntaxNode)input[i];

                Action<SyntaxNode> compileGroup = (node) =>
                {
                    i++;

                    int index = i;

                    bracketsCount++;

                    while (bracketsCount != 0 && index < input.Length)
                    {
                        if (input[index] == '(')
                            bracketsCount++;
                        else if (input[index] == ')')
                            bracketsCount--;

                        nodes.Add((SyntaxNode)input[index]);

                        index++;
                    }

                    node.Children.AddRange(GetSyntaxTree(input.Substring(i, index - i - 1)));

                    i = index - 1;
                };

                Action<SyntaxNode> compileDigit = (node) =>
                {
                    int start = i + 1;

                    if (node.Symbol == "-")
                    {
                        node.NodeType = NodeType.Digit;
                    }

                    while (i + 1 < input.Length && (Char.IsDigit(input[i + 1]) || input[i + 1] == ','))
                    {
                        node.Symbol += input[i + 1];
                        nodes.Add(node);
                        i++;
                    }

                    if (node.Symbol.Count(x => x == ',') > 1)
                    {
                        throw new CompileErrorException();
                    }
                };

                if (current.NodeType == NodeType.Group)
                {
                    compileGroup(current);
                    tree.Add(current);

                    if (i + 1 < input.Length && ((SyntaxNode)input[i + 1]).NodeType != NodeType.ArithmeticOperator)
                    {
                        throw new CompileErrorException();
                    }
                }

                if (i != 0 && current.NodeType == NodeType.ArithmeticOperator)
                {
                    if (i == input.Length - 1)
                    {
                        throw new CompileErrorException();
                    }

                    SyntaxNode next = (SyntaxNode)input[i + 1];

                    if (next.NodeType != NodeType.Digit && next.NodeType != NodeType.Group)
                    {
                        throw new CompileErrorException();
                    }

                    if (nodes[i - 1].NodeType != NodeType.Digit && nodes[i - 1].NodeType != NodeType.Group)
                    {
                        throw new CompileErrorException();
                    }

                    current.Children.Add(nodes[i - 1]);
                    i++;

                    if (next.NodeType == NodeType.Group)
                    {
                        compileGroup(next);
                        tree.Add(current);
                        tree.Add(next);

                        nodes.Add(current);
                        nodes.Add(next);
                    }
                    else if (next.NodeType == NodeType.Digit)
                    {
                        compileDigit(next);
                        tree.Add(current);

                        nodes.Add(current);
                        nodes.Add(next);
                    }
                    else
                    {
                        throw new CompileErrorException();
                    }

                    current.Children.Add(next);

                    continue;
                }

                if (i == 0 || current.NodeType == NodeType.Digit)
                {
                    compileDigit(current);
                }

                nodes.Add(current);
            }

            if (tree.Any(x => x.NodeType == NodeType.ArithmeticOperator))
            {
                return tree.Where(x => x.NodeType == NodeType.ArithmeticOperator).ToList();
            }

            if (tree.Count == 0 || tree.Count == 1)
            {
                return tree;
            }

            throw new CompileErrorException();
        }

        public static bool IsImportantOperator(string op)
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
                    return num1 / num2;

                case "^":
                    if (num2 >= 1)
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
                    else if (num2 > 0 && num2 < 1)
                    {
                        double exp = 1 / num2;
                        if (exp % 2 != 0)
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

                        throw new CompileErrorException();
                    }
                    else
                    {
                        if (num1 >= 0)
                        {
                            return Math.Pow(1.0 / num1, num2);
                        }
                        else
                        {
                            return -Math.Pow(-1.0 / num1, num2);
                        }
                    }
                    return Math.Pow(num1, num2);
                    //MessageBox.Show(Math.Pow(-4, 1 / 3.0).ToString());
                    //MessageBox.Show(num2.ToString());
                    //double result = Math.Pow(num1, num2);
                    //if (result == double.NaN)
                    //{
                    //    if (Math.Pow(-num1, num2) != double.NaN)
                    //    {

                    //    }
                    //}
                    //return num1 > 0 ? Math.Pow(num1, num2) : -Math.Pow(-num1, num2);

                default:
                    throw new CompileErrorException();
            }
        }

        public static double CompileNode(SyntaxNode node)
        {
            switch (node.NodeType)
            {
                case NodeType.ArithmeticOperator:
                    return ArithmeticOperation(CompileNode(node.Children[0]), CompileNode(node.Children[1]), node.Symbol);

                case NodeType.Digit:
                    return double.Parse(node.Symbol);

                case NodeType.Group:
                    return Compile(node.Children);

                default:
                    throw new CompileErrorException();
            }
        }

        public static double Compile(List<SyntaxNode> tree)
        {
            int firstImportant = tree.FindIndex(x => IsImportantOperator(x.Symbol));
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

                double impResult = CompileNode(tree[lastImportant]);
                tree[lastImportant] = null;

                for (int i = lastImportant - 1; i >= index; i--)
                {
                    impResult = ArithmeticOperation(
                        CompileNode(tree[i].Children.First()),
                        impResult,
                        "^"
                    );

                    tree[i] = null;
                }

                return impResult;
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

                string prevSymbol = i - 2 >= 0 && i != firstImportant + 1 ? tree[i - 2]?.Symbol : null;

                if (i + 1 < tree.Count && IsImportantOperator(tree[i + 1].Symbol))
                {
                    double current = CompileNode(tree[i + 1]);
                    string currentSymbol = tree[i].Symbol;

                    i++;

                    while (i + 1 < tree.Count && IsImportantOperator(tree[i + 1].Symbol))
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

                    if (prevSymbol == "-" && currentSymbol != "-")
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

                    if (prevSymbol == "-" && tree[i].Symbol != "-")
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

        public Form1()
        {
            InitializeComponent();

            textBoxIn.TextChanged += (sender, e) =>
            {
                try
                {
                    if (textBoxIn.Text.Length == 0)
                    {
                        textBoxOut.Text = "";
                        return;
                    }

                    string input = Regex.Replace(textBoxIn.Text, @"\s", "");

                    if (input.Count(x => x == '(') != input.Count(x => x == ')'))
                    {
                        throw new CompileErrorException();
                    }

                    var tree = GetSyntaxTree(input);
                    var result = Compile(tree);

                    textBoxOut.Text = result.ToString();
                }
                catch
                {
                    textBoxOut.Text = "Klaida";
                }
            };
        }
    }
}

/*
 using System;

class MainClass {
  public static void Main (string[] args) {
    string num = "" + 1/3.0;
    Console.WriteLine(num);
    Console.WriteLine(num.Length);
    Console.WriteLine(Denominator(num));
  }

  static int Denominator(string number) {
    int len = number.Length;
    int numerator = 0;
    int numberOfDigitsToDecimal = 0;

    // Converting number to int
    for (int i = 0; i < len; i++) {
        if (number[i] == '.')
            break;

        numberOfDigitsToDecimal++;
        numerator = numerator * 10 + (number[i] - '0');
    }

    for (int i = numberOfDigitsToDecimal + 1; i < len; i++) {
        numerator = numerator * 10 + (number[i] - '0');
    }

    // Getting the denominator
    int denominator = getPower(len - numberOfDigitsToDecimal - 1);

    // If it happens that the number was already ant integer, the denominator must have been 1
    if (numberOfDigitsToDecimal == len)
        denominator = 1;

    int gcd = GCD(numerator, denominator);

    return denominator / gcd;
  }

  static int GCD(int a, int b) {
    return a == 0 ? b : GCD(b % a, a);
  }

  static int getPower(int pow) {
    int answer = 1;
    for (int i = 0; i < pow; i++) {
        answer *= 10;
    }
 
    return answer;
  }
}
*/

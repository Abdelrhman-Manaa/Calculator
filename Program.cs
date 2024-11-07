using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;

namespace CalculatorApp
{

    public abstract class CalcultorBase
    {
        public abstract decimal Calc(string opretor, decimal fristnum, decimal secondnum);
    }
    public class Calculator : CalcultorBase
    {
        private decimal _result;
        private decimal _fristnum;
        private decimal _secendnum;
        private string _opr;
        public decimal Result
        {
            get { return _result; }
            set { _result = value; }
        }
        public decimal Fristnum
        {
            get { return _fristnum; }
            set { _fristnum = value; }
        }
        public decimal Secondnum
        {
            get { return _secendnum; }
            set { _secendnum = value; }
        }
        public string Opr
        {
            get { return _opr; }
            set { _opr = value; }
        }


        public override decimal Calc(string opr, decimal fristnum, decimal secondnum)
        {
            switch (opr)
            {
                case "+":
                    return Add(fristnum, secondnum);
                case "-":
                    return Subtract(fristnum, secondnum);
                case "*":
                    return Multiply(fristnum, secondnum);
                case "/":
                    return Divide(fristnum, secondnum);
                default:
                    throw new Exception("Invalid Opretor");
            }
        }
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0)
            {
                throw new Exception("Cant divide by zero");
            }
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            string NewOpreation;
            
                do
                {
                try
                {
                    Console.Write("Enter the frist number : ");
                    calculator.Fristnum = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter an operation (+, -, *, /) : ");
                    calculator.Opr = Console.ReadLine().Trim();

                    Console.Write("Enter the second number : ");
                    calculator.Secondnum = Convert.ToDecimal(Console.ReadLine());

                    calculator.Result = calculator.Calc(calculator.Opr, calculator.Fristnum, calculator.Secondnum);

                    Console.WriteLine("Result: " + calculator.Fristnum + " " + calculator.Opr + " " + calculator.Secondnum + " = " + calculator.Result);

                    Console.WriteLine("Press E to End... if you want to continue press any key else");
                    NewOpreation = Console.ReadLine();

                }
            catch (Exception exp)
            {
                Console.WriteLine("Error: " + exp.Message);
                    Console.WriteLine("Press E to End... if you want to continue press any key else");
                    NewOpreation = Console.ReadLine();
                }
        } while (NewOpreation != "e");
            // Console.ReadKey();
        }
    }
}

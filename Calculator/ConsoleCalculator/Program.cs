using System.Windows;

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] actions = new string[] { "+", "-", "*", "/", "**" };
            string result = string.Empty;
            string num1;
            string num2;
            while (Checked())
            {

                Console.Clear();
                if(result == string.Empty | result == "?") num1 = InputValue(1);
                else num1 = result;
                num2 = InputValue(2);
                string action = InputValue(actions);
                result = MathAction(action, num1, num2);
                Console.WriteLine($"\n {num1} {action} {num2} = {result}");    
            }    
        }

        static string MathAction(string action, string num1, string num2)
        {
            string result = string.Empty;
            switch(action)
            {
                case "+": result = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString(); break;
                case "-": result = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString(); break;
                case "*": result = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString(); break;
                case "/": result = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString(); break;
                case "**": result = (Math.Pow(Convert.ToDouble(num1), Convert.ToDouble(num2))).ToString(); break;
            }
            return result;
        }
        static bool Checked()
        {
            Console.WriteLine("\nЗапустить: любая кнопка" +
                              "\nВыход: q\n\n");
            string? answer = Console.ReadLine();
            if (answer == "q") return false;
            else return true;
        }
        static string InputValue(byte count)
        {   
            try
            {
                Console.WriteLine($"\nВведите {count}-е число:\n");
                double num = Convert.ToDouble(Console.ReadLine());
                return num.ToString();
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Вы ввели не число!\n");
                return InputValue(count);
            }
        }

        static string InputValue(string[] actions)
        {
            try
            {
                Console.Clear();
                GetElements(actions);
                Console.WriteLine("\nВыберите действие:\n");
                string? action = Console.ReadLine();
                action = actions[Convert.ToInt32(action) - 1];
                return action;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nВы ввели не число!\n");
                return InputValue(actions);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\nВведите одно значение!\n");
                return InputValue(actions);
            }
        }
        static void GetElements(string[] array)
        {
            Console.WriteLine("\n");
            for (int i = 1; i <= array.Length; i++)
            {
                Console.Write($"{i}    ");
                Console.Write($"{array[i - 1]} \n\n");
            }
        } 
    }
}

 


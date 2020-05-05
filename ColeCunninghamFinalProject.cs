using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the following information");
            Console.WriteLine("How much do you annually spend?");
            int annualyspent = int.Parse(Console.ReadLine());
            int retirementmoney = annualyspent * 25;
            Console.WriteLine("How old are you?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("At what age do you plan to retire?");
            int retirementage = int.Parse(Console.ReadLine());
            int savingsyears = retirementage - age;
            RunMenu();
            string choice;
            do
            {
                choice = Console.ReadLine();
            }
            while (choice != "1" && choice != "2" && choice != "3");

            if (choice == "1")
            {
                RunSpendinginRetirementModule(retirementmoney);
            }
            if (choice == "2")
            {
                RunSavingsRightNowModule(savingsyears, retirementage);
            }
            if (choice == "3")
            {
                RunSavingsNeededModule(savingsyears, retirementmoney);
            }
        }

        public static void RunSpendinginRetirementModule(int moneyinretirement)
        {
            Console.WriteLine("Spending in Retirement");
            Console.WriteLine("How much do you annually spend?");
            double retirementspent = moneyinretirement * 0.03;
            Console.WriteLine("Based on how much you annually spend, you will need {0} for retirement.", moneyinretirement.ToString("C"));
            Console.WriteLine("You can spend {0} each year during retirement.", retirementspent.ToString("C"));
        }

        public static void RunSavingsRightNowModule(int num1, int num2)
        {
            Console.WriteLine("Current Savings");
            Console.WriteLine("How much are you currently saving a month?");
            double savingmonth = double.Parse(Console.ReadLine());
            double savinginyear = savingmonth * 12;
            double retirementsavings = savinginyear * num1;
            Console.WriteLine("At the rate you are saving, you will have {0} when you retire at age {1}.", retirementsavings.ToString("C"), num2);
            Console.WriteLine("Please enter your 3 biggest bills");
            double[] abc = new double[3];
            abc[0] = double.Parse(Console.ReadLine());
            abc[1] = double.Parse(Console.ReadLine());
            abc[2] = double.Parse(Console.ReadLine());
            double billssum = abc[0] + abc[1] + abc[2];
            Console.WriteLine("You are spending {0} a month on bills.", billssum.ToString("C"));
            Console.WriteLine("Can you cut back on any of these?");
            string billsdecision = Console.ReadLine();
            if (billsdecision == "yes")
            {
                Console.WriteLine("How much in total can you cut back?");
                int billssavingsamount = int.Parse(Console.ReadLine());
                double newsavingsamount = billssavingsamount + savingmonth;
                Console.WriteLine("You can now save {0} a month instead of {1}.", newsavingsamount.ToString("C"), savingmonth.ToString("C"));
            }
            if (billsdecision == "No")
            {
                Console.WriteLine("Ok");
            }
        }

        public static void RunSavingsNeededModule(int num1, int moneyinretirement)
        {
            Console.WriteLine("Savings Needed");
            Console.WriteLine("How much in savings do you have right now?");
            int savingsnow = int.Parse(Console.ReadLine());
            int savingsneeded = moneyinretirement - savingsnow;
            Console.WriteLine("Since you need {0} total but you already have {1}, then you will need {2}.", moneyinretirement.ToString("C"), savingsnow.ToString("C"), savingsneeded.ToString("C"));
            int savingsperyear = savingsneeded / num1;
            int savingspermonth = savingsperyear / 12;
            Console.WriteLine("You will have {0} years to save so you have to save {1} per year or {2} per month, if you did not have any annual returns from investments.", num1, savingsperyear.ToString("C"), savingspermonth.ToString("C"));
            double interestrate = 0.06;
            double rate = interestrate / 12;
            double yearrate = num1 * 12;
            double compoundinterestform = savingsnow * Math.Pow(1 + rate, yearrate);
            double futurevalue = moneyinretirement - compoundinterestform;
            double monthlycont = 1 / (((Math.Pow(1 + rate, yearrate) - 1) / rate) / futurevalue);
            double mcont = Math.Round(monthlycont, 2);
            Console.WriteLine("Assuming that you earned 6 percent on investments, you would need to invest {0} monthly in order to reach your retirement", mcont.ToString("C"));
        }

        public static void RunMenu()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.Write(" * ");
            }
            Console.WriteLine();
            Console.Write("Retirement Calculator");
            Console.WriteLine();
            for (int i = 0; i <= 10; i++)
            {
                Console.Write(" * ");
            }
            Console.WriteLine();
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1) Spending in Retirement");
            Console.WriteLine("2) Savings Right Now");
            Console.WriteLine("3) Savings Needed");
        }
    }
}
using System;
using System.Globalization;
using InstallmentsInterface.Entities;
using InstallmentsInterface.Entities.Services;

namespace InstallmentsInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());

            Console.Write("Data (dd/MM/yyyy): ");
            DateTime dateContract = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract value: ");
            double valueContract = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(contractNumber, dateContract, valueContract);

            ContractService contractSerice = new ContractService(new PaypalService());
            contractSerice.ProcessContract(myContract, months);

            Console.WriteLine("Installments:");
            foreach(Installment installment in myContract.Installment)
            {
                Console.WriteLine(installment);
            }
        }
    }
}

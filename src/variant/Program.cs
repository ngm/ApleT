using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant
{
    class Options
    {
        [Option('c', "customer", Required = true, HelpText = "Customer to run the app for")]
        public string Customer { get; set; }

        [Option('d', "next_audit_date", Required = false, HelpText = "Set the next audit date")]
        public bool Catalog { get; set; }

        [Option('r', "change_request", Required = false, HelpText = "Sends a change request email")]
        public bool ChangeRequest { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

    public enum Customer
    {
        A,
        B,
        C,
        UNKNOWN
    }

    class Program
    {
        static void Main(string[] args)
        {
            var customer = Customer.UNKNOWN;

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                switch (options.Customer.ToUpper())
                {
                    case "A":
                        customer = Customer.A;
                        break;
                    case "B":
                        customer = Customer.B;
                        break;
                    case "C":
                        customer = Customer.C;
                        break;
                }

                WriteWelcome(customer);

                if (options.Catalog)
                {
                    Console.WriteLine("Available Items");
                }

                if (options.ChangeRequest)
                {
                    Console.WriteLine("Change Request Email Sent");
                }
            }
        }

        private static void WriteWelcome(Customer customer)
        {
            Console.WriteLine("Welcome To Customer " + customer.ToString() + "'s Store!");
        }
    }
}

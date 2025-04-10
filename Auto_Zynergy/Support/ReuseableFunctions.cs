using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Zynergy.Support
{
    class ReuseableFunctions
    {

        GenericVariables genericVariables = new GenericVariables();

        private static Random random = new Random();
        public int GenerateRandom()
        {
            return random.Next(1, 100);
        }

        public long GenerateLegalIdentity()
        {
            //Random random = new Random();
            return (long)(random.NextDouble() * (9_999_999_999L - 1_000_000_000L) + 1_000_000_000L); // Generates a 10-digit number
        }

        public char GenerateRandomLetter()
        {
            Random rand = new Random();

            // Generate a random number between 0 and 25
            int randomIndex = rand.Next(0, 26);

            // Convert that number into a corresponding letter (A-Z)
            return (char)('A' + randomIndex);
        }

        public long GeneratePersonnummer()
        {
            // Random random = new Random();
            return (long)(random.NextDouble() * (9_999_999_999_999L - 1_000_000_000_000L) + 1_000_000_000_000L); // Generates a 12-digit number
        }

        public void SaveMeterIdToGenericVariable(string meterId)
        {
            // Save the value to the static field.
            GenericVariables.meterpointExternalId = meterId;
            Console.WriteLine("Saved Meter Id: " + GenericVariables.meterpointExternalId);
        }
    }
}

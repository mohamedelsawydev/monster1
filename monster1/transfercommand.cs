using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monster1
{
    internal class transfercommand
    {
        public static void handle(Guid id1,Guid id2 , decimal amount, IAccountRepo repo)
        {
            var account1 = repo.getaccount(id1);
            var account2 = repo.getaccount(id2);
            if (account1 == null || account2 == null)
            {
                throw new ArgumentException("One or both accounts do not exist.");
            }
         
            try
            {
                repo.withdraw(id1 ,amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

            try
            {
                repo.add(id2, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

        }
    }
}

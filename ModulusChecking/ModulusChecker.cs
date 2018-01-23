using System.Runtime.CompilerServices;
using ModulusChecking.Loaders;
using ModulusChecking.Models;
using ModulusChecking.Steps;

[assembly: InternalsVisibleTo("ModulusCheckerTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace ModulusChecking
{
    public class ModulusChecker
    {
        private readonly IModulusWeightTable _weightTable;

        public ModulusChecker()
        {
            _weightTable = ModulusWeightTable.GetInstance;
        }

        public bool CheckBankAccount(string sortCode, string accountNumber)
        {
            var bankAccountDetails = new BankAccountDetails(sortCode, accountNumber);
            bankAccountDetails.WeightMappings = _weightTable.GetRuleMappings(bankAccountDetails.SortCode);
            return new ConfirmDetailsAreValidForModulusCheck().Process(bankAccountDetails);
        }
    }
}

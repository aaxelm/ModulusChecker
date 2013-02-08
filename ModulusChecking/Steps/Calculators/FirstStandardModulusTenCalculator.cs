using System.Diagnostics;
using System.Linq;
using ModulusChecking.Loaders;
using ModulusChecking.Models;

namespace ModulusChecking.Steps.Calculators
{
    class FirstStandardModulusTenCalculator : BaseModulusCalculator
    {
         public override bool Process(BankAccountDetails bankAccountDetails)
        {
            ValidateEnoughMappingRulesForStepCount(bankAccountDetails, ModulusWeightMapping.Step.First);
            return ProcessWeightingRule(bankAccountDetails, bankAccountDetails.WeightMappings.First());
        }
    }
}
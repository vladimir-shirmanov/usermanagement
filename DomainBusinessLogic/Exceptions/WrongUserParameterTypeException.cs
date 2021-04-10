using System;

namespace DomainBusinessLogic.Exceptions
{
    public class WrongUserParameterTypeException : Exception
    {
        public WrongUserParameterTypeException(string strategyName)
            : base($"You pass user of the wrong type into {strategyName}.")
        {
        }
    }
}
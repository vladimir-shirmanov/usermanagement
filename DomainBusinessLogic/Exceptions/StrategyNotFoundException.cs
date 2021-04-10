using System;

namespace DomainBusinessLogic.Exceptions
{
    public class StrategyNotFoundException : Exception
    {
        public StrategyNotFoundException() :
            base("User Registration Strategy Not Found. Please implement a new strategy if you are passing a new user type")
        {
        }
    }
}
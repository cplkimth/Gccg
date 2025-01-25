namespace Gccg.Core.Exceptions
{
    internal class WrongCriteriaException : Exception
    {
        public string Criteria { get; private set; }

        public WrongCriteriaException(string criteria) : base($"criteria {criteria} is wrong.")
        {
            Criteria = criteria;
        }
    }
}
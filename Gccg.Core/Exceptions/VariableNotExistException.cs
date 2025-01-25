namespace Gccg.Core.Exceptions
{
    internal class VariableNotExistException : Exception
    {
        public string Variable { get; private set; }

        public VariableNotExistException(string variable) : base($"variable {variable} is not exist.")
        {
            Variable = variable;
        }
    }
}
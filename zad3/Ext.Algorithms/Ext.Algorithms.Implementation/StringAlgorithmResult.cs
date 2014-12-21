namespace Ext.Algorithms.Implementation
{
    public class StringAlgorithmResult : IAlgorithmResult
    {
        public StringAlgorithmResult(string result)
        {
            Result = result;
        }

        public string Result { get; private set; }
    }
}
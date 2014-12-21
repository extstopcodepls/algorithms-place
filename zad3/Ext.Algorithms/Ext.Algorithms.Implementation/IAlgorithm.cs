using System.Collections.Generic;

namespace Ext.Algorithms.Implementation
{
    public interface IAlgorithm
    {
        IAlgorithmResult Process();
        IAlgorithmResult Process(IEnumerable<string> fileContent);
    }
}
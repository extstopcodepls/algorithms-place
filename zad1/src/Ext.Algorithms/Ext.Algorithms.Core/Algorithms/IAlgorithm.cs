using Ext.Algorithms.Core.Algorithms.Results;

namespace Ext.Algorithms.Core.Algorithms
{
    public interface IAlgorithm
    {
        void Prepare();
        IAlgorithmResult Resolve();
    }
}

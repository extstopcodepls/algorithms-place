using Ext.Algorithms.Core.Algorithms.Config;
using Ext.Algorithms.Core.Algorithms.Inputs;
using Ext.Algorithms.Core.Algorithms.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.Core.Algorithms
{
    public interface IAlgorithm
    {
        void Prepare();
        IAlgorithmResult Resolve();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yab.DependencyInjection;

namespace Yab.Uid
{
    // 来源：https://github.com/jhtodd/SequentialGuid/blob/master/SequentialGuid/Classes/SequentialGuid.cs 

    /// <summary>
    /// 有序GUID产生器
    /// </summary>
    public class SequentialGuidGenerator : IGuidGenerator, ITransientDependency
    {
        public Guid Create()
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using Prism.Events;

namespace BASIC_MVVM_CORE.PrismEvent
{
    public class RunningPercentChanged : PubSubEvent<KeyValuePair<object,int>>
    {
    }
}
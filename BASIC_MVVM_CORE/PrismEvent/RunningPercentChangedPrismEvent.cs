using Prism.Events;
using System.Collections.Generic;

namespace BASIC_MVVM_CORE.PrismEvent
{
    public class RunningPercentChangedPrismEvent : PubSubEvent<KeyValuePair<object, int>>
    {
    }
}
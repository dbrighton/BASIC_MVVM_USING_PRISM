using Prism.Events;
using System.Collections.Generic;

namespace BASIC_MVVM_CORE.PrismEvent
{
    public class IsRunningStateChangedPrismEvent : PubSubEvent<KeyValuePair<object, bool>>
    {
    }
}
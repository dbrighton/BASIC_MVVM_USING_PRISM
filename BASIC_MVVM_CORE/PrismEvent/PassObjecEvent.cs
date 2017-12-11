using Prism.Events;
using System.Collections.Generic;

namespace BASIC_MVVM_CORE.PrismEvent
{
    public class PassObjecEvent : PubSubEvent<KeyValuePair<string, object>>
    {
    }
}
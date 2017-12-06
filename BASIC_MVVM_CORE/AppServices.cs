using Microsoft.Practices.Unity;
using Prism.Events;

namespace BASIC_MVVM_CORE
{
    public static class AppServices
    {
        public static UnityContainer Container { get; set; }
        public static EventAggregator EventAggregator { get; private set; }

        static AppServices()
        {
            Container = new UnityContainer();
            EventAggregator = new EventAggregator();
        }
    }
}
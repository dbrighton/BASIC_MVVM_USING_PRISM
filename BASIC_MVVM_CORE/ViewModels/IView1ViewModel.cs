using System.Threading.Tasks;
using System.Windows.Input;

namespace BASIC_MVVM_CORE.ViewModels
{
    public interface IView1ViewModel
    {
        bool IsRunning { get; set; }
        ICommand PassStringCmd { get; set; }
        int PercentCompleate { get; set; }
        ICommand StartAllUsingUnityCmd { get; set; }
        string StatusText { get; set; }
        void StopProcces();
        string StringToPass { get; set; }

        int View2PercentCompleate { get; set; }

        int View3PercentCompleate { get; set; }

        int View4PercentCompleate { get; set; }

        Task<bool> StartProccesAsync();
    }
}
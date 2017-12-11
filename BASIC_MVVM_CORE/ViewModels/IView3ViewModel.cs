using System.Threading.Tasks;
using System.Windows.Input;

namespace BASIC_MVVM_CORE.ViewModels
{
    public interface IView3ViewModel
    {
        bool IsRunning { get; set; }
        ICommand PassStringCmd { get; set; }
        int PercentCompleate { get; set; }
        string StatusText { get; set; }
        string StringToPass { get; set; }

        Task<bool> StartProccesAsync();

        void StopProcces();
    }
}
using System.Threading.Tasks;

namespace BASIC_MVVM_CORE.ViewModels
{
    public interface IViewTwoViewModel
    {
        int PercentCompleate { get; set; }
        bool IsRunning { get; set; }

        Task<bool> StartProccesAsync();

        int View1PercentCompleate { get; set; }
        int View3PercentCompleate { get; set; }
        int View4PercentCompleate { get; set; }
    }
}
using System.Threading.Tasks;

namespace BASIC_MVVM_CORE.ViewModels
{
    public interface IViewThreeViewModel
    {
        int PercentCompleate { get; set; }
        bool IsRunning { get; set; }

        Task<bool> StartProccesAsync();

        int View1PercentCompleate { get; set; }
        int View2PercentCompleate { get; set; }
        int View4PercentCompleate { get; set; }
    }
}
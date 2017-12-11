using System.Threading.Tasks;

namespace BASIC_MVVM_CORE.ViewModels
{
    public interface IViewOneViewModel
    {
        int PercentCompleate { get; set; }
        bool IsRunning { get; set; }

        Task<bool> StartProccesAsync();

        int View2PercentCompleate { get; set; }
        int View3PercentCompleate { get; set; }
        int View4PercentCompleate { get; set; }
    }
}
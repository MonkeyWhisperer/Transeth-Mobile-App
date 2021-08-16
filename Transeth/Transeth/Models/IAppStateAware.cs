using System.Threading.Tasks;

namespace Transeth.Models
{
    public interface IAppStateAware
    {
        void OnResumeApplicationAsync();
    }
}

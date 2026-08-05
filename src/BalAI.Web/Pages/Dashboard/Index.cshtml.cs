using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BalAI.Web.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        public Task OnGetAsync() => Task.CompletedTask;
    }
}

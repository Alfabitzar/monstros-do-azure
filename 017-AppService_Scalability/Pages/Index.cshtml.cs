using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace AppServiceBasic.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Propoerty to list all the environment variables
        /// </summary>
        public IDictionary Variables { get; private set; } = new Dictionary<string, string>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Get all the variables of the environment to list
            this.Variables = Environment.GetEnvironmentVariables();
        }
    }
}
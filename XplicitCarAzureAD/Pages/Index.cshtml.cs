using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XplicitCarAzureAD.Pages
{
    using System.IO.Pipes;

    using XplicitCarAzureAD.Services;

    public class IndexModel : PageModel
    {
        private XplicitApiClient client;

        public string[] Values { get; set; }

        public IndexModel(XplicitApiClient client)
        {
            this.client = client;
        }

        public async Task OnGet()
        {
            Values = await this.client.GetValues();
        }
    }
}

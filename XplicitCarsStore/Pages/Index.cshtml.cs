using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XplicitCarsStore.Pages
{
    using System.Net.Http;

    using Newtonsoft.Json;

    public class IndexModel : PageModel
    {
        private readonly HttpClient client;

       public string[] Values { get; set; }

        public IndexModel(IHttpClientFactory clientFactory)
        {
            this.client = clientFactory.CreateClient("sales");
        }

        public async Task OnGet()
        {
            var response = await this.client.GetAsync("/api/values");
            var content = await response.Content.ReadAsStringAsync();
            this.Values = JsonConvert.DeserializeObject<string[]>(content);
        }
    }
}

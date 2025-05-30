using GymGenius.DataAccess.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymGenius.Ui.Pages
{
    public class Gallery : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Gallery(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Gallery gallery;

        public string Message { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Message = "Invalid input.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");

            var json = JsonSerializer.Serialize(gallery);
            var content = new StringContent(json, Encoding.UTF8, "");

            var response = await client.PostAsync("/api/v1/Gallery", content);

            if (response.IsSuccessStatusCode)
            {
                Message = "Signed in successfully!";
                return RedirectToPage("/Gallery"); // or your dashboard
            }

            
            return Page();
        }
    }

   
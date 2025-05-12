using GymGenius.DataAccess.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymGenius.Ui.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignInModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public PeopleModel SignInUser { get; set; } = new();

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

            var json = JsonSerializer.Serialize(SignInUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/v1/people", content);

            if (response.IsSuccessStatusCode)
            {
                Message = "Signed in successfully!";
                return RedirectToPage("/Index"); // or your dashboard
            }

            Message = $"Failed to sign in: {response.StatusCode}";
            return Page();
        }
    }
}

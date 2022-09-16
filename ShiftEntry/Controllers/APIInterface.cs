using ShiftTrackerAPI.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


namespace ShiftEntry.Controllers
{
    internal static class APIInterface
    {
        private const string APIPATH = "https://localhost:7267/api/shifts";

        static internal async Task<List<Shift>> GetShifts()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# Requester");

            var streamTask = client.GetStreamAsync(APIPATH);

            var shifts = await JsonSerializer.DeserializeAsync<List<Shift>>(await streamTask);

            return shifts;
        }

        static internal async Task PostShift(Shift shift)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# Requester");

            var json = JsonSerializer.Serialize(shift);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            await client.PostAsync(APIPATH, content);
        }

        static internal async Task DeleteShift(int id)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# Requester");

            var path = APIPATH + "/" + id;
            await client.DeleteAsync(path);
        }

        static internal async Task PutShift(Shift shift)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# Requester");

            var path = APIPATH + "/" + shift.Id;
            var json = JsonSerializer.Serialize(shift);

            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            await client.PutAsync(path, content);
        }
    }
}

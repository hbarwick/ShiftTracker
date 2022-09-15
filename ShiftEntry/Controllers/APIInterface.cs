﻿using ShiftTrackerAPI.Models;
using System.Net.Http.Headers;
using System.Text.Json;


namespace ShiftEntry.Controllers
{
    internal static class APIInterface
    {
        private const string apiPath = "https://localhost:7267/api/shifts";

        static internal async Task<List<Shift>> GetShifts()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# Requester");

            var streamTask = client.GetStreamAsync(apiPath);

            var shifts = await JsonSerializer.DeserializeAsync<List<Shift>>(await streamTask);

            return shifts;
        }
    }
}
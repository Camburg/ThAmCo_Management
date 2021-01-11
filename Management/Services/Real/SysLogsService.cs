using Management.Dto;
using Management.Interfaces;
using Management.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Management.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Management.Services.Real
{
    public class SysLogsService : ISysLogsService
    {
        private readonly HttpClient _client;

        public SysLogsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<SystemLogDto>> GetAllSystemLogs()
        {
            List<SystemLogDto> logs;

            var response = await _client.GetAsync("logs");

            if (response.IsSuccessStatusCode)
            {
                var output = await response.Content.ReadFromJsonAsync<IEnumerable<SystemLogDto>>();
                logs = output.ToList();
            }
            else
            {
                logs = new List<SystemLogDto>();
            }

            return logs;
        }

        public async Task<List<SystemLogDto>> GetFilteredSystemLogs(Filter Filter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendSystemLog(string componentName, string details, string role, AlertType alertType)
        {
            var package = new SystemLogDto
            {
                AlertType = alertType,
                ComponentName = componentName,
                Details = details,
                Role = role,
                Id = new Guid(),
                Date = DateTime.Now
            };
            var content = new ObjectContent(typeof(SystemLogDto), package, new JsonMediaTypeFormatter());
            var response = await _client.PutAsync("logs", content);

            return response.IsSuccessStatusCode;
        }
    }
}

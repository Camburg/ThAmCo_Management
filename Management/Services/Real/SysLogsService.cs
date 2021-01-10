using Management.Dto;
using Management.Interfaces;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Management.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Management.Services.Real
{
    public class SysLogsService : ISysLogsService
    {
        private HttpClient _client;

        SysLogsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<SystemLogDto>> GetAllSystemLogs()
        {
            throw new NotImplementedException();
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
            _client.BaseAddress = new System.Uri("https://thamco-syslogs.azurewebsites.net/");
            HttpResponseMessage response = await _client.PutAsJsonAsync("/api/logs", JsonConvert.SerializeObject(package));

            return response.IsSuccessStatusCode;
        }
    }
}

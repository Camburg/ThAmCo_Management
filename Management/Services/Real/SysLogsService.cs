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
using System.Security.Cryptography;
using System.Threading.Tasks;
using Management.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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

        public async Task<List<SystemLogDto>> GetFilteredSystemLogs(Filter filter)
        {
            var returnLogs = await GetAllSystemLogs();
            if (filter.Date != default)
            {
                returnLogs = returnLogs.Where(x => x.Date.Date == filter.Date).ToList();
            }
            if (!filter.ComponentName.Equals("ANY"))
            {
                returnLogs = returnLogs.Where(x => x.ComponentName.Equals(filter.ComponentName)).ToList();
            }
            if (filter.AlertType != AlertType.ANY)
            {
                returnLogs = returnLogs.Where(x => x.AlertType == filter.AlertType).ToList();
            }
            if (!filter.Role.Equals("ANY"))
            {
                returnLogs = returnLogs.Where(x => x.Role.Equals(filter.Role)).ToList();
            }
            return returnLogs;
        }

        public async Task<bool> SendSystemLog(string componentName, string details, string role, AlertType alertType)
        {
            var package = new SystemLogDto
            {
                AlertType = alertType,
                ComponentName = componentName,
                Details = details,
                Role = role,
                Id = Guid.NewGuid(),
                Date = DateTime.Now
            };
            var content = new ObjectContent(typeof(SystemLogDto), package, new JsonMediaTypeFormatter());
            var response = await _client.PutAsync("logs", content);

            return response.IsSuccessStatusCode;
        }
    }
}

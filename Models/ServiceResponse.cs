﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzNamingTool.Models
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public dynamic ResponseObject { get; set; }
    }
}

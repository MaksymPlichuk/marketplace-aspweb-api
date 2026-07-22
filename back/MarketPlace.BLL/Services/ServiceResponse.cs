using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Services
{
    public class ServiceResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
        public object? Payload { get; set; } = null;
    }
}

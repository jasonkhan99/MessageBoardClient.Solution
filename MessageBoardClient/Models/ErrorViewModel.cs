using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace MessageBoardClient.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
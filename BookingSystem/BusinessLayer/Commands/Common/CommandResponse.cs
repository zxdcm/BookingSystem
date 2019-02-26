using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Commands.Common
{
    public class CommandResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

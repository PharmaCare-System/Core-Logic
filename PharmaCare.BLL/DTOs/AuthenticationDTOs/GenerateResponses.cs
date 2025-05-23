using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.AuthenticationDTOs
{
    public class GenerateResponses
    {
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
        public string? token { get; set; }

    }
}

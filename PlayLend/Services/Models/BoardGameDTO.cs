using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayLend.Services.Models
{
    public class BoardGameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerRange { get; set; }
        public string Description { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}
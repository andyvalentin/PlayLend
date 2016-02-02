using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayLend.Domain
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerRange { get; set; }
        public string Description { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
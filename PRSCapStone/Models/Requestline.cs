using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PRSCapStone.Models
{
    public class RequestLine
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Request Request { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }

        
    }
}

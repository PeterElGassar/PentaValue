using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.BasicModels
{
    public class Media
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public DateTime From_time { get; set; }
        public DateTime To_time { get; set; }
    }
}

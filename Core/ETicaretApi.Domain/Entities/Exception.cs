using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class Exception: BaseEntity
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

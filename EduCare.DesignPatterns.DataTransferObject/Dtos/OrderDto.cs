using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.DataTransferObject.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public string CompanyName { get; set; }
        public decimal Summary { get; set; }
    }
}

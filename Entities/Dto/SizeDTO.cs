using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class SizeDTO:IDto
    {
        public string SizeValue { get; set; }
        public int StockQuantity { get; set; }

       
    }
}

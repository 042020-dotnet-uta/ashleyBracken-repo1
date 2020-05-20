using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SleepingSelkie.Models
{/// <summary>
/// Order List to store recieved orders from the user
/// </summary>
    public class OrderListModel
    {
        public List<InventoryViewModel> order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.Interfaces;

namespace TopNewsApi.Core.Entities
{
    public class DashboardAccess : IEntity
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
    }
}

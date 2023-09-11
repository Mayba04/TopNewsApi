using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.Interfaces;

namespace TopNewsApi.Core.Entities
{
    public class Category: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Post> Post { get; set; }
    }
}

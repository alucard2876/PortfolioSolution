using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.Domain.Entitys
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedTime { get; protected set; }
        public DateTime LastChangedTime { get; protected set; }
    }
}

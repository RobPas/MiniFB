using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniFB.Entities.Abstract
{
    public interface IEntity
    {
        Guid ID { get; set; }
    }
}

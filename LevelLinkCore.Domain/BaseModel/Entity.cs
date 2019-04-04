using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Domain.BaseModel
{
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }
    }
}

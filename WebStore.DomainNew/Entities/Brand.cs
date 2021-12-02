using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base.Interfaces;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}

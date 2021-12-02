using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

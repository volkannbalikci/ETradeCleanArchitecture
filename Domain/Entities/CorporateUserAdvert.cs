using Core.Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class CorporateUserAdvert : EntityBase<Guid>
{
    public Guid CorporateUserId { get; set; }
    public Guid AdvertId { get; set; }

    public virtual CorporateUser? CorporateUser { get; set; }
    public virtual Advert? Advert { get; set; }
}

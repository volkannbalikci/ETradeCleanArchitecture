using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdvertPhotoPaths.Commands.Update
{
    public class UpdatedAdvertPhotoPathResponse
    {
        public Guid Id { get; set; }
        public Guid AdvertId { get; set; }
        public string PhotoPath { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
    }
}

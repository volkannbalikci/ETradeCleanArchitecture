﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }

    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public string BrandWebsiteUrl { get; set; }

    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}

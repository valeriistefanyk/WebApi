﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Domain.Models
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}

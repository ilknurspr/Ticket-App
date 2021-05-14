﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance
{
    public interface IOrderRepository:IAsyncRepository<Order>
    {
    }
}

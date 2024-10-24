﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ISubscriberService:IGenericService<Subscriber>
    {
        Task<Subscriber> GetByEmail(string email);

        Task<int> DailySubscriberCount();

        Task<int> TotalSubscriberCount();
    }
}

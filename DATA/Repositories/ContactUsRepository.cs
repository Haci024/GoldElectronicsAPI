﻿using Data.Connection;
using Data.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactUsRepository:GenericRepository<ContactUs>,IContactUsDAL
    {
        private readonly GoldElectronicsDb _db;
        public ContactUsRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }
    }
}
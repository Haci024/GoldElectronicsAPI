﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.NotficationsDTO
{
    public class NotficationListDTO
    {
        public Guid Id { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public DateTime SendingDate { get; set; }

        public string Description { get; set; }

        public bool IsView { get; set; }

        public string Url { get; set; }

        public string Color { get; set; }
    }
}
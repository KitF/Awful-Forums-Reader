﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulForumsReader.Core.Entity
{
    public class PrivateMessageEntity
    {
        public string Status { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string Sender { get; set; }

        public string Date { get; set; }

        public string MessageUrl { get; set; }
    }
}

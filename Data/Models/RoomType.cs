﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return Type;
        }
    }
}

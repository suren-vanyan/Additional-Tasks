﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace JSONSerialization
{
    [DataContract]
    class Apple:Company
    {
        public Product[] Products { get; set; }
    }
}

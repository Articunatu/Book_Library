﻿using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.ViewModels
{
    public class BurrowerViewModel
    {
        public IEnumerable<Burrower> Burrowers { get; set; }
    }
}
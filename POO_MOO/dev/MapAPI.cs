﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public interface MapAPI
    {
        TileAPI[][] Tiles { get; set; }
    }
}
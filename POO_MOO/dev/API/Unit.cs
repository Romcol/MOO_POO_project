﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public interface UnitAPI
    {
        TileAPI Tile { get; set; }

        void attack();

        void move();
    }
}

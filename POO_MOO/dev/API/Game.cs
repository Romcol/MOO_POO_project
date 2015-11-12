using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public interface GameAPI
    {
        PlayerAPI Player1 { get; set; }
        PlayerAPI Player2 { get; set; }
        MapAPI Map { get; set; }
        TurnAPI TurnAPI { get; set; }

        void load();
        void next();
        void save();
    }
}

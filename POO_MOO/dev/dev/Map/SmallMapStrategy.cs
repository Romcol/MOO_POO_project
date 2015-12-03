using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class SmallMapStrategy: MapStrategy
    {

		private const int SIZE = 10;
		private const int NB_TURNS = 20;
		private const int NB_UNITS = 6;

		public override int size
		{
			get { return SIZE; }
		}
		public override int nb_turns
		{
			get { return NB_TURNS; }
		}
		public override int nb_units
		{
			get { return NB_UNITS; }
		}
	}
}
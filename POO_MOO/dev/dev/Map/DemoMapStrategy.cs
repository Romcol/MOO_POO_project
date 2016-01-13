using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class DemoMapStrategy : MapStrategy
    {
		private const int SIZE = 4;
		private const int NB_TURNS = 5;
		private const int NB_UNITS = 4;

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
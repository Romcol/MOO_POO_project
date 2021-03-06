﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class StandardMapStrategy : MapStrategy
    {
		private const int SIZE = 14;
		private const int NB_TURNS = 30;
		private const int NB_UNITS = 8;

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
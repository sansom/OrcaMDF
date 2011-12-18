﻿using System;

namespace OrcaMDF.Core.Engine.SqlTypes
{
	public class SqlDateTime : ISqlType
	{
		private const double CLOCK_TICK_MS = 10d/3d;

		public bool IsVariableLength
		{
			get { return false; }
		}

		public short? FixedLength
		{
			get { return 8; }
		}

		public byte[] NormalizeCompressedValue(byte[] value)
		{
			throw new NotImplementedException();
		}

		public object GetValue(byte[] value)
		{
			if (value.Length != 8)
				throw new ArgumentException("Invalid value length: " + value.Length);

			int time = BitConverter.ToInt32(value, 0);
			int date = BitConverter.ToInt32(value, 4);

			return new DateTime(1900, 1, 1, time/300/60/60, time/300/60%60, time/300%60, (int)Math.Round(time%300*CLOCK_TICK_MS)).AddDays(date);
		}
	}
}
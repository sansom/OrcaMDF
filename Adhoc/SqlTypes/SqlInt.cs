using System;

namespace Orca.MdfReader.Adhoc.SqlTypes
{
	public class SqlInt : ISqlType
	{
		public bool IsVariableLength
		{
			get { return false; }
		}

		public short? FixedLength
		{
			get { return 4; }
		}

		public object GetValue(byte[] value)
		{
			return BitConverter.ToInt32(value, 0);
		}
	}
}
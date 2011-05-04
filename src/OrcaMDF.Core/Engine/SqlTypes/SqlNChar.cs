using System;
using System.Text;

namespace OrcaMDF.Core.Engine.SqlTypes
{
	public class SqlNChar : ISqlType
	{
		private short length;

		public SqlNChar(short length)
		{
			this.length = length;
		}

		public bool IsVariableLength
		{
			get { return false; }
		}

		public short? FixedLength
		{
			get { return length; }
		}

		public object GetValue(byte[] value)
		{
			if (value.Length != length)
				throw new ArgumentException("Invalid value length: " + value.Length);

			return Encoding.Unicode.GetString(value);
		}
	}
}
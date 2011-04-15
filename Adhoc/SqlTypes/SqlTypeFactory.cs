﻿using System;

namespace Orca.MdfReader.Adhoc.SqlTypes
{
	public class SqlTypeFactory
	{
		internal SqlBitReadState BitReadState;

		public ISqlType Create(string typeName)
		{
			switch(typeName.ToLower().Split('(')[0])
			{
				case "bit":
					return new SqlBit(this);

				case "char":
					return new SqlChar(Convert.ToInt16(typeName.Split('(')[1].Split(')')[0]));

				case "datetime":
					return new SqlDateTime();

				case "int":
					return new SqlInt();

				case "varchar":
					return new SqlVarchar();

				case "nvarchar":
					return new SqlNvarchar();

				default:
					throw new ArgumentException("typeName: " + typeName);
			}
		}
	}
}
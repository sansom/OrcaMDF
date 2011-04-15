namespace Orca.MdfReader.Adhoc.SqlTypes
{
	public interface ISqlType
	{
		bool IsVariableLength { get; }
		short? FixedLength { get; }
		object GetValue(byte[] value);
	}
}
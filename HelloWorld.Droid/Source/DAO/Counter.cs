using System;
using SQLite;

namespace HelloWorld.DAO
{
	[Table("Counter")]
	public class Counter
	{
		public int CounterID
		{
			get
			{
				return _counterID;
			}
			set { _counterID = value; }
		}
		
		int _counterID;
	}
}

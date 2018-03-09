using System;
using System.Collections.Generic;

namespace Iterator
{

	public interface IStringEnumerator
	{
		bool MoveNext();
		string Current { get; }
	}

	public class StringEnumerator: IStringEnumerator
	{
		// Ignore this.  It's just how we store the data internally.
		private List<string> _innerData;
		

		private int _index;
		public StringEnumerator(List<string> data)
		{
			_innerData = new List<string>(data);
			_index = -1;
		}

		// IStringEnumerator members		
		public bool MoveNext()
		{
			if (_index < _innerData.Count - 1)
			{
				_index++;
				return true;
			}
			else
				return false;
		}
		public string Current => _innerData[_index];
	}


	public interface IStringEnumerable
	{
		IStringEnumerator GetEnumerator();
	}

	public class SomeCollectionObject: IStringEnumerable
	{
		private List<string> _innerData;
		public SomeCollectionObject()
		{
			this._innerData = new List<string>();
		}
		public void Add(string value)
		{
			_innerData.Add(value);
		}

		public IStringEnumerator GetEnumerator()
		{
			return new StringEnumerator(_innerData);
		}
	}
}
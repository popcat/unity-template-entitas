namespace BartekNizio.Unity.Template.Entitas
{
	public class BasicIndexer
	{
		protected uint _index;

		public uint GetIndex()
		{
			return _index;
		}
		
		public uint Increment()
		{
			_index++;
			return _index;
		}

		public void Reset()
		{
			_index = 0;
		}
	}
}
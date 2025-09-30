namespace BartekNizio.Unity.Template.Entitas
{
	public class SystemSequenceFeature : InjectableFeature
	{
		public SystemSequenceFeature(Contexts contexts)
		{
			Add(new UpdateSequenceSystem(contexts));
		}
	}
}
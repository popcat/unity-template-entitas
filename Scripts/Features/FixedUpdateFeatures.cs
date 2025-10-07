using BartekNizio.Unity.Template.Entitas.Platformer2D;

namespace BartekNizio.Unity.Template.Entitas
{
	public class FixedUpdateFeatures : InjectableFeature
	{
		public FixedUpdateFeatures(Contexts contexts) {
			Add(new CharacterControllerFeature(contexts));
			Add(new PhysicsFeature(contexts));
		}
	}
}
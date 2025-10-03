using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectEntity : ObjectEntity
	{
		public new GameEntity Entity => (GameEntity) base.Entity;

		public GameEntity Initialize()
		{
			InitializeEntity();
			return Entity;
		}
		
		protected override Entity CreatEntity()
		{
			return Contexts.game.CreateEntity();
		}

		protected override void AddComponent(IObjectEntityComponent component)
		{
			component.AddComponent(this);
		}
	}
}
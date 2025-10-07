using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
	public struct EntityWrapper
	{
		public GameEntity GameEntity { get; }
		public MetaEntity MetaEntity { get; }
		public InputEntity InputEntity { get; }
		public UiEntity UiEntity { get; }

		public Entity Entity {
			get {
				if (GameEntity != null) {
					return GameEntity;
				}

				if (MetaEntity != null) {
					return MetaEntity;
				}

				if (InputEntity != null) {
					return InputEntity;
				}

				if (UiEntity != null) {
					return UiEntity;
				}

				return null;
			}
		}

		public EntityWrapper(Entity entity) {
			GameEntity = null;
			MetaEntity = null;
			InputEntity = null;
			UiEntity = null;

			switch (entity) {
				case GameEntity gameEntity:
					GameEntity = gameEntity;
					break;
				case MetaEntity metaEntity:
					MetaEntity = metaEntity;
					break;
				case InputEntity inputEntity:
					InputEntity = inputEntity;
					break;
				case UiEntity uiEntity:
					UiEntity = uiEntity;
					break;
			}
		}
	}
}
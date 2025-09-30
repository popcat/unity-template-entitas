using System.Collections.Generic;
using Entitas;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class CameraSpawnSystem : ReactiveSystem<GameEntity>
	{
		[Inject] private readonly CameraConfig _cameraConfig;
		private readonly Contexts _contexts;

		public CameraSpawnSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.CameraSpawnRequest);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isCameraSpawnRequest;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var position = Vector2.zero;
			var camera = GameObject.Instantiate(_cameraConfig.gameCameraPrefab, position, Quaternion.Euler(0, 45f, 0));
			_contexts.game.isCameraSpawnRequest = false;
		}
	}
}
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class InitializeMainCameraSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly List<GameEntity> _gameCamerasCache = new();
		private readonly IGroup<GameEntity> _gameCamerasGroup;
		private readonly List<MetaEntity> _metaCamerasCache = new();
		private readonly IGroup<MetaEntity> _metaCamerasGroup;

		public InitializeMainCameraSystem(Contexts contexts) {
			_contexts = contexts;
			_gameCamerasGroup = _contexts.game.GetGroup(GameMatcher.Camera);
			_metaCamerasGroup = _contexts.meta.GetGroup(MetaMatcher.Camera);
		}


		public void Execute() {
			if (_contexts.game.isMainCamera) {
				return;
			}

			if (_contexts.meta.isMainCamera) {
				return;
			}

			var mainCamera = Camera.main;
			if (mainCamera == null) {
				return;
			}

			foreach (var entity in _gameCamerasGroup.GetEntities(_gameCamerasCache)) {
				if (entity.camera.Instance != mainCamera) {
					continue;
				}

				entity.isMainCamera = true;
				return;
			}

			foreach (var entity in _metaCamerasGroup.GetEntities(_metaCamerasCache)) {
				if (entity.camera.Instance != mainCamera) {
					continue;
				}

				entity.isMainCamera = true;
				return;
			}
		}
	}
}
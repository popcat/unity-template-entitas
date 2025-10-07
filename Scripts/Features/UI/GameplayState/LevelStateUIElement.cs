using System.Linq;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelStateUIElement : MonoBehaviour, IAnyLevelStateListener
	{
		public LevelState[] State;

		[Inject]
		private readonly Contexts _contexts;

		private MetaEntity _metaListener;

		private void Awake() {
			gameObject.SetActive(_contexts.meta.hasLevelState && State.Contains(_contexts.meta.levelState.value));
			_metaListener = _contexts.meta.CreateEntity();
			_metaListener.AddAnyLevelStateListener(this);
		}

		private void OnDestroy() {
			_metaListener.Destroy();
		}

		public void OnAnyLevelState(MetaEntity entity, LevelState value) {
			if (State.Contains(_contexts.meta.levelState.value)) {
				gameObject.SetActive(true);
				return;
			}

			gameObject.SetActive(false);
		}
	}
}
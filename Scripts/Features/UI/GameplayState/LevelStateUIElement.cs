using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelStateUIElement : MonoBehaviour, IAnyLevelStateListener
	{
		[Inject] private readonly Contexts _contexts;
		public LevelState[] State;
		private MetaEntity _metaListener;

		private void Awake()
		{
			gameObject.SetActive(_contexts.meta.hasLevelState && State.Contains(_contexts.meta.levelState.value));
			_metaListener = _contexts.meta.CreateEntity();
			_metaListener.AddAnyLevelStateListener(this);
		}

		public void OnAnyLevelState(MetaEntity entity, LevelState value)
		{
			if (State.Contains(_contexts.meta.levelState.value)) {
				gameObject.SetActive(true);
				return;
			}

			gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			_metaListener.Destroy();
		}
	}
}

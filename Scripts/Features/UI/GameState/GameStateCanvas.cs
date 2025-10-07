using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateCanvas : MonoBehaviour, IAnyGameStateListener
	{
		public GameState GameState;

		[Inject]
		private readonly Contexts _contexts;

		private void Awake() {
			gameObject.SetActive(false);
			var metaListener = _contexts.meta.CreateEntity();
			metaListener.AddAnyGameStateListener(this);
		}

		public void OnAnyGameState(MetaEntity entity, GameState value, GameState previous) {
			if (value != GameState) {
				gameObject.SetActive(false);
				return;
			}

			gameObject.SetActive(true);
		}
	}
}
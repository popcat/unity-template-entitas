using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateButton : MonoBehaviour
	{
		public GameState GameState;

		[Inject]
		private readonly Contexts _contexts;

		private Button _button;

		private void Awake() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(RequestNewGameState);
		}

		private void RequestNewGameState() {
			_contexts.meta.gameStateEntity.stateManager.instance.RequestState(GameState);
		}
	}
}
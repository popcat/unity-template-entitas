using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateButton : MonoBehaviour
	{
		[Inject] private readonly Contexts _contexts;
		private Button _button;

		public GameState GameState;

		private void Awake()
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener(RequestNewGameState);
		}

		private void RequestNewGameState()
		{
			_contexts.meta.gameStateEntity.stateManager.instance.RequestState(GameState);
		}
	}
}
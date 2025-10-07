using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelStateButton : MonoBehaviour
	{
		public LevelState State;

		[Inject]
		private readonly Contexts _contexts;

		private Button _button;

		private void Awake() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(RequestNewGameplayState);
		}

		private void RequestNewGameplayState() {
			_contexts.meta.levelStateEntity.stateManager.instance.RequestState(State);
		}
	}
}
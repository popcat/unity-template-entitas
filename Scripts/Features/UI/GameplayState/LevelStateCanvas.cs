using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class LevelStateCanvas : MonoBehaviour, IAnyLevelStateListener
	{
		public LevelState State;

		[Inject]
		private readonly Contexts _contexts;

		private CanvasGroup _canvasGroup;

		private void Awake() {
			_canvasGroup = GetComponent<CanvasGroup>();
			gameObject.SetActive(false);
			var metaListener = _contexts.meta.CreateEntity();
			metaListener.AddAnyLevelStateListener(this);
		}

		public void OnAnyLevelState(MetaEntity entity, LevelState value) {
			if (value != State) {
				HideCanvas();
				return;
			}

			ShowCanvas();
		}

		private void ShowCanvas() {
			//gameObject.SetActive(true);
			_canvasGroup.alpha = 1;
			_canvasGroup.interactable = true;
			_canvasGroup.blocksRaycasts = true;
		}

		private void HideCanvas() {
			//gameObject.SetActive(false);
			_canvasGroup.alpha = 0;
			_canvasGroup.interactable = false;
			_canvasGroup.blocksRaycasts = false;
		}
	}
}
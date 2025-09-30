using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameStateCanvas : MonoBehaviour, IAnyGameStateListener
	{
		[Inject] private readonly Contexts _contexts;
		public GameState GameState;
		
		private void Awake()
		{
			gameObject.SetActive(false);
			var metaListener = _contexts.meta.CreateEntity();
			metaListener.AddAnyGameStateListener(this);
		}

		public void OnAnyGameState(MetaEntity entity, GameState value, GameState previous)
		{
			if (value != GameState) {
				gameObject.SetActive(false);
				return;
			}
			
			gameObject.SetActive(true);
		}
	}
}
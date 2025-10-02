using UnityEngine;
using UnityEngine.SceneManagement;

namespace BartekNizio.Unity.Template.Entitas
{
	public class BootManager : MonoBehaviour
	{
		private void Start()
		{
			var coreSceneOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
			coreSceneOperation.completed += _ => {
				SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
			};
			var uiSceneOperation = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
			uiSceneOperation.completed += _ => {
				SceneManager.UnloadSceneAsync(0);
				Contexts.sharedInstance.meta.isBootFinished = true;
			};
		}
	}
}
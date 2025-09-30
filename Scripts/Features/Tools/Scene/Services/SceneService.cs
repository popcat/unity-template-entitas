using UnityEngine.SceneManagement;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class SceneService
	{
		[Inject] private readonly ContextService _contextService;
		[Inject] private readonly Contexts _contexts;

		public SystemSequence LoadSceneSequence(int sceneIndex)
		{
			var ss = new SystemSequence(_contexts);
			ss.Add((c)=> c.meta.CreateEntity().AddLoadSceneRequest(sceneIndex), 
				(c,e) => !c.meta.hasSceneLoading && !c.meta.hasLoadSceneRequest, $"Load Scene {sceneIndex}");
			return ss;
		}
		
		public SystemSequence UnloadSceneSequence(int sceneIndex)
		{
			var ss = new SystemSequence(_contexts);
			var scene = SceneManager.GetSceneByBuildIndex(sceneIndex);
			if (scene.isLoaded == false) return ss;
			
			ss.Add((c)=> c.meta.CreateEntity().AddUnloadSceneRequest(sceneIndex), 
				(c,e) => !c.meta.hasSceneUnloading && !c.meta.hasUnloadSceneRequest, $"UnLoad Scene {sceneIndex}");
			return ss;
		}

		public SystemSequence ReloadGameplaySceneSequence()
		{
			var ss = new SystemSequence(_contexts);
			ss.Add(UnloadSceneSequence(GetGameplaySceneIndex()));
			ss.Add(LoadSceneSequence(GetGameplaySceneIndex()));
			return ss;
		}
		

		public int GetBootSceneIndex()
		{
			return 0;
		}
		
		public int GetCoreSceneIndex()
		{
			return 1;
		}
		
		public int GetUISceneIndex()
		{
			return 2;
		}
		
		public int GetGameplaySceneIndex()
		{
			return 3;
		}
	}
}
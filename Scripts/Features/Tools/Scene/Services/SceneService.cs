using UnityEngine.SceneManagement;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class SceneService
	{
		[Inject] private readonly ContextService _contextService;
		[Inject] private readonly Contexts _contexts;
		
		public SystemSequence LoadSceneSequence(string sceneName)
		{
			return LoadSceneSequence(-1, sceneName);
		}
		
		public SystemSequence LoadSceneSequence(int sceneIndex)
		{
			return LoadSceneSequence(sceneIndex, null);
		}
		
		private SystemSequence LoadSceneSequence(int sceneIndex = -1, string sceneName = null)
		{
			var ss = new SystemSequence(_contexts);
			ss.Add((c)=>
				{
					var loadSceneEntity = c.meta.CreateEntity();
					loadSceneEntity.isSceneLoadRequest = true;
					if(sceneIndex > 0)
						loadSceneEntity.AddIndex(sceneIndex);
					if (sceneName != null)
						loadSceneEntity.AddSceneName(sceneName);
				}, 
				(c,e) => c.meta.isSceneLoadCompleted, $"Load Scene {sceneName} {sceneIndex}");
			return ss;
		}
		
		public SystemSequence UnloadSceneSequence(string sceneName)
		{
			var scene = SceneManager.GetSceneByName(sceneName);
			return UnloadSceneSequence(scene);
		}
		
		public SystemSequence UnloadSceneSequence(int buildIndex)
		{
			var scene = SceneManager.GetSceneByBuildIndex(buildIndex);
			return UnloadSceneSequence(scene);
		}
		
		private SystemSequence UnloadSceneSequence(Scene scene)
		{
			var ss = new SystemSequence(_contexts);
			if (scene.isLoaded == false) return ss;
			
			ss.Add((c)=> {
					var loadSceneEntity = c.meta.CreateEntity();
					loadSceneEntity.isSceneUnloadRequest = true;
					loadSceneEntity.AddIndex(scene.buildIndex);
				}, 
				(c,e) => c.meta.isSceneUnloadCompleted, $"UnLoad Scene {scene.name}");
			return ss;
		}

		public SystemSequence ReloadSceneSequence(string sceneName)
		{
			var ss = new SystemSequence(_contexts);
			ss.Add(UnloadSceneSequence(sceneName));
			ss.Add(LoadSceneSequence(sceneName));
			return ss;
		}

		public SystemSequence ReloadSceneSequence(int sceneIndex)
		{
			var ss = new SystemSequence(_contexts);
			ss.Add(UnloadSceneSequence(sceneIndex));
			ss.Add(LoadSceneSequence(sceneIndex));
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
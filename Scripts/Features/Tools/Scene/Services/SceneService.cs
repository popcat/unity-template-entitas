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
			ss.Add((c)=>
				{
					var loadSceneEntity = c.meta.CreateEntity();
					loadSceneEntity.isSceneLoadRequest = true;
					loadSceneEntity.AddIndex(sceneIndex);
				}, 
				(c,e) => c.meta.isSceneLoadCompleted, $"Load Scene {sceneIndex}");
			return ss;
		}
		
		public SystemSequence UnloadSceneSequence(int sceneIndex)
		{
			var ss = new SystemSequence(_contexts);
			var scene = SceneManager.GetSceneByBuildIndex(sceneIndex);
			if (scene.isLoaded == false) return ss;
			
			ss.Add((c)=> {
					var loadSceneEntity = c.meta.CreateEntity();
					loadSceneEntity.isSceneUnloadRequest = true;
					loadSceneEntity.AddIndex(sceneIndex);
				}, 
				(c,e) => c.meta.isSceneUnloadCompleted, $"UnLoad Scene {sceneIndex}");
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
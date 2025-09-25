using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class UpdateManager : MonoBehaviour
	{
		private UpdateSystem  _updateSystem;
        private FixedUpdateSystem _fixedUpdateSystem;
        private ContextService _contextService;

        [Inject]
        private void Init( UpdateSystem updateSystem, FixedUpdateSystem fixedUpdateSystem, DiContainer container, ContextService contextService)
        {
            InitCoreSystems( updateSystem, fixedUpdateSystem, container );
            contextService.onBeforeContextReset += DeactivateReactiveSystems;
            contextService.onContextResetDone += ActivateReactiveSystems;
        }

        private void InitCoreSystems( UpdateSystem updateSystem, FixedUpdateSystem fixedUpdateSystem, DiContainer container )
        {
            _updateSystem = updateSystem;
            _updateSystem.IncjectSelfAndChildren( container );
            _updateSystem.Initialize();
            _fixedUpdateSystem = fixedUpdateSystem;
            _fixedUpdateSystem.IncjectSelfAndChildren( container );
            _fixedUpdateSystem.Initialize();
        }

        private void Update()
        {
            _updateSystem.Execute();
            _updateSystem.Cleanup();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystem.Execute();
            _fixedUpdateSystem.Cleanup();
        }

        private void OnDestroy()
        {
            _updateSystem.TearDown();
            _fixedUpdateSystem.TearDown();
        }

        private void DeactivateReactiveSystems( IContext context )
        {
            _updateSystem.DeactivateReactiveSystems();
            _fixedUpdateSystem.DeactivateReactiveSystems();
        }

        private void ActivateReactiveSystems( IContext context )
        {
            _updateSystem.ActivateReactiveSystems();
            _fixedUpdateSystem.ActivateReactiveSystems();
        }
    }
}
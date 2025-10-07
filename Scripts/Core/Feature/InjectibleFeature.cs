using System.Collections;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
	public class InjectableFeature : Feature
	{
		public InjectableFeature() { }

		public InjectableFeature(string name) : base(name) { }

		public void IncjectSelfAndChildren(DiContainer container) {
			InjectOrQueue(container, this);
			InjectInChilndren(_cleanupSystems, container);
			InjectInChilndren(_executeSystems, container);
			InjectInChilndren(_initializeSystems, container);
			InjectInChilndren(_tearDownSystems, container);
		}

		private void InjectInChilndren(IEnumerable collection, DiContainer container) {
			foreach (var sys in collection) {
				var injectableFeature = sys as InjectableFeature;
				if (injectableFeature != null) {
					injectableFeature.IncjectSelfAndChildren(container);
				}
				else {
					InjectOrQueue(container, sys);
				}
			}
		}

		private void InjectOrQueue(DiContainer container, object obj) {
			if (container.IsInstalling) {
				container.QueueForInject(obj);
			}
			else {
				container.Inject(obj);
			}
		}
	}
}
using Entitas;
using UnityEngine;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas
{
    public class InteractionInputSystem : IExecuteSystem
    {
        [Inject]
        private InputConfig _inputConfig;
        private readonly Contexts _contexts;

        public InteractionInputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
		
        public void Execute()
        {
            var interactionInput = _inputConfig.interactInputAction;
            if (interactionInput.WasCompletedThisFrame() && !_contexts.input.hasDragInput) {
                var screenPosition = _inputConfig.cursorPositionInputAction.ReadValue<Vector2>();
                _contexts.input.CreateEntity().AddInteractionInput(screenPosition);
                DebugLogger.Log($"Interaction detected");
            }
        }
    }
}
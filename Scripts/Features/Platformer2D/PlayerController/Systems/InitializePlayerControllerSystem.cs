using Entitas;
using Zenject;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    public class InitializePlayerControllerSystem : IInitializeSystem
    {
        [Inject] private Platformer2DPlayerControllerConfig _platformer2DPlayerControllerConfig;
        private readonly Contexts _contexts;

        public InitializePlayerControllerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            var map = _platformer2DPlayerControllerConfig.Input;
            var inputEntity = _contexts.input.CreateEntity();
            inputEntity.isPlatformer2DPlayerControllerU = true;

            var move = map.FindAction("Move").Clone();
            move.Enable();
            inputEntity.AddMoveInputAction(move);
            
            var jump = map.FindAction("Jump").Clone();
            jump.Enable();
            inputEntity.AddJumpInputAction(jump);

            var run = map.FindAction("Run").Clone();
            run.Enable();
            inputEntity.AddRunInputAction(run);
        }
    }
}
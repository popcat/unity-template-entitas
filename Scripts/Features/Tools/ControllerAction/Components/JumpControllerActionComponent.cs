using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game, Meta]
    public class JumpControllerActionComponent : IComponent
    {
        public ControllerActionInputStatus Status;
    }
}
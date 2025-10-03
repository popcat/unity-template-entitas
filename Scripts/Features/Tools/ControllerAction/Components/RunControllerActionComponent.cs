using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game, Meta]
    public class RunControllerActionComponent : IComponent
    {
        public ControllerActionInputStatus Status;
    }
}
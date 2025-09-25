using Entitas;
using Entitas.CodeGeneration.Attributes;
using Unity.Mathematics;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
    public class PreviousVelocity2DComponent : IComponent
    {
        public float2 Value;
    }
}
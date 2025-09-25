using Entitas;
using Entitas.CodeGeneration.Attributes;
using Unity.Mathematics;

namespace BartekNizio.EntitasSystem
{
    [Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
    public class Number4Component : IComponent
    {
        public int4 Value;
    }
}
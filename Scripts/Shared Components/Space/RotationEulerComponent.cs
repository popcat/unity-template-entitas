using Entitas;
using Entitas.CodeGeneration.Attributes;
using Unity.Mathematics;
using UnityEngine;

namespace BartekNizio.EntitasSystem
{
    [Game, Meta, Input, Ui, Event(EventTarget.Self), Event(EventTarget.Any)]
    public class RotationEulerComponent : IComponent
    {
        public float3 Value;
    }
}
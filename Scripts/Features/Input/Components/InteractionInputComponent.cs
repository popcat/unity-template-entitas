using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Input, Unique, Cleanup(CleanupMode.DestroyEntity)]
    public class InteractionInputComponent : IComponent
    {
        public Vector2 screenPosition;
    }
}
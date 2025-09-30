using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game, Unique, Cleanup(CleanupMode.DestroyEntity)]
    public class MoveCameraRequestComponent : IComponent
    {
        public Vector3 targetPosition;
    }
}
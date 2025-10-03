using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game, Meta]
    public class MoveControllerActionComponent : IComponent
    {
        public Vector2 Value;
        public ControllerActionInputStatus Status;
    }
}
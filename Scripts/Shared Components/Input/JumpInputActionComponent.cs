using Entitas;
using UnityEngine.InputSystem;

namespace BartekNizio.Unity.Template.Entitas
{
    [Input]
    public class JumpInputActionComponent : IComponent
    {
        public InputAction Value;
    }
}
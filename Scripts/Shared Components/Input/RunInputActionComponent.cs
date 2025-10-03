using Entitas;
using UnityEngine.InputSystem;

namespace BartekNizio.Unity.Template.Entitas
{
    [Input]
    public class RunInputActionComponent : IComponent
    {
        public InputAction Value;
    }
}
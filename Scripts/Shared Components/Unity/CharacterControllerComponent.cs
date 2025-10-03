using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game, Meta]
    public class CharacterControllerComponent : IComponent
    {
        public CharacterController Instance;
    }
}
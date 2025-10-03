using UnityEngine;
using UnityEngine.InputSystem;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    [CreateAssetMenu(fileName = "PlayerController_Platformer2D_Config", menuName = "Config/Platformer2D/Player Controller")]
    public class Platformer2DPlayerControllerConfig : ScriptableObject
    {
        public InputActionMap Input;
    }
}
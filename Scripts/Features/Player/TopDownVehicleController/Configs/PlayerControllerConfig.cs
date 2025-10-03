using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [CreateAssetMenu(fileName = "PlayerControllerConfig", menuName = "Config/PlayerController")]
    public class PlayerControllerConfig : ScriptableObject
    {
        public PlayerMovementStyle movementStyle;
        public PlayerAttackStyle attackStyle;
    }
}
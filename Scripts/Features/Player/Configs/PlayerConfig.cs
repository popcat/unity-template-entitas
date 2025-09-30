using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Player")]
    public class PlayerConfig : ScriptableObject
    {
        public VehicleConfig vehicleConfig;
        public Vector3 spawnPosition;
    }
}
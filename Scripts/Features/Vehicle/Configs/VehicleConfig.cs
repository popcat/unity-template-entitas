using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [CreateAssetMenu(fileName = "Vehicle Config",menuName = "Config/Vehicle")]
    public class VehicleConfig : ScriptableObject
    {
        public GameObject vehiclePrefab;
        
        [Header("General")]
        public float acceleration;
        public float maxSpeed;
        public float drag;
        public float rotationSpeed;

        [Header("Wobble")]
        public bool isWobble;
        public float wobbleRotationSpeed;
        public float wobbleRotationAngle;
    }
}
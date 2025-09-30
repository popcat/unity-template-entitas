using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [Game]
    public class VehicleComponent : IComponent
    {
        public VehicleConfig config;
        public Transform dirPivot;
        public Transform accPivot;
    }
}
using Entitas;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	[Game]
	public class VehicleComponent : IComponent
	{
		public Transform accPivot;
		public VehicleConfig config;
		public Transform dirPivot;
	}
}
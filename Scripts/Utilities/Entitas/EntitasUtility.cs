using System.Collections.Generic;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public static class EntitasUtility
	{
		public static GameEntity FindClosestEntity(GameEntity sourceEntity, IEnumerable<GameEntity> targetEntities) {
			GameEntity closestEntity = null;
			var closestDistance = float.MaxValue;
			foreach (var targetEntity in targetEntities) {
				var distance = Vector3.SqrMagnitude(sourceEntity.transform.Instance.position -
				                                    targetEntity.transform.Instance.position);
				if (distance < closestDistance) {
					closestEntity = targetEntity;
					closestDistance = distance;
				}
			}

			return closestEntity;
		}
	}
}
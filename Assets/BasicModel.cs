using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Model", menuName = "Physics Test/Basic Model")]
public class BasicModel : PhysicsModel
{
	[SerializeField, SquaredValue]
	float distanceToCheckSquared;

	[SerializeField]
	AnimationCurve strengthBasedOnNearDistance;

	[SerializeField, SquaredValue]
	float arrivedDistanceSquared;

	[SerializeField]
	float strength;

	public override void PhysicsUpdate(Vector3 toTarget, PhysicsTest physicsObject)
	{
		float sqrDistance = toTarget.sqrMagnitude;

		//if(sqrDistance < distanceToCheckSquared)
		//{
		//	float ratio = Mathf.Sqrt(sqrDistance / distanceToCheckSquared);

		//	usedStrength = strength * strengthBasedOnNearDistance.Evaluate(ratio);
		//}

		if (sqrDistance > arrivedDistanceSquared)
		{
			float usedStrength = strength;

			if (Mathf.Sign(Vector3.Dot(toTarget, physicsObject.Rigid.velocity)) > 0)
			{
				float stopDistance = physicsObject.Rigid.velocity.sqrMagnitude / (2*strength);

				if (sqrDistance < stopDistance * stopDistance)
				{
					usedStrength = -strength;
				}
			}

			toTarget /= Mathf.Sqrt(sqrDistance);
			
			physicsObject.ApplyForce(toTarget * usedStrength);
		}
	}
}

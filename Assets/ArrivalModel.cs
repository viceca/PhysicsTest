using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arrival Model", menuName = "Physics Test/Arrival Model")]
public class ArrivalModel : PhysicsModel
{
	[SerializeField]
	float maxSpeed;

	[SerializeField]
	float maxAccel;

	public override void PhysicsUpdate(Vector3 toTarget, PhysicsTest physicsObject)
	{
		float distance = toTarget.magnitude;

		float rampedSpeed = maxSpeed * (distance / (physicsObject.Rigid.velocity.sqrMagnitude) / (2 * maxAccel));

		float clippedSpeed = Mathf.Min(rampedSpeed, maxSpeed);

		Vector3 desiredVelocity = (clippedSpeed / distance) * toTarget;

		Vector3 steering = desiredVelocity - physicsObject.Rigid.velocity;

		physicsObject.Rigid.AddForce(steering, ForceMode.VelocityChange);
	}
}

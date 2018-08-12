using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Control Model", menuName = "Physics Test/Control Model")]
public class ControlModel : PhysicsModel
{
	[SerializeField]
	float toVel = 2.5f;

	[SerializeField,SquaredValue]
	float maxVelSquared = 225;

	[SerializeField]
	float maxForce = 40.0f;

	[SerializeField]
	float gain = 5f;
	
	public override void PhysicsUpdate(Vector3 toTarget, PhysicsTest physicsObject)
	{
		Vector3 tgtVel = toTarget * toVel;

		if (toTarget.sqrMagnitude * toVel * toVel > maxVelSquared)
		{
			Debug.Log("Clamping");
			tgtVel = toTarget.normalized * Mathf.Sqrt(maxVelSquared);
		}

		Vector3 error = tgtVel - physicsObject.Rigid.velocity;

		Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);

		physicsObject.ApplyForce(force);
	}
}

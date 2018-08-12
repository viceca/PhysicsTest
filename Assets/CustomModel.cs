using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Custom Model", menuName = "Physics Test/Custom Model")]
public class CustomModel : PhysicsModel
{
	[SerializeField]
	AnimationCurve strengthBasedOnVelocity;

	[SerializeField]
	AnimationCurve massToLerp;

	[SerializeField]
	AnimationCurve distanceToStrength;

	[SerializeField]
	float toVel = 2.5f;

	[SerializeField, SquaredValue]
	float maxVelSquared = 225;

	[SerializeField]
	float maxForce = 40.0f;

	[SerializeField]
	float gain = 5f;

	[SerializeField, Range(0,10)]
	float dampeningFactor = 0; 

	public override void PhysicsUpdate(Vector3 toTarget, PhysicsTest physicsObject)
	{
		Vector3 tgtVel = toTarget * toVel;

		if (toTarget.sqrMagnitude * toVel * toVel > maxVelSquared)
		{
			tgtVel = toTarget.normalized * Mathf.Sqrt(maxVelSquared);
		}

		Vector3 error = tgtVel - physicsObject.Rigid.velocity;

		float maxForce = this.maxForce * strengthBasedOnVelocity.Evaluate(physicsObject.Rigid.velocity.magnitude) * distanceToStrength.Evaluate(toTarget.magnitude);

		maxForce = Mathf.Lerp(this.maxForce, maxForce, massToLerp.Evaluate(physicsObject.Rigid.mass));

		Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);

		force -= physicsObject.Rigid.velocity * physicsObject.Rigid.mass * dampeningFactor;

		physicsObject.ApplyForce(force);
	}
}

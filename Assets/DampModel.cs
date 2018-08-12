using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damp Model", menuName = "Physics Test/Damp Model")]
public class DampModel : PhysicsModel
{
	[SerializeField]
	float dampCoeficient = 1;

	[SerializeField]
	float springCoeficient = 1;

	public override void PhysicsUpdate(Vector3 toTarget, PhysicsTest physicsObject)
	{
	}
}

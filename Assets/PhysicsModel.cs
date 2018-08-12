using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicsModel : ScriptableObject
{
	public abstract void PhysicsUpdate(Vector3 toTarget, PhysicsTest physicsObject);
}

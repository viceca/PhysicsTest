using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsTest : TestBasic
{
	public PhysicsModel UsedModel => usedModel;

	[SerializeField]
	bool isUnidimentional = true;

	[SerializeField]
	PhysicsModel usedModel;

	Vector3 lastForce;

	void FixedUpdate()
	{
		Vector3 direction = target.position - transform.position;

		if (isUnidimentional)
		{
			direction.y = direction.z = 0;
		}

		if(usedModel != null)
		{
			usedModel.PhysicsUpdate(direction, this);
		}
	}

	public void ApplyForce(Vector3 force)
	{
		lastForce = force;
		Rigid.AddForce(force);
	}

	protected override void OnDrawGizmos()
	{
		Vector3 position = transform.position;

		Gizmos.color = Color.blue;

		Gizmos.DrawLine(position, position + lastForce);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointTest : TestBasic
{
	[SerializeField]
	float driveSpring;

	[SerializeField]
	float driveDamper;

	[SerializeField]
	float driveMaximumForce;

	ConfigurableJoint joint;

	protected override void Awake()
	{
		base.Awake();

		joint = GetComponent<ConfigurableJoint>();
		ApplyParameters();
	}

	void ApplyParameters()
	{
		JointDrive drive = joint.xDrive;

		drive.positionSpring = driveSpring;
		drive.positionDamper = driveDamper;
		drive.maximumForce = driveMaximumForce;

		joint.xDrive = joint.yDrive = joint.zDrive = drive;
	}

	void OnValidate()
	{
		if(joint != null)
		{
			ApplyParameters();
		}
	}
}

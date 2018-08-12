using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBasic : MonoBehaviour
{
	public Rigidbody Rigid { get; private set; }

	[SerializeField]
	protected Transform target;

	Camera mainCamera;

	protected virtual void Awake()
	{
		Rigid = GetComponent<Rigidbody>();

		mainCamera = FindObjectOfType<Camera>();

		if (target == null)
		{
			target = new GameObject("Target").transform;
			target.transform.position = transform.position;
		}
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

			targetPosition.z = 0;

			target.position = targetPosition;
		}
	}

	protected virtual void OnDrawGizmos()
	{
		if (Rigid != null)
		{
			Vector3 position = transform.position;

			Gizmos.color = Color.black;

			Gizmos.DrawLine(position, position + Rigid.velocity);
		}
	}
}

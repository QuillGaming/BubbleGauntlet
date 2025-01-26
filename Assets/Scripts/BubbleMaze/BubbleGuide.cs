using System.Collections;
using UnityEngine;


public class MouseMove2D : MonoBehaviour
{

	private Vector3 mousePosition;
	public float moveSpeed = 0.001f;


	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

		}

	}
}


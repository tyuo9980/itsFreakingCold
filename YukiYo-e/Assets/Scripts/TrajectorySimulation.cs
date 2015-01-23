using UnityEngine;
using System.Collections;

public class TrajectorySimulation : MonoBehaviour {
	public float f_radius = 0.6f; 
	public float f_translateSpeed = 270.0f; 
	public float f_angle = 0.0f; 
	public Quaternion q_rotation = Quaternion.identity;

	Vector3 direction = Vector3.one;
	
	void Start()
	{
		Destroy(gameObject, 1.0f);
	}
	
	void Update()
	{
		direction = new Vector3(Mathf.Sin(f_angle), Mathf.Cos(f_angle));
		Translate(0, f_translateSpeed);
		UpdatePositionRotation();
	}
	
	void Translate(float x, float y)
	{
		var perpendicular = new Vector3(-direction.y, direction.x);
		var verticalRotation = Quaternion.AngleAxis(y * Time.deltaTime, perpendicular);
		var horizontalRotation = Quaternion.AngleAxis(x * Time.deltaTime, direction);
		q_rotation *= horizontalRotation * verticalRotation;
	}
	
	void UpdatePositionRotation()
	{
		transform.localPosition = q_rotation * Vector3.forward * f_radius;
		transform.rotation = q_rotation * Quaternion.LookRotation(direction, Vector3.forward);
	}
}

using UnityEngine;
using System.Collections;

public class FirstPersonCameraRunner : MonoBehaviour {
	//public Transform player;
	
	// Update is called once per frame
	//void Update () {
	//	transform.position = new Vector3(player.position.x, 0, 0);
	//}

//	public float f_dampTime = 0f;
//	private Vector3 v3_velocity = Vector3.zero;
	public Transform t_target;
	
	// Update is called once per frame
	void Update () 
	{
		if (t_target)
		{
			//Vector3 point = camera.WorldToViewportPoint(t_target.position);
			//Vector3 delta = t_target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			//Vector3 destination = transform.position + delta;
			//transform.position = Vector3.SmoothDamp(transform.position, destination, ref v3_velocity, f_dampTime);
			transform.position = t_target.position;
		}
		
	}
}


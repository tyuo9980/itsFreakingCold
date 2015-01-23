using UnityEngine;
using System.Collections;

public class SnowballGenerator : MonoBehaviour {
	public GameObject[] items;
	public float f_frequency = 0.8f;
	public float f_height = 2f;
	// Use this for initialization
	void Start () {
		Generate();
	}
	
	void Generate(){
		Vector3 groundPos = new Vector3(transform.position.x, f_height, transform.position.z);
		Instantiate(items[Random.Range(0, items.GetLength(0))], transform.position, Quaternion.identity);
		Invoke("Generate", f_frequency);
	}
}

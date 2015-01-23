using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject go_character;
	private Vector3 v3_offset;
	[SerializeField] float f_maxSpeed = 0f;
	private bool b_left = false;
	private bool b_right = false;
	private float f_timer = 0f;
	// Use this for initialization


	private float accel = 0.01f;
	private float velo = 0f;
	private float maxvelo = 0.01f;
	private float minvelo = -0.01f;

	void Start () {
		//offset = transform.postion.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") < 0) {
			b_left = true;
			b_right = false;
			//print ("left here!");

		}
		if(Input.GetAxis("Horizontal") > 0) {
			b_right = true;
			b_left = false;
			//print ("right here!");
		}

		if((b_left == true && b_right == false)){
			//print ("left");
			Move(-1);
		}
		else if(b_left == false && b_right == true){
			//print ("right");
			Move(1);
		}
		else{
			//print ("still");
			Move (0);
			print (velo);
		}
		
		b_left = false;
		b_right = false;

		rigidbody2D.position = new Vector2(rigidbody2D.position.x + velo, rigidbody2D.position.y);
	}

	void FixedUpdate(){

		if(go_character.transform.position.x < -1.2f ){
			print (go_character.transform.position);
			//rigidbody2D.velocity = new Vector2(0,0);
			print ("bbb" + go_character.transform.position);
			go_character.transform.position = new Vector3(1.1f, go_character.transform.position.y,go_character.transform.position.z);
			b_left = true;
			b_right = false;
			//Debug.Break ();
		}
		else if (go_character.transform.position.x > 1.1f){
			go_character.transform.position = new Vector3(-1.2f, go_character.transform.position.y,go_character.transform.position.z);
			b_right = true;
			b_left = false;
		}



	}

	void Move(int move){
		/*
		if(f_timer <= 2f){
			rigidbody2D.velocity = new Vector2(move*f_maxSpeed, 0);
			f_timer = f_timer + 1;
		}
		else{
			rigidbody2D.velocity = new Vector2(0,0);
			f_timer = 0f;
		}
		print("aaaaa" + rigidbody2D.velocity );
		*/

		//move right
		if (move == 1){
			velo += accel;
			if (velo > maxvelo)
				velo = maxvelo;
		}
		//move left
		else if (move == -1){
			velo -= accel;
			if (velo < minvelo)
				velo = minvelo;
		}
		else if (move == 0){
			if (velo < 0){
				velo += accel;
				if (velo > 0)
					velo = 0;
			}
			else if (velo > 0){
				velo -= accel;
				if (velo < 0)
					velo = 0;
			}
		}

	//	if((grounded||!doubleJump) && jump) {
	//		//anim.SetBool("Ground", false);
	//		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
	//		rigidbody2D.AddForce(new Vector2(0f, jumpForce));
	//		if(!grounded) {
	//			doubleJump = true;
	//		}
	}
}


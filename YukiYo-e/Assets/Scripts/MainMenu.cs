using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {

	public GUISkin skin;
	public Vector2 btStartServerLocation;
	public Vector2 btExitGameLocation;
	public _GUIClasses.Location center = new _GUIClasses.Location();
	public bool startBtCreated = false;

	// Update is called once per frame
	void Update () {
		center.updateLocation(); //in case the player is skretching the window
	}
	void OnGUI(){
		GUI.skin = skin;
		//update start button location
		if (GUI.Button(new Rect(center.offset.x + btStartServerLocation.x, center.offset.y + btStartServerLocation.y, 140, 50), "START SERVER")){
			startBtCreated = true;
			Application.LoadLevel("MainScene");
		}
		if (GUI.Button(new Rect(center.offset.x + btExitGameLocation.x, center.offset.y + btExitGameLocation.y, 140, 50), "EXIT")){
			startBtCreated = true;
			Application.Quit();
		}
	}
}

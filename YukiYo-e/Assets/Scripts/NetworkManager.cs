using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MainMenu))]
public class NetworkManager : MonoBehaviour {
	private const string typeName = "Yokiyo-e";
	private const string gameName = "RoomName";
	private MainMenu menu;

	private void Awake(){
		menu = GetComponent<MainMenu>();
	}

	private void StartServer()
	{
		Network.InitializeServer(2, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}

	//void OnGUI()
	//{
	//	if (!Network.isClient && !Network.isServer)
	//	{
	//		if (menu.startBtCreated){
	//			StartServer();
	//		}
	//	}
	//}

}

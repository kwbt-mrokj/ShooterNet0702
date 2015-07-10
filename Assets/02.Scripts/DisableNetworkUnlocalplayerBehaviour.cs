using UnityEngine;
using UnityEngine.Networking;

public class DisableNetworkUnlocalplayerBehaviour : NetworkBehaviour {
	/*
	[SerializeField]
	Behaviour[] behaviours;
	*/

	public Behaviour cntrlScript;
	
	public Camera camera;

	void Start()
	{
		if(!isLocalPlayer)
		{
			/*
			foreach(var behaviour in behaviours)
			{
				behaviour.enabled = false;
			}*/

			cntrlScript.enabled = false;
			
			camera.enabled = false;
		}
	}
	
	void OnApplicationFocus(bool focusStatus)
	{
		if(isLocalPlayer)
		{
			/*
			foreach(var behaviour in behaviours)
			{
				behaviour.enabled = focusStatus;	
			}*/	
			cntrlScript.enabled = focusStatus;
			
			camera.enabled = true;
		}
	}
}

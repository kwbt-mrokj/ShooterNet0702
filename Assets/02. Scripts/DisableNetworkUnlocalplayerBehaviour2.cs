using UnityEngine;
using UnityEngine.Networking;

public class DisableNetworkUnlocalplayerBehaviour2 : NetworkBehaviour
{
	public Behaviour cntrlScript;
	public Camera camera;

	void Start ()
	{
		if(! isLocalPlayer ){

			cntrlScript.enabled = false;
			camera.enabled = false;
		}
	}
	void OnApplicationFocus(bool focusStatus) {
		if(isLocalPlayer)
		{
			cntrlScript.enabled = focusStatus;
			camera.enabled = true;
		}
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerID : NetworkBehaviour {

    [SyncVar]
    private string playerUniqueIdentity;

    private NetworkInstanceId playerNetID;
    private Transform myTransform;


    public override void OnStartLocalPlayer()
    {
        GetNetIdentity();
        SetIdentity();
    }

    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (myTransform.name == "" || myTransform.name == "Player(Clone)")
        {
            SetIdentity();
        }
	}


    [Client]
    void GetNetIdentity()
    {
        //NetworkIdentityのNetID取得
        playerNetID = GetComponent<NetworkIdentity>().netId;

        CmdTellServerMyIdentity(MakeUniqueIdentity());
    }

    void SetIdentity()
    {
        //自分以外のPlayerオブジェクトの場合
        if (!isLocalPlayer)
        {
            //今ついている名前のまま
            myTransform.name = playerUniqueIdentity;
        }
        else
        {
            //自分自身の場合MakeUniqueIdentityメソッドで名前を取得
            myTransform.name = MakeUniqueIdentity();
        }
    }

    string MakeUniqueIdentity()
    {
        //Player + NetIDで名前を付ける
        string uniquename = "Player" + playerNetID.ToString();
        return uniquename;
    }

    //Command: SyncVar変数を変更し、変更結果を全クライアントへ送る
    [Command]
    void CmdTellServerMyIdentity(string name)
    {
        playerUniqueIdentity = name;
    }

}

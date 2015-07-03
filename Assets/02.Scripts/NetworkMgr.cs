using UnityEngine;
using System.Collections;

public class NetworkMgr : MonoBehaviour {

    //接続IP
    private const string ip = "127.0.0.1";
    //接続ポート
    private const int port = 30000;
    //NAT機能の使用の有無
    private bool _useNat = false;

    //プレイヤーのプレハブ
    public GameObject player;

    void OnGUI()
    {
        //現在のユーザーのネットワーク接続の有無を判断
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            //ゲームサーバー生成ボタン
            if(GUI.Button(new Rect(20, 20, 200, 25), "Start Server"))
            {
                //ゲームサーバー生成 : InitializeServer (接続者数, ポート番号, NATの使用の有無)
                Network.InitializeServer(20, port, _useNat);

            }

            //ゲームへの接続ボタン
            if(GUI.Button(new Rect(20, 50, 200, 25), "Connect Server"))
            {
                //ゲームサーバーへの接続: Connect (接続者IP, 接続ポート番号)
                Network.Connect(ip, port);
            }

        }
        else
        {
            //サーバーの場合はメッセージを出力
            if(Network.peerType == NetworkPeerType.Server)
            {
                GUI.Label(new Rect(20, 20, 200, 25), "Initilisation Server...");
                GUI.Label(new Rect(20, 50, 200, 25), "Client Count = " + Network.connections.Length.ToString());
            }

            //クライアントに接続したときのメッセージを出力
            if(Network.peerType == NetworkPeerType.Client)
            {
                GUI.Label(new Rect(20, 20, 200, 25), "Connencted to Server");
            }
        }
    }

    //ゲームサーバーとして起動し、サーバーの初期化が正常に完了したときに呼び出される
    void OnServerInitialized()
    {
        //StartCoroutine(this.CreatePlayer());
    }

    void OnConnectedToSever()
    {
        //StartCoroutine(this.CreatePlayer());
    }

}

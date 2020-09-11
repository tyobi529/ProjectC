using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class LoginController : MonoBehaviourPunCallbacks
{

    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        var v = new Vector2(0, -1);

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            PhotonNetwork.Instantiate("GameController", v, Quaternion.identity);

            PhotonNetwork.Instantiate("Player", v, Quaternion.identity);
        }

        else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            PhotonNetwork.Instantiate("Player", v, Quaternion.identity);


        }


    }
}
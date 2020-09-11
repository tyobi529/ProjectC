using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPunCallbacks, IPunObservable
{
    public int[] kind = new int[30];

    public GameObject Scaffold;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject a = Instantiate(Scaffold) as GameObject;
            a.transform.position = new Vector2(-2 + 2 * i, 2);
        }

        if (photonView.IsMine)
        {
            for (int i = 0; i < kind.Length; i++)
            {
                kind[i] = Random.Range(1, 8);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // データを送受信するメソッド
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(kind);
        }
        else
        {
            kind = (int[])stream.ReceiveNext();

        }
    }

}

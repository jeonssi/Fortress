using Photon.Pun;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Create : MonoBehaviourPunCallbacks
{
    [SerializeField] int count = 0;
    [SerializeField] Transform[] transforms; 

   
    public void Create()
    {
        PhotonNetwork.Instantiate
        (

            "Character",
            transforms[count++].position,
            Quaternion.identity

        );
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        count--;
    }

}

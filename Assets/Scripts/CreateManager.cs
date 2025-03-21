using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CreateManager : MonoBehaviourPunCallbacks
{
    [SerializeField] int count = 0;
    [SerializeField] Transform[] transforms;

    private void Awake()
    {
        Create();
    }

    public void Create()
   {
        PhotonNetwork.Instantiate
        (
            "Character",
            Vector3.zero,
            Quaternion.identity

        );
   }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        count--;
    }
}

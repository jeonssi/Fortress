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
        if (transforms == null || transforms.Length == 0)
        {
            return;
        }
        Create();
    }

    public void Create()
   {
        int index = Random.Range(0, transforms.Length);
        Transform spawnPoint = transforms[index];

        PhotonNetwork.Instantiate
        (
            "Character",
            Vector3.zero,
            Quaternion.identity

        );
   }

 
}

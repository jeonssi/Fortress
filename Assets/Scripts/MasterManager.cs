using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.EventSystems.EventTrigger;

public class MasterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            StartCoroutine(Create());
        }
        PhotonNetwork.InstantiateRoomObject("Character", Vector3.zero, Quaternion.identity);
    }


    IEnumerator Create()
    {
        while(true)
        {
            if(PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.InstantiateRoomObject("Energy", Vector3.zero, Quaternion.identity);
            }

            yield return waitForSeconds;
        }
        
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        StartCoroutine(Create());
    }


}

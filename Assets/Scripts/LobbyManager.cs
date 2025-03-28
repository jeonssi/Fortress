using Photon.Pun;
using Photon.Realtime; 

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Dropdown dropDown;

    public void Connect()
    {
        if(PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.ConnectUsingSettings(); //연결시도
        }
        else
        {
            Debug.Log("Already connected to Photon. Current State:" + PhotonNetwork.NetworkClientState);
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                dropDown.options[dropDown.value].text,
                LobbyType.Default
            )
        );
    }

    public override void OnJoinedLobby()
    {
        StartCoroutine(LoadRoom());
    }

    private IEnumerator LoadRoom()
    {
        while (!PhotonNetwork.IsConnectedAndReady)
        {
            yield return null;
        }

        PhotonNetwork.LoadLevel("Room");
    }


}


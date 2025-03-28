using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviourPunCallbacks
{
    public void Resume()
    {
        gameObject.SetActive(false);
        MouseManager.Instance.SetMouse(false);
    }
     
    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
        //gameObject.SetActive(false);
    }

   

    public override void OnLeftRoom()
    {
        gameObject.SetActive(false);

        PhotonNetwork.JoinLobby();

        PhotonNetwork.LoadLevel("Room");
    }
}

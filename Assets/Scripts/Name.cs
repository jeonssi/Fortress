using Photon.Pun;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNametext;

    private void Awake()
    {
        nickNametext = GetComponent<Text>();

        PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("Name");

        if (photonView.IsMine)
        {
            nickNametext.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            nickNametext.text = photonView.Owner.NickName;
        }
    }
}

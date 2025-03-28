using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NickNameManager : MonoBehaviour
{
    [SerializeField] GameObject nickNamePanel;
    private void Awake()
    {

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Name")) )
        {
            nickNamePanel.SetActive(true);
        }
        else
        {
            nickNamePanel.SetActive(false);
        }
    }

}
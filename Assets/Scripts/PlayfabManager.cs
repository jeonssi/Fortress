using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using PlayFab.ClientModels;
using UnityEngine.UI;
using PlayFab;

public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject failurePanel;
    [SerializeField] InputField emailInputField;
    [SerializeField] InputField passwordInputField;

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress
        (
            request,
            Succeed,
            Fail
        );
    }

    public void Succeed(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Lobby");
    }

    public void Fail(PlayFabError playFabEroor)
    {
        failurePanel.SetActive(true);
        Debug.Log(playFabEroor.ToString());
    }
}

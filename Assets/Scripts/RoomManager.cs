using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputFiled;
    [SerializeField] InputField capacityInputField;

    [SerializeField] Transform parentTransform;

    void Start()
    {
        
    }

}

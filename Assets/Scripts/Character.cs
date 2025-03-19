using Photon.Pun;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviourPun
{
    [SerializeField] GameObject remoteCamera;
    // Start is called before the first frame update
    void Start()
    {
        DisableCamera();
        //if (photonView.IsMine == true)
        //{
        //    if (remoteCamera == null)
        //    {
        //        remoteCamera = GameObject.Find("Camera");
        //    }
        //    remoteCamera.SetActive(false);
        //}
    }

    public void DisableCamera()
    {
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.SetActive(false);
        }
    }
   
}

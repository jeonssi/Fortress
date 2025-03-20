using Photon.Pun;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] GameObject remoteCamera;
    [SerializeField] Rigidbody rigidBody;
    private void Awake()
    {
        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
    }
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

    private void Update()
    {
        if (!photonView.IsMine) return;
        move.OnkeyUpdate();
    }
    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;
        move.OnMove(rigidBody);
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

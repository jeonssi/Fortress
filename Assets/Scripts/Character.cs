using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent (typeof(Rotation))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] GameObject remoteCamera;
    [SerializeField] Rigidbody rigidBody;
    private void Awake()
    {
        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
        rotation = GetComponent<Rotation>();    
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

        if(photonView.IsMine == false)
        {
            return;
        }
        move.OnkeyUpdate();
        rotation.OnMouseUpdate();
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine == false)
        {
            return;
        }
        move.OnMove(rigidBody);
        rotation.RotateY(rigidBody);
       
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

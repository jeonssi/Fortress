using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent (typeof(Rotation))]
[RequireComponent(typeof (Create))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] GameObject remoteCamera;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Create create;
    private void Awake()
    {
        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
        rotation = GetComponent<Rotation>();    
        create = GetComponent<Create>();    
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
        create.OnPlayerLeftRoom(Player otherPlayer)
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

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

    [SerializeField] Pause pausePanel;
    private void Awake()
    {
        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
        rotation = GetComponent<Rotation>();   
        
        pausePanel = FindObjectOfType<Pause>(true);
    }

    void Start()
    {
        DisableCamera();
      
    }

    private void Update()
    {

        if(photonView.IsMine == false)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            pausePanel.gameObject.SetActive(true);

        }
        move.OnkeyUpdate();
        rotation.OnMouseX();
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

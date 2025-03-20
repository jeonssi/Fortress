using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    private Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    public void OnkeyUpdate()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        direction.Normalize();
    }

    public void OnMove(Rigidbody rigidBody)
    {
        rigidBody.position += rigidBody.transform.TransformDirection(direction * speed * Time.fixedDeltaTime);
    }

}

using System.Collections;
using System.Collections.Generic;

using TMPro.EditorUtilities;

using UnityEngine;

public class Rotation : MonoBehaviour
{
    //Mouse X
    [SerializeField] float speed;
    [SerializeField] float mouseX;
   
    public void OnMouseUpdate()
    {
        //mouseX �� ���콺�� �Է��� ���� �����մϴ�.
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;

    }

    public void RotateY(Rigidbody rigiBbody)
    {
        rigiBbody.transform.eulerAngles = new Vector3(0f, mouseX, 0f);
    }
}

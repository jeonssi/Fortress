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
        //mouseX 에 마우스로 입력한 값을 저장합니다.
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;

    }

    public void RotateY(Rigidbody rigiBbody)
    {
        rigiBbody.transform.eulerAngles = new Vector3(0f, mouseX, 0f);
    }
}

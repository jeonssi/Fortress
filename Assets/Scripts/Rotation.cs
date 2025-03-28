using System.Collections;
using System.Collections.Generic;

using TMPro.EditorUtilities;

using UnityEngine;

public class Rotation : MonoBehaviour
{
    //Mouse X
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    //[SerializeField] float minPitch = -20f;  
    //[SerializeField] float maxPitch = 30f;  
    public void OnMouseX()
    {
        //mouseX 에 마우스로 입력한 값을 저장합니다.
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
       
    }
    public void OnMouseY()
    {
        // mouseY = Mathf.Clamp(mouseY, minPitch, maxPitch);
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigiBbody)
    {
        rigiBbody.transform.eulerAngles = new Vector3(0f, mouseX, 0f);
    }

    public void RotateX(GameObject clone)
    {
        //MouseY 의 값을 -65 ~65 사이의 값으로 제한
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        clone.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);

    }
}

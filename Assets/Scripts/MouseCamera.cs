using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
     public Vector2 turn;
     public float sensitivity = .5f;
     public Vector3 deltaMove;
     public float speed = 1;
     public GameObject Mover;

     void start()
     {
        Cursor.lockState = CursorLockMode.Locked;
     }
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("mouse Y") * sensitivity;
        Mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y,0, 0);

        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        Mover.transform.Translate(deltaMove);
    }
}

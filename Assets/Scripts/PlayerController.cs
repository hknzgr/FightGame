using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myBody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseController();
    }

    void MouseController()
    {
        if (Input.GetMouseButton(0))
        {
            Quaternion targetRotation;
            float MouseX = Input.GetAxis("Mouse X");
            float MouseY = Input.GetAxis("Mouse Y");
            if (MouseX != 0 && MouseY != 0)
            {
                myBody.velocity = new Vector3(MouseX * 0.000001f, myBody.velocity.y, MouseY * 0.000001f); // Good Trick
                targetRotation = Quaternion.LookRotation(new Vector3(MouseX, 0, MouseY));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
            }
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
    }
}

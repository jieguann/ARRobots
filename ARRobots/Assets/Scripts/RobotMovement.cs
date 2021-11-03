using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private Animator robotAnim;
    private Rigidbody robotBody;
    private Joystick  joystick;
    // Start is called before the first frame update
    void OnEnable()
    {
        robotAnim = GetComponent<Animator>();
        robotBody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();

        //play the open animation
        robotAnim.SetBool("Open_Anim", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Direction.magnitude > 0)
        {
            robotBody.AddForce(transform.forward * moveSpeed);
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        //Rotation of the Robot
        Vector3 targetDiraction = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
    }
}

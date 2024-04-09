using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1_Controller : MonoBehaviour
{
    private Rigidbody MyRB;
    private Vector3 _velocity;
    public float VelocM;

    public float JumpForce;
    private bool CanJump;
    RaycastHit hit;
    public float RayDistance;
    public LayerMask Layers;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody>();
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.position += _velocity * VelocM;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, RayDistance, Layers))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            CanJump = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RayDistance, Color.white);
            CanJump = false;
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        _velocity = context.ReadValue<Vector3>();
    }
    public void OnJunp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(CanJump == true)
            {
                MyRB.AddForce(transform.up * JumpForce);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private InputController InputController;

    Animator animator;
    Vector3 movement;
    Rigidbody rigidbody;

    public float speed = 5.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRun", true);
        }
        else
            animator.SetBool("isRun", false);
    }

    private void FixedUpdate()
    {
        movement.x = InputController.returnHorizontal();
        movement.z = InputController.returnVertical();

        Vector3 _moveHorizontal = transform.right * movement.x;
        Vector3 _moveVertical = transform.forward * movement.z;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        movement.Normalize();

        rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);
        
    }
}

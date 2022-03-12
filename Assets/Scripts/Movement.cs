using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public float bounceForce;
    public Vector3 velocity;
    public CharacterController controller;
    float stepOffset;
    public Vector3 impact;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {
        stepOffset = controller.stepOffset;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            controller.stepOffset = 0.5f;
        }
        else
        {
            controller.stepOffset = 0f;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        movement = movement * speed * Time.deltaTime;

        controller.Move(movement);

        if (Input.GetButtonDown("Jump") && isGrounded) //controller.isGrounded
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (impact.magnitude > 0.2)
        {
            controller.Move(impact * Time.deltaTime);
            impact = Vector3.Lerp(impact, Vector3.zero, 10 * Time.deltaTime);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            print("Player");
            Vector3 dir = transform.position - enemy.transform.position;
            impact = dir.normalized * bounceForce / 3f;
        }
    }
}
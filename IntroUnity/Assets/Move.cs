using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 jumpForce = new Vector3(0.0f, 10.0f, 0.0f);
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1.0f;
        }

        Vector3 movement = transform.forward * moveDir.y + transform.right * moveDir.x;
        moveDir = movement * speed * Time.deltaTime;

        transform.Translate(moveDir.x, 0.0f, moveDir.y);

        Jump();
    }
}

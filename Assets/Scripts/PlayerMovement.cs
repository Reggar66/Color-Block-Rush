using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float movementSpeed = 10f;
    public float movementClamp = 5f;

    private float x_axis = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateX_Axis();
    }

    private void FixedUpdate()
    {
        Movement();
        //Movement2();
    }

    private void Movement()
    {
        float x = x_axis * movementSpeed * Time.deltaTime;

        Vector2 newPosition = rb2d.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -movementClamp, movementClamp);

        rb2d.MovePosition(newPosition);
    }

    private void UpdateX_Axis()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            x_axis = 0f;
        }


        if (Input.GetKey(KeyCode.D))
        {
            x_axis = Mathf.MoveTowards(x_axis, 1f, 3f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x_axis = Mathf.MoveTowards(x_axis, -1f, 3f * Time.deltaTime);
        }
        else
        {
            x_axis = Mathf.MoveTowards(x_axis, 0f, 3f * Time.deltaTime);
        }
    }

    private void Movement2()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        Debug.Log(Input.GetAxis("Horizontal"));
        rb2d.MovePosition(rb2d.position + Vector2.right * x);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
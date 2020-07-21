using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPositionCorrection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameObject.transform.position += new Vector3(0, 2, 0);
        }
    }
}
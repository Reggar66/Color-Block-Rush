using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Image[] lifes;
    public int life = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddHeart();
            if (life < 3)
            {
                life++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            IgnoreCurrentBlocks();
            RemoveHeart();
            life--;
            GameController.Instance.SlowOnCollision(life);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heal"))
        {
            AddHeart();
            if (life < 3)
            {
                life++;
            }
            Destroy(other.gameObject);
        }
    }

    private void IgnoreCurrentBlocks()
    {
        foreach (GameObject block in BlockSpawner.Instance.lastSpawnedBlocks)
        {
            // Change tag of the block to ignore life removing
            block.tag = "Untagged";
        }
    }

    private void RemoveHeart()
    {
        if (life > 0)
        {
            lifes[life - 1].enabled = false;
        }
    }

    private void AddHeart()
    {
        if (life < 3)
        {
            lifes[life].enabled = true;
        }
    }
}
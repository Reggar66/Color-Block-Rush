using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLifeHandler : MonoBehaviour
{
    public float destroyPosition = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndDestroy();
    }

    private void CheckAndDestroy()
    {
        if (transform.position.y <= destroyPosition)
        {
            Destroy(this.gameObject);
        }
    }
}

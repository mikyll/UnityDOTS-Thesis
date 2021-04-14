using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float maxHeight, minHeight;
    public float moveSpeed = 1.0f;
    // Update is called once per frame
    private void Start()
    {
        if (transform.position.y < minHeight && moveSpeed > 0)
            moveSpeed = -moveSpeed;
        if (transform.position.y > maxHeight && moveSpeed < 0)
            moveSpeed = -moveSpeed;
    }

    void Update()
    {
        if(transform.position.y > maxHeight)
        {
            moveSpeed = -moveSpeed;
        }
        else if(transform.position.y < minHeight)
        {
            moveSpeed = -moveSpeed;
        }

        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);

    }
}

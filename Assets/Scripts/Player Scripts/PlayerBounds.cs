using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // private SpriteRenderer mySR;
    private float playerSize;
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        playerSize = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        } else if (transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        maxX = bounds.x - playerSize/1.5f;
        minX = -bounds.x + playerSize/1.5f;
    }
}

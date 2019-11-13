using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    /// <summary>
    /// Scales the Background to Screen Width.
    /// </summary>
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer bgSR = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float width = bgSR.sprite.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2;
        //float worldWidth = worldHeight * Screen.width / Screen.height;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
    }

}

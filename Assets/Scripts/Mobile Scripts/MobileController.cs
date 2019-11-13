using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveMobile playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveMobile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("release button");
        if (gameObject.name == "Left")
        {
            playerMove.MoveLeft = false;
            playerMove.MoveRight = false;
            //playerMove.StopMoving();
        }

        if (gameObject.name == "Right")
        {
            playerMove.MoveLeft = false;
            playerMove.MoveRight = false;
            //playerMove.StopMoving();
        }

    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("hold button");
        if (gameObject.name == "Left")
        {
            playerMove.MoveLeft = true;
            playerMove.MoveRight = false;
        }

        if (gameObject.name == "Right")
        {
            playerMove.MoveRight = true;
            playerMove.MoveLeft = false;
        }
    }
}

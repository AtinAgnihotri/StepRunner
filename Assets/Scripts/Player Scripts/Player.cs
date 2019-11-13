using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8f, maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myRG;
    [SerializeField]
    private Animator myAnim;
    [SerializeField]
    private SpriteRenderer mySR;

    bool animBool;

    private void Awake()
    {
        myRG = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }

    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void SetAnimation()
    {
        myAnim.SetBool("Run", animBool);
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myRG.velocity.x);

        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            //Debug.Log("h greater 0");
            //myAnim.SetBool("Run", true);
            animBool = true;
            mySR.flipX = false;
            if (vel < maxVelocity)
                forceX = speed;
            
        } else if (h < 0)
        {
            //Debug.Log("h lesser 0");
            //myAnim.SetBool("Run", true);
            animBool = true;
            mySR.flipX = true;
            if (vel < maxVelocity)
                forceX = -speed;
        }
        else
        {
            //myAnim.SetBool("Run", false);
            //mySR.flipX = false;
            animBool = false;
            float yVel = myRG.velocity.y;
            myRG.velocity = new Vector2(0f, yVel);
        }

        myRG.AddForce(new Vector2(forceX, 0));
    }
}

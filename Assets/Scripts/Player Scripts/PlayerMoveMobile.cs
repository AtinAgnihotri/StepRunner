using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMobile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f, maxVelocity = 70f;

    [SerializeField]
    private Rigidbody2D myRG;
    [SerializeField]
    private Animator myAnim;
    [SerializeField]
    private SpriteRenderer mySR;

    bool animBool;

    private bool moveLeft, moveRight;

    public bool MoveLeft
    {
        //get
        //{
        //    return this.moveLeft;
        //}
        set
        {
            this.moveLeft = value;
        }
    }

    public bool MoveRight
    {
        //get
        //{
        //    return this.moveRight;
        //}
        set
        {
            this.moveRight = value;
        }
    }

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
        if (moveLeft)
        {
            MoveLeftFn();
        }
        else if (moveRight)
        {
            MoveRightFn();
        }
        else
        {
            MoveHaltFn();
        }

    }

    void MoveLeftFn()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myRG.velocity.x);
        animBool = true;
        mySR.flipX = true;
        if (vel < maxVelocity)
            forceX = -speed;
        myRG.AddForce(new Vector2(forceX, 0));
    }

    void MoveRightFn()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myRG.velocity.x);
        animBool = true;
        mySR.flipX = false;
        if (vel < maxVelocity)
            forceX = speed;
        myRG.AddForce(new Vector2(forceX, 0));
    }

    void MoveHaltFn()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myRG.velocity.x);
        animBool = false;
        float yVel = myRG.velocity.y;
        myRG.velocity = new Vector2(0f, yVel);
        myRG.AddForce(new Vector2(forceX, 0));
    }

    void SetAnimation()
    {
        myAnim.SetBool("Run", animBool);
    }

    public void StopMoving()
    {
        animBool = moveLeft = moveRight = false;
        myAnim.SetBool("Run", animBool);
    }
}

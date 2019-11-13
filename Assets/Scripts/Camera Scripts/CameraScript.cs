using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed = 1f;
    private float accelaration = 0.2f;
    private float maxSpeed = 3.2f;

    [SerializeField]
    private float easySpeed = 3.4f;

    [SerializeField]
    private float mediumSpeed = 3.8f;

    [SerializeField]
    private float hardSpeed = 4.2f;


    [HideInInspector]
    public bool moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxSpeed();
        moveCamera = true;
    }

    void SetMaxSpeed()
    {
        if (GamePreferences.EasyDifficulty == 1)
            maxSpeed = easySpeed;
        if (GamePreferences.MediumDifficulty == 1)
            maxSpeed = mediumSpeed;
        if (GamePreferences.HardDifficulty == 1)
            maxSpeed = hardSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        Vector3 temp = transform.position;

        float oldY = temp.y;
        float newY = oldY - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        if (speed < maxSpeed)
        {
            speed += accelaration * Time.deltaTime;
        }
        else
        {
            speed = maxSpeed;
        }
        transform.position = temp;
        
    }
}

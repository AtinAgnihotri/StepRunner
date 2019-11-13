using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] steps;
    [SerializeField]
    private float distanceBetweenSteps = 3f;

    private float minX, maxX;

    private float controlX;

    private float lastStepPositionY;
    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    private float stepSize, stepSizeY, playerSizeY, collectableSize;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSizeY = player.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        controlX = 0;
        stepSize = steps[0].GetComponent<SpriteRenderer>().bounds.size.x / 2;
        stepSizeY = steps[0].GetComponent<SpriteRenderer>().bounds.size.y / 2;
        collectableSize = 0f;
        SetMinAndMaxX();
        CreateSteps();

        for(int i=0; i<collectables.Length; i++)
        {
            collectables[i].SetActive(false);
            if (collectableSize == 0f)
                if (collectables[i].gameObject.tag == "Coin")
                    collectableSize = collectables[i].GetComponent<SpriteRenderer>().bounds.size.y / 2;
        }
    }

    void Start()
    {
        PositionThePlayer();
    }

    void Shuffle(GameObject [] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++) {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        maxX = bounds.x - stepSize;
        minX = -bounds.x + stepSize;
        //Debug.Log("MinX is " + minX);
        //Debug.Log("MaxX is " + maxX);
        //Debug.Log("boundX is " + bounds.x);
        //Debug.Log("MaxX is " + maxX);

    }

    void CreateSteps()
    {
        Shuffle(steps);
        float positionY = 0f;

        for(int i=0; i<steps.Length; i++)
        {
            Vector3 tempLocation = steps[i].transform.position;
            tempLocation.y = positionY;
            //tempLocation.x = Random.Range(minX, maxX);
            switch (controlX)
            {
                case 0:
                    tempLocation.x = Random.Range(0f, maxX);
                    controlX = 1;
                    break;
                case 1:
                    tempLocation.x = Random.Range(0f, minX);
                    controlX = 2;
                    break;
                case 2:
                    tempLocation.x = Random.Range(1f, maxX);
                    controlX = 3;
                    break;
                case 3:
                    tempLocation.x = Random.Range(-1f, minX);
                    controlX = 0;
                    break;
            }
            lastStepPositionY = positionY;
            steps[i].transform.position = tempLocation;
            positionY -= distanceBetweenSteps;
        }
    }

    void PositionThePlayer()
    {
        GameObject[] gameSteps = GameObject.FindGameObjectsWithTag("Step");
        GameObject[] sandySteps = GameObject.FindGameObjectsWithTag("Sandy");

        for (int i = 0; i < sandySteps.Length; i++){
            if (sandySteps[i].transform.position.y == 0f) {
                Vector3 temp = sandySteps[i].transform.position;
                sandySteps[i].transform.position = new Vector3(gameSteps[0].transform.position.x,
                                                               gameSteps[0].transform.position.y,
                                                               gameSteps[0].transform.position.z);
                gameSteps[0].transform.position = temp;
            }
        }

        Vector3 stepTemp = gameSteps[0].transform.position;

        for(int i = 0; i < gameSteps.Length; i++)
        {
            if (stepTemp.y < gameSteps[i].transform.position.y)
            {
                stepTemp = gameSteps[i].transform.position;
            }
        }

        stepTemp.y += playerSizeY;
        player.transform.position = stepTemp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Step" || target.tag == "Sandy")
        {
            //Debug.Log("Name of Entered Object: " + target.gameObject.name );
            //Debug.Log("Last Y: " + lastStepPositionY );
            //Debug.Log("Y of Entered Object: " + target.gameObject.transform.position.y );
            if (target.transform.position.y == lastStepPositionY)
            {
                //Debug.Log("Spawned Some New Ones");
                Shuffle(steps);
                Shuffle(collectables);

                Vector3 tempLocation = target.transform.position;
                
                for(int i=0; i < steps.Length; i++) {
                    if(!steps[i].activeInHierarchy)
                    {
                        switch (controlX)
                        {
                            case 0:
                                tempLocation.x = Random.Range(0f, maxX);
                                controlX = 1;
                                break;
                            case 1:
                                tempLocation.x = Random.Range(0f, minX);
                                controlX = 2;
                                break;
                            case 2:
                                tempLocation.x = Random.Range(1f, maxX);
                                controlX = 3;
                                break;
                            case 3:
                                tempLocation.x = Random.Range(-1f, minX);
                                controlX = 0;
                                break;
                        }

                        tempLocation.y -= distanceBetweenSteps;
                        //if (lastStepPositionY > steps[i].transform.position.y)
                            //lastStepPositionY = steps[i].transform.position.y;
                        
                        steps[i].transform.position = tempLocation;
                        lastStepPositionY = steps[i].transform.position.y;
                        steps[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);

                        if (steps[i].tag != "Sandy")
                        {
                            if (!collectables[random].activeInHierarchy)
                            {

                                if (!((collectables[random].tag == "Life") && (PlayerScore.lifeCount >= 2)))
                                {
                                    Vector3 collectableTemp = tempLocation;
                                    collectableTemp.y += stepSizeY + collectableSize;
                                    //collectableTemp.y += collectableSize;
                                    //collectableTemp.y += collectableSize;
                                    collectables[random].transform.position = collectableTemp;
                                    collectables[random].SetActive(true);
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}

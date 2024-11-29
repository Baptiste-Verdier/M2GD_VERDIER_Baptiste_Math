using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private float speed = 5f;
    private Vector2 length;
    Vector2 screenSize;
    Vector2 laserSize;
    public Vector3 rockPos;
    private Vector2 birthPos;
    private float distance;
    private GameObject[] rocks;
    public GameObject rock;
    private float rockRad;
    // Start is called before the first frame update
    void Start()
    {
        birthPos = transform.position;
       
    }
    void Awake()
    {
        Camera mainCamera = Camera.main;
        screenSize = (mainCamera.ViewportToWorldPoint(Vector2.one) - mainCamera.ViewportToWorldPoint(Vector2.zero)) / 2;
     
    }

    // Update is called once per frame
    void Update()
    {
      rocks = GameObject.FindGameObjectsWithTag("Rock") ;
        foreach (GameObject rock in rocks) 
        {
            rockPos = rock.GetComponent<RockBehaviour>().transform.position;
            rockRad = rock.GetComponent<RockBehaviour>().rockSize.x;
            if (laserRockCollision() == true)
            {Debug.Log(laserRockCollision());
            rock.GetComponent<RockBehaviour>().size = rock.GetComponent<RockBehaviour>().size -1 ;
                if (rock.GetComponent<RockBehaviour>().size != 0)
                {
                    Instantiate(rock, rockPos, transform.rotation);
                    Instantiate(rock, rockPos, transform.rotation);
                }
                Destroy(rock);
                Destroy(gameObject);
            }

        }

        transform.position += transform.up * speed * Time.deltaTime;
        distance = (birthPos.x - transform.position.x) * (birthPos.x - transform.position.x) + (birthPos.y - transform.position.y) * (birthPos.y - transform.position.y);

        if (distance  >= screenSize.x * screenSize.x + screenSize.y * screenSize.y)
        {
        
           
        Destroy(gameObject);
        }
    }

    bool laserRockCollision()
    {
        if (DistanceLaserRock() <= rockRad)
        {
            return true;
        }
        else { return false; }

    }

    float DistanceLaserRock()
    {
        Vector2 distance = rockPos - transform.position;
        return Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
    }
}

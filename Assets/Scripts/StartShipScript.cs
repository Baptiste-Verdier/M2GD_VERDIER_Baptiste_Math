using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShipScript : MonoBehaviour
{
    public int rockNumber = 7;
    public GameObject rock;
    public GameObject ship;
    Vector2 screenSize;
    Vector2 rockSize;
    // Start is called before the first frame update
    void Awake()
    {
        Camera mainCamera = Camera.main;
        screenSize = (mainCamera.ViewportToWorldPoint(Vector2.one) - mainCamera.ViewportToWorldPoint(Vector2.zero)) / 2;
        rockSize = rock.GetComponent<SpriteRenderer>().bounds.size / 2;
    }
    void Start()
    {

        Instantiate(ship, Vector2.one, transform.rotation);
        for (int i = 0; i < rockNumber; i++)
        {
            Vector3 rockPosition = new Vector3(Random.Range(screenSize.x + rockSize.x, screenSize.x - rockSize.x), Random.Range(-screenSize.y, screenSize.y), 0);
            Instantiate(rock, rockPosition, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

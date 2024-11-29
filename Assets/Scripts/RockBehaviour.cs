using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.UIElements;

public class RockBehaviour : MonoBehaviour
{
  private float baseSlow = 1f;
   
    public Vector2 rockSize;
   public Vector2 screenSize;
   public Vector2 shipSize;
   public Vector3 shipPos;
    public Sprite rockL;
    public Sprite rockM;
    public Sprite rockS;
    private Sprite sprite;
   public int size = 3;

    


    // Start is called before the first frame update
    void Start()
    {
        shipSize = ShipBehaviour.instance.GetComponent<SpriteRenderer>().bounds.size/2;

       
        if (size == 3)
        {
            sprite = rockL;
        }
        else if (size == 2)
        {
            sprite = rockM;
            transform.localScale = transform.localScale/1.5f;
            baseSlow = baseSlow * 2;
        }
        else
        { 
            sprite = rockS;
            transform.localScale = transform.localScale/1.5f;
            baseSlow = baseSlow * 4;
        }
        GetComponent<SpriteRenderer>().sprite = sprite;
        rockSize = Vector2.one * sprite.bounds.size.x / 2 * transform.localScale.x;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));

    }
    void Awake()
    {
        Camera mainCamera = Camera.main;
        screenSize = (mainCamera.ViewportToWorldPoint(Vector2.one) - mainCamera.ViewportToWorldPoint(Vector2.zero)) / 2;
      
      
    }

    // Update is called once per frame
    void Update()
    {
      shipPos = ShipBehaviour.instance.transform.position;
      

        // téléportation aux bords de l'écran
        transform.position += transform.up * baseSlow * Time.deltaTime;
        if (transform.localPosition.x > screenSize.x + rockSize.x)
        {
            transform.position = new Vector3(-screenSize.x - rockSize.x, transform.position.y);
        }
        if (transform.localPosition.x < -screenSize.x - rockSize.x)
        {
            transform.position = new Vector3(screenSize.x + rockSize.x, transform.position.y);
        }
        if (transform.localPosition.y > screenSize.y + rockSize.y)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y - rockSize.y); 
        }
        if (transform.localPosition.y < -screenSize.y - rockSize.y)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y + rockSize.y);
        }

        //changements de tailles
        if (ShipRockCollision() == true) 
        { 
            SceneManager.LoadScene(1);
        } 
     
        
    }


  
    bool ShipRockCollision()
    {
        if (DistanceShipRock() <= rockSize.x + shipSize.x)
        {
            return true;
        }
        else { return false; }

    }

    float DistanceShipRock()
    {
        Vector2 distance = shipPos - transform.position;
        return Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rockSize.x);
    }




}

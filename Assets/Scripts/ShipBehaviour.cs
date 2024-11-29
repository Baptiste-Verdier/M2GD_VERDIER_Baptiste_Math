using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


public class ShipBehaviour : MonoBehaviour
{
    Vector3 position;
    Vector3 rockPosition;
   public Vector2 shipSize;
    Vector2 screenSize;
   private float speed;

    public GameObject laser;
    private float acceleration = 1f;

    private bool reload = true;
    private float fireRate = 0.2f;

    private float distanceX;
    private float distanceY;
    private float angleTan;
    private bool waitDone = false;
    Vector3 mousePos1 = Vector3.zero;
    Vector3 mousePos2 = Vector3.zero;

    public static ShipBehaviour instance;
    void Awake()
    {
        instance = this;
      Camera  mainCamera = Camera.main;
        screenSize = (mainCamera.ViewportToWorldPoint(Vector2.one) - mainCamera.ViewportToWorldPoint(Vector2.zero))/2;
        shipSize = GetComponent<SpriteRenderer>().bounds.size;
    }

     void Start()
    {
        
    }

    void Update()
    {

        
        //mouvement avec flèches
        //transform.position += position;
        // position.x = (position.x + speed.x) * Time.deltaTime;
        // position.y = (position.y + speed.y) * Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    speed.x = speed.x + acceleration ;
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    speed.x = speed.x - acceleration;
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    speed.y = (speed.y + acceleration);
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    speed.y = (speed.y - acceleration);
        //}




        //Téléportation du vaisseau quand il arrive derrière la caméra. Respectivement : Bas, Haut, Gauche, Droite
        if (transform.localPosition.y < -screenSize.y - shipSize.y)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y + shipSize.y / 2);
        }
        else if (transform.localPosition.y > screenSize.y + shipSize.y)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y - shipSize.y / 2);
        }
        else if (transform.localPosition.x < -screenSize.x - shipSize.x)
        {
            transform.position = new Vector3(screenSize.x + shipSize.x / 2, transform.position.y);
        }
        else if (transform.localPosition.x > screenSize.x + shipSize.x)
        {
            transform.position = new Vector3(-screenSize.x - shipSize.x / 2, transform.position.y);
        }

        //Blocage Vitesse
        if (speed <= 0)
        {
            speed = 0;
        }
        else if (speed >= 100)
        {
            speed = 99;
        }


        //rotation + mouvements avec souris
        Move();
        transform.position += transform.up * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                speed = speed + acceleration;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && reload == true)
            {
                shoot();
            }

            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                speed = speed - acceleration;
            }
            
       
        
    }

    private void shootRate()
        {
            reload = true;
        }
    private void shoot()
        {
           
                Instantiate(laser, transform.position, transform.rotation);
                reload = false;
                Invoke("shootRate", fireRate);
            
        }

    private void Move()
    {
        

        mousePos1 = Input.mousePosition;
        Invoke("Wait", 1f);
       
        if (waitDone == true) 
        {
            mousePos2 = Input.mousePosition;
            waitDone = false;
        }

        if (mousePos1 - mousePos2 != Vector3.zero)
        {
                distanceX = Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x;
                distanceY = Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y;
                angleTan = Mathf.Atan2(distanceY, distanceX) * (180 / Mathf.PI);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleTan - 90));
        }
    }

    private void Wait()
    {
         waitDone = true;
    }
        

 
}

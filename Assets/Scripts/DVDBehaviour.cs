using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DVDBehaviour : MonoBehaviour
{
    [SerializeField] Vector2 screenSize;
    Vector2 dvdSize;
    [SerializeField] private int horizontalSpeed = 1;
    [SerializeField] private int verticalSpeed = 1;
    public int absoluteSpeed;

    // Start is called before the first frame update
    void Start()
    {
        screenSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta/2;
        dvdSize = GetComponent<RectTransform>().sizeDelta /2;
        GetComponent<Image>().color = Color.blue;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (horizontalSpeed, verticalSpeed,0) * absoluteSpeed * Time.deltaTime;
        Debug.Log(transform.localPosition);
        if (transform.localPosition.y >= screenSize.y - dvdSize.y) 
        {
            verticalSpeed = -1;
           
        }
        if (transform.localPosition.x >= screenSize.x - dvdSize.x)
        {
            horizontalSpeed = -1;
        }
       
        if ( transform.localPosition.y <= -screenSize.y + dvdSize.y)
        {
            verticalSpeed = 1;
        }
        if ( transform.localPosition.x <= -screenSize.x + dvdSize.x)
        {
            horizontalSpeed = 1;
        }
    }
}

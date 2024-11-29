using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public GameObject player;
    private float distanceX;
    private float distanceY;
    private float angleTan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceX = transform.position.x - player.GetComponent<Transform>().transform.position.x;
        distanceY = transform.position.y - player.GetComponent<Transform>().transform.position.y;
        angleTan = Mathf.Atan2(distanceY , distanceX) * (180 / Mathf.PI);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleTan+90));
    }
}

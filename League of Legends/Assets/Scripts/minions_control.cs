using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minions_control : MonoBehaviour
{
    public GameObject minions;
    private float x;
    private bool moving;
    
    // Start is called before the first frame update
    void Start()
    {
        //newPos = new Vector3(6f,1.6f,0f); 
        //minions.transform.SetPositionAndRotation();
        moving = true;

    }

    // Update is called once per frame
    void Update()
    {
        while (moving) {
            x -= 0.1f;
            minions.transform.position = new Vector3(x, minions.transform.position.y, minions.transform.position.z);
        }
       
    }

    //when the minions meet the wall, it will stop atuo.
    private void OnTriggerEnter(Collider other) {
        moving = false;
    }
}

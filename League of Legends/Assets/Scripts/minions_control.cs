using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minions_control : MonoBehaviour
{
    public GameObject minions;
    private float x;
    private float z;
    
    //private Rigidbody rb;
    private bool stop = false;
    //private bool trunRight = false;
    #region MonoBehaviour API

    // Start is called before the first frame update
    void Start()
    {
        x = minions.transform.position.x;
        z = minions.transform.position.z;
        StartCoroutine(moving());
    }

    private void OnTriggerEnter(Collider other)
    {
        stop = true;
        Destroy(minions);
    }

    private IEnumerator moving()
    {
        while (!stop)
        {
            if (z <= 5)
            {
                z += 0.1f;
                minions.transform.position = new Vector3(minions.transform.position.x, minions.transform.position.y, z);
                yield return new WaitForSeconds(0.01f);  //delay, waiting before go back 
            } else
            {
                x += 0.1f;
                minions.transform.position = new Vector3(x, minions.transform.position.y, z);
                yield return new WaitForSeconds(0.01f);  //delay, waiting before go back 
            }
        }

        yield return null; 
    }

    // Update is called once per frame
    /* 
    void FixedUpdate()
    {
        if (!stop)
        {
            x -= 0.1f;
            //rb.velocity = new Vector3(x, minions.transform.position.y, minions.transform.position.z); ;
            minions.transform.position = new Vector3(x, minions.transform.position.y, minions.transform.position.z);
        }
        else
        {
            //call OnCollisionEnter() auto.
        }


    }
    */

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "End_Point")
        {
            stop = true;
            //Debug.Log("Stop");
            Destroy(minions);
            //Instantiate(minions, transform.position, Quaternion.identity);
        }
    }*/
    #endregion

}

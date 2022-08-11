using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponColtrol : MonoBehaviour
{

    [SerializeField] private float speed;

    void Start()
    {

    }

    void Update()
    {
        transform.position -= Vector3.left * speed * Time.deltaTime;
    }

   /*---------------Destory blocks----------------*/
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Block")
        {
            Destroy(other.gameObject);
        }

    }
}

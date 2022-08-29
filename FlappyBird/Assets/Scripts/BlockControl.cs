using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private float zOfBlock;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.Rotate(0, 0, zOfBlock + 1f, Space.World);
    }

    private void OnPlayerDeath()
    {
        speed = 0f;
    }

    /*---------------Destory blocks----------------*/
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Weapon")
        {       
            Destroy(this.gameObject);
        }

    }
}

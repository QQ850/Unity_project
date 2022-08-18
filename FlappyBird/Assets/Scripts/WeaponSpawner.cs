using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    /*------------Object & position-------------*/
    public GameObject objectToSpawn;
    public GameObject player;

    /*---------------------- Add armband ----------------------*/
    public ThalmicMyo rightHand;
    public Thalmic.Myo.Pose lastPose = Thalmic.Myo.Pose.Rest;  
    public bool makeFist = false;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    
    void Update()
    {
        if (lastPose != rightHand.pose)
        {
            lastPose = rightHand.pose;
            makeFist = false;
        }
        if (rightHand.pose.ToString() == "Fist" && !makeFist)
        {
            SpawnObject();
            makeFist = true;
        }
    }

    private void SpawnObject()
    {
        GameObject weapon = Instantiate(objectToSpawn);
        weapon.transform.position = new Vector3(-27.5f , player.transform.position.y + 6, 72f);

    }

    /*private void OnCollisionEnter(Collision other)
    {
        string str = other.gameObject.tag;
        Debug.Log(str);
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("block");
            Destroy(other.gameObject);
        }

    }*/
}
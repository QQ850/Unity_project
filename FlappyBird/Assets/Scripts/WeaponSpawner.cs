using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    /*------------Object & position-------------*/
    public GameObject objectToSpawn;
    public float xPos;
    public float yPos;
    public float zPos;

    /*---------------------- Add armband ----------------------*/
    public ThalmicMyo rightHand;
    public Thalmic.Myo.Pose lastPose = Thalmic.Myo.Pose.Rest;  
    public bool makeFist = false;

    /*------------------- objects pool -------------------*/
    [SerializeField] private ObjectPool weaponPool;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnAsync());

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
        var weapon = weaponPool.GetFromPool();
        weapon.transform.position = new Vector3(xPos, yPos, zPos);

    }

    /*
    private IEnumerator SpawnAsync()
    {
        if (lastPose != rightHand.pose)
        {
            lastPose = rightHand.pose;
            makeFist = false;
        }

        if (rightHand.pose.ToString() == "Fist" && !makeFist)
        {
            var weapon = weaponPool.GetFromPool();
            weapon.transform.position = new Vector3(xPos, yPos, zPos);
            makeFist = true;
        }
        yield return new WaitForSeconds(3f);
    }
   */
}

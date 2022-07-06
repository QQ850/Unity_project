using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //[SerializeField] private GameObject minionPrefab;
    public GameObject melee_minion, ranged_minion, cannon_minion;
    public GameObject spawnPoint;
    

    void Start()
    {
        StartCoroutine(spawn_wave());
    }
    // Update is called once per frame
   /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(minionPrefab, transform.position, Quaternion.identity);
        }
    }*/

    //take many minons and spwan them 
    private IEnumerator spawnMinions(GameObject minion, int count)
    {

        for (int i = 0; i < count; i++)
        {
            Instantiate(minion, spawnPoint.transform);
            yield return new WaitForSeconds(1f);
        }
        yield return null; //once we done just exit 
    }

    private IEnumerator spawn_wave()
    {
        StartCoroutine(spawnMinions(melee_minion, 3));
        yield return new WaitForSeconds(3f);
        StartCoroutine(spawnMinions(cannon_minion, 1));
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawnMinions(ranged_minion, 3));
        yield return null;
    }
}

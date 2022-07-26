using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(ObjectPool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private Vector2 gapRange;
    [SerializeField] private float gapSize;
    [SerializeField] private float xPos;
    [SerializeField] private float zPos;

    [SerializeField] private ObjectPool tunnelPool;
    [SerializeField] private ObjectPool scoreTriggerPool;

    private bool playerIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        //manager.OnPlayerDeath.AddListener(OnPlayerDeath);
        //tunnelPool = GetComponent<ObjectPool> ();
        StartCoroutine(SpawnAsync());
        
    }

    // Update is called once per frame
    private IEnumerator SpawnAsync()
    {

        while (playerIsAlive)
        {
            yield return new WaitForSeconds(spawnRate);
            //spawn tunnels 
            var topTunnel = tunnelPool.GetFromPool();
            var bottomTunnel = tunnelPool.GetFromPool();
            var scoreTrigger = scoreTriggerPool.GetFromPool();

            var gapPosition = Random.Range(gapRange.x, gapRange.y);
            scoreTriggerPool.transform.position = new Vector3(xPos, gapPosition, zPos);
            bottomTunnel.transform.position = new Vector3(xPos, gapPosition - gapSize - bottomTunnel.transform.localScale.y / 2, zPos);
            topTunnel.transform.position = new Vector3(xPos, gapPosition + gapSize + topTunnel.transform.localScale.y / 2, zPos);

        }
    }

    public void isAlive()
    {
        playerIsAlive = false;
    }

    /*   private void OnPlayerDeath()
       {
           StopAllCoroutines();
       }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(ObjectPool))]
public class Spawner : MonoBehaviour
{
    /*------------------- Tunnel & scoreTrigger's rate & position -------------------*/
    [SerializeField] private float spawnRate;
    [SerializeField] private Vector2 gapRange;
    [SerializeField] private float gapSize;
    [SerializeField] private float xPos;
    [SerializeField] private float zPos;

    /*------------------ Block's rate & position---------------------*/
    [SerializeField] private Vector2 blockRange;

    /*------------------- objects pool -------------------*/
    [SerializeField] private ObjectPool tunnelPool;
    [SerializeField] private ObjectPool scoreTriggerPool;
    [SerializeField] private ObjectPool blockPool;


    
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(SpawnAsync());
        
    }

    // Update is called once per frame
    private IEnumerator SpawnAsync()
    {

        while (true)
        {
            /*-------------- spawn tunnel and score trigger-------------*/
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(spawnRate);
                /*----------------- get tunnels------------------*/
                var topTunnel = tunnelPool.GetFromPool();
                var bottomTunnel = tunnelPool.GetFromPool();
                /*----------------- get scoreTrigger------------------*/
                var scoreTrigger = scoreTriggerPool.GetFromPool();


                /*------------------- Spawn Objects ------------------*/
                var gapPosition = Random.Range(gapRange.x, gapRange.y);
                scoreTrigger.transform.position = new Vector3(xPos, gapPosition, zPos);  
                bottomTunnel.transform.position = new Vector3(xPos, gapPosition - gapSize/* - bottomTunnel.transform.localScale.y / 2*/, zPos);
                topTunnel.transform.position = new Vector3(xPos, gapPosition + gapSize/* + topTunnel.transform.localScale.y / 2*/, zPos);

            }

            yield return new WaitForSeconds(spawnRate);

            /*-------------- spawn blocks -------------- */
           for (int i = 0; i < 10; i++)
           {
               yield return new WaitForSeconds(spawnRate);
               var gapPosition = Random.Range(blockRange.x, blockRange.y);
               var Block = blockPool.GetFromPool();           
               Block.transform.position = new Vector3(xPos, gapPosition, zPos);
           }

            yield return new WaitForSeconds(spawnRate);

            /*-------------- spawn both -------------- */
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(spawnRate);
              
                var topTunnel = tunnelPool.GetFromPool();
                var bottomTunnel = tunnelPool.GetFromPool();  
                var scoreTrigger = scoreTriggerPool.GetFromPool();


                /*------------------- Spawn Objects ------------------*/
                var gapPosition = Random.Range(gapRange.x, gapRange.y);
                scoreTrigger.transform.position = new Vector3(xPos, gapPosition, zPos);
                bottomTunnel.transform.position = new Vector3(xPos, gapPosition - gapSize/* - bottomTunnel.transform.localScale.y / 2*/, zPos);
                topTunnel.transform.position = new Vector3(xPos, gapPosition + gapSize/* + topTunnel.transform.localScale.y / 2*/, zPos);

                /*-------------- spawn blocks -------------- */
                yield return new WaitForSeconds(spawnRate);
                gapPosition = Random.Range(blockRange.x, blockRange.y);
                var Block = blockPool.GetFromPool();
                Block.transform.position = new Vector3(xPos, gapPosition, zPos);

            }
        }

    }


   /*   private void OnPlayerDeath()
      {
          StopAllCoroutines();
      }*/
        }

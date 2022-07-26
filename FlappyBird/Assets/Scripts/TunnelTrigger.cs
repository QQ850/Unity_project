using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTrigger : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tunnel") || other.CompareTag("ScoreTrigger"))
        {
            pool.ReturnToPool(other.gameObject);
        }
 
    }
}

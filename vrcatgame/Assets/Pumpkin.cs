using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pumpkin : MonoBehaviour
{
    public List<GameObject>  Spawners = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(this, GetSpawnLocation(), Quaternion.identity);
            Destroy(this);
        }
    }

    private Vector3 GetSpawnLocation()
    {
        var index = Random.Range(0, Spawners.Count());
        return Spawners[index].transform.position;
    }
}

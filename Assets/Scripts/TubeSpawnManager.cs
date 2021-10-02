using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawnManager : MonoBehaviour
{
    public float waitTime;
    public GameObject pipePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTube(this.waitTime));
    }

    // Update is called once per frame
    IEnumerator SpawnTube(float waitTime)
    {
        float height = Random.Range(-4f, 1.5f);
        Instantiate(pipePrefab, new Vector3(10f, height,0f), Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawnTube(waitTime));
    }
}

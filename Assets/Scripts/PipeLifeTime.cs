using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLifeTime : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetPipeLifeTime(this.lifeTime));
    }

    IEnumerator SetPipeLifeTime(float lifeTime){
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}

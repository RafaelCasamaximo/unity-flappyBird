using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFloor : MonoBehaviour
{
    public float scroll;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = scroll * Time.deltaTime;
        this.renderer.material.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));
    }
    /*
    https://www.youtube.com/watch?v=NVmRluVsoIg&ab_channel=DesignandDeploy
    */
}

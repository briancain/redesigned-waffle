using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetUIUVRandomly : MonoBehaviour
{

    public Material material;

    // Update is called once per frame
    void Update()
    {
        material.SetTextureOffset("_MainTex", new Vector2(Random.Range(0, 1.0f), Random.Range(0, 1.0f)));
    }
}


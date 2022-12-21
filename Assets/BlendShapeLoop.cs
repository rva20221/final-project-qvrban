using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlendShapeLoop : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;

    private Mesh skinnedMesh;

    private int blendShapeCount;

    private int playIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;
    }
    
    void FixedUpdate()
    {
        if (playIndex > 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(playIndex - 1, 0f);
        }

        if (playIndex == 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount - 1, 0f);
        }
        
        skinnedMeshRenderer.SetBlendShapeWeight(playIndex, 100f);
        playIndex++;
        if (playIndex > blendShapeCount - 1)
        {
            playIndex = 0;
        }
    }
}

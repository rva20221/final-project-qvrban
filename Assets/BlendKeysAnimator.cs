using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlendKeysAnimator : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;

    private Mesh skinnedMesh;

    private int blendShapeCount;

    private int playIndex;

    public bool isLoop;
    // Start is called before the first frame update
    private void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;
    }

    public IEnumerator StartAnimation()
    {
        while (true)
        {
            var diffTwoNegative = playIndex - 2 < 0 ? blendShapeCount - 2 + playIndex : playIndex - 2;
            var diffOneNegative = playIndex - 1 < 0 ? blendShapeCount - 1 + playIndex : playIndex - 1;
            var diffOnePositive = playIndex + 1 >= blendShapeCount ? playIndex + 1 - blendShapeCount : playIndex + 1;
            var diffTwoPositive = playIndex + 2 >= blendShapeCount ? playIndex + 2 - blendShapeCount : playIndex + 2;
        
            skinnedMeshRenderer.SetBlendShapeWeight(diffTwoNegative, 0);
            skinnedMeshRenderer.SetBlendShapeWeight(diffOneNegative, 50f);
            skinnedMeshRenderer.SetBlendShapeWeight(playIndex, 100f);
            skinnedMeshRenderer.SetBlendShapeWeight(diffOnePositive, 50f);
            skinnedMeshRenderer.SetBlendShapeWeight(diffTwoPositive, 0f);

            playIndex++;
            if (playIndex > blendShapeCount - 1)
            {
                if (!isLoop) break;
                playIndex = 0;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}

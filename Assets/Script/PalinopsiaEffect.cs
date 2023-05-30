using UnityEngine;

namespace Assets.Script
{
    public class PalinopsiaEffect : MonoBehaviour
    {
        public float trailDuration = 0.1f;
        public int trailCount = 5;
        public float trailOpacity = 0.5f;

        private SpriteRenderer spriteRenderer;
        private TrailRenderer[] trailRenderers;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Create and configure the trail renderers
            trailRenderers = new TrailRenderer[trailCount];
            for (int i = 0; i < trailCount; i++)
            {
                GameObject trailObject = new GameObject("Trail" + i);
                trailObject.transform.SetParent(transform);
                trailObject.transform.localPosition = Vector3.zero;
                trailRenderers[i] = trailObject.AddComponent<TrailRenderer>();

                // Configure the trail renderer properties
                trailRenderers[i].time = trailDuration;
                trailRenderers[i].startWidth = spriteRenderer.bounds.size.magnitude;
                trailRenderers[i].endWidth = 0f;
                trailRenderers[i].material = spriteRenderer.material;
                trailRenderers[i].material.SetFloat("_Opacity", trailOpacity);
            }
        }

        private void LateUpdate()
        {
            // Update the trail positions and colors
            for (int i = 0; i < trailCount; i++)
            {
                float trailTimeOffset = i * (trailDuration / trailCount);
                trailRenderers[i].time = trailDuration - trailTimeOffset;

                if (i == 0)
                {
                    trailRenderers[i].transform.position = transform.position;
                    trailRenderers[i].startColor = spriteRenderer.color;
                    trailRenderers[i].endColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
                }
                else
                {
                   // trailRenderers[i].transform.position = trailRenderers[i - 1].GetPositionAtTime(trailTimeOffset);
                    trailRenderers[i].startColor = trailRenderers[i - 1].startColor;
                    trailRenderers[i].endColor = trailRenderers[i - 1].endColor;
                }
            }
        }
    }
}

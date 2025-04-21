using UnityEngine;

public class Parallyx : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.07f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}

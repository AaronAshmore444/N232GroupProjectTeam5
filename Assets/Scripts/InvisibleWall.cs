using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    void Start()
    {
        // Ensure the Mesh Renderer is disabled
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

    }
}

using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera myCam;
    [SerializeField] private Vector3 buffer;

    public void SetCameraPosition()
    {
        var (center, size) = CalculateOrthoSize();
        myCam.transform.position = center;
        myCam.orthographicSize = size;
    }

    // Delayed method to give the system more time to process information.
    public IEnumerator SetCameraPositionDelayed()
    {
        yield return new WaitForSeconds(0.2f);
        SetCameraPosition();
    }

    // Method to calculate the orthographic size based on the bounds of the scene objects.
    private (Vector3 center, float size) CalculateOrthoSize()
    {
        Bounds bounds = new Bounds();
        foreach (var col in FindObjectsOfType<Collider>())
        {
            bounds.Encapsulate(col.bounds);
        }

        bounds.Expand(buffer);
        var vertical = bounds.size.y;
        var horizontal = bounds.size.x * myCam.pixelHeight / myCam.pixelWidth;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0, 0, -10);
        return (center, size);
    }
}
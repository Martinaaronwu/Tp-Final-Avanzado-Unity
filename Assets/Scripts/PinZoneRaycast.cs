using UnityEngine;

public class PinZoneRaycast : MonoBehaviour
{
    public float rayDistance = 0.6f;
    public LayerMask floorLayer;

    private bool counted = false;

    void Update()
    {
        if (counted) return;

        Vector3 origin = transform.position + Vector3.up * 0.4f;

        Vector3[] directions =
        {
            transform.forward,
            -transform.forward,
            transform.right,
            -transform.right
        };

        foreach (Vector3 dir in directions)
        {
            if (Physics.Raycast(origin, dir, rayDistance, floorLayer))
            {
                counted = true;
                GameManager.Instance.AddPoint();
                break;
            }
        }
    }
}

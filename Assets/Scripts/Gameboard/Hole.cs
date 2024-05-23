using UnityEngine;

public class Hole : MonoBehaviour
{
    private bool _isEmpty = true;

    public bool IsEmpty { get => _isEmpty; }

    public void StartRay()
    {
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), -transform.up);
        if (Physics.Raycast(ray)) _isEmpty = false;
        else _isEmpty = true;
    }
}

using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] verts;
    [SerializeField] private float heightOffset;

    public Vector3 GetPointOnSpline(float inputT)
    {
        int index = (int)inputT;
        float t = inputT - index;
        if (inputT > verts.Length-1)
        {
            return verts[^1].position;
        }
        return Vector3.Lerp(verts[index].position, verts[index + 1].position, t) + (Vector3.up * heightOffset);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < verts.Length-1; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(verts[i].position + (Vector3.up * heightOffset), verts[i + 1].position + (Vector3.up * heightOffset));
        }
    }
}

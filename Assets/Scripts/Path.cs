using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Vector3[] verts;

    public Vector3 GetPointOnSpline(float inputT)
    {
        int index = (int)inputT;
        float t = inputT - index;
        if (inputT > verts.Length-1)
        {
            return verts[^1];
        }
        return Vector3.Lerp(verts[index], verts[index + 1], t);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < verts.Length-1; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(verts[i], verts[i + 1]);
        }
    }
}

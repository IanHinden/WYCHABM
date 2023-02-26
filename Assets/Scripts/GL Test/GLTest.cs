using UnityEngine;

public class GLTest : MonoBehaviour
{
    float width = 2;
    float height = .3f;
    float startPos = 0;
    private void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            startPos += .3f;
            CreateRectangle(startPos, i);
        }
    }

    private void CreateRectangle(float startPos, int chance)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(-width, -height);
        vertices[1] = new Vector3(-width, height);
        vertices[2] = new Vector3(width, height);
        vertices[3] = new Vector3(width, -height);

        mesh.vertices = vertices;

        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        GameObject go = new GameObject();
        MeshFilter goMesh = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer goRend = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        goMesh.mesh = mesh;

        if(chance % 2 == 0)
        {
            goRend.material.color = Color.red;
        } else
        {
            goRend.material.color = Color.white;
        }

        go.transform.position = new Vector3(0, startPos, 0);
    }
}
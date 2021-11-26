using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownhillGenerator : MonoBehaviour
{
    // Generate an x by y mesh sheet
    [SerializeField] int x;
    [SerializeField] int y;

    Mesh mesh;
    Vector3[] verticies;
    int[] triangles;

    void Start()
    {
        // Create new mesh and add it to mesh filter and collider
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Generate the verticies and triangles lists
        // Generate verticies
        verticies = new Vector3[(x + 1) * (y + 1)];
        int pos = 0;
        for (int i = 0; i <= y; i++)
        {
            for (int j = 0; j <= x; j++)
            {
                verticies[pos] = new Vector3(j, Random.Range(0f, .15f), i);
                pos += 1;
            }
        }

        // Generate triangles
        triangles = new int[x * y * 2 * 6];
        pos = 0;
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                // Add the two triangles for this square at this position

                // First tri
                triangles[pos] = j + (x + 1) * i;
                triangles[pos + 1] = j + (x + 1) * (i + 1);
                triangles[pos + 2] = (j + 1) + (x + 1) * i;

                // Second tri
                triangles[pos + 3] = j + (x + 1) * (i + 1);
                triangles[pos + 4] = (j + 1) + (x + 1) * (i + 1);
                triangles[pos + 5] = (j + 1) + (x + 1) * i;

                pos += 6;
            }
        }

        // Add verticies and triangles to mesh
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshCollider>().sharedMesh = mesh;

        /* This is useful if you want to get rid of the bumpiness of the plane and just use a rectangular hitbox */
        //// Generate collider mesh. Just a plane.
        //Mesh colliderMesh = new Mesh();
        //Vector3[] colliderVerticies = new Vector3[] {
        //    new Vector3(0,0,0), new Vector3(x+1,0,0), new Vector3(0,0,y+1), new Vector3(x+1,0,y+1)
        //};

        //int[] colliderTriangles = new int[]{
        //    0,2,1,2,3,1
        //};

        //colliderMesh.Clear();
        //colliderMesh.vertices = colliderVerticies;
        //colliderMesh.triangles = colliderTriangles;
        //colliderMesh.RecalculateNormals();
        //GetComponent<MeshCollider>().sharedMesh = colliderMesh;
    }
}

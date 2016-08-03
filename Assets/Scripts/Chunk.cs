using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Chunk : MonoBehaviour
{
    bool isInitialized = false;
    public ChunkData data;

    MeshFilter _meshFilter;
    public MeshFilter meshFilter
    {
        get
        {
            if (_meshFilter == null)
            {
                _meshFilter = gameObject.GetComponent<MeshFilter>();
            }
            return _meshFilter;
        }
    }

    MeshRenderer _meshRenderer;
    public MeshRenderer meshRenderer
    {
        get
        {
            if (_meshRenderer == null)
            {
                _meshRenderer = gameObject.GetComponent<MeshRenderer>();
            }
            return _meshRenderer;
        }
    }

    World _world;
    public World world { get { return _world; } }

    public float size { get { return data.size * world.blockSize; } }
    public float height { get { return data.height * world.blockSize; } }

    public void Initialize(World world)
    {
        _world = world;

        Mesh mesh = new Mesh();
        mesh.MarkDynamic();

        for (int y = 0; y < data.height; y++)
        {
            for (int z = 0; z < data.size; z++)
            {
                for (int x = 0; x < data.size; x++)
                {
                }
            }
        }

        isInitialized = true;
    }

    public Vector3 GetLocalBlockPosition(int x, int y, int z)
    {
        return transform.position + new Vector3(x, y, z) - (new Vector3(size, height, size) - new Vector3(world.blockSize, world.blockSize, world.blockSize)) / 2;
    }

    public bool ShouldDrawBlock(int x, int y, int z)
    {
        if (data.GetBlock(x, y, z) == "air") return false;

        string[] blockNeighbors = data.GetBlockNeighbors(x, y, z);
        for (int i = 0; i < blockNeighbors.Length; i++)
        {
            if (blockNeighbors[i] == "air") return true;
        }

        return false;
    }

    void OnDrawGizmos()
    {
        if (isInitialized == false) return;

        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireCube(transform.position, new Vector3(data.size, data.height, data.size));

        for (int y = 0; y < data.height; y++)
        {
            for (int z = 0; z < data.size; z++)
            {
                for (int x = 0; x < data.size; x++)
                {
                    if (ShouldDrawBlock(x, y, z) == false) continue;

                    Gizmos.color = new Color(1, 1, 1);
                    Gizmos.DrawWireCube(GetLocalBlockPosition(x, y, z), Vector3.one * 0.9f);
                }
            }
        }
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Chunk : MonoBehaviour
{
	bool isInitialized = false;
	public ChunkData data;
	MeshFilter _meshFilter;

	public MeshFilter meshFilter {
		get {
			if (_meshFilter == null) {
				_meshFilter = gameObject.GetComponent<MeshFilter> ();
			}
			return _meshFilter;
		}
	}

	MeshRenderer _meshRenderer;

	public MeshRenderer meshRenderer {
		get {
			if (_meshRenderer == null) {
				_meshRenderer = gameObject.GetComponent<MeshRenderer> ();
			}
			return _meshRenderer;
		}
	}

	public void Initialize ()
	{
		Mesh mesh = new Mesh();
		mesh.MarkDynamic();

		for (int y = 0; y < data.height; y++) {
			for (int z = 0; z < data.size; z++) {
				for (int x = 0; x < data.size; x++) {
				}
			}
		}

		isInitialized = true;
	}
}

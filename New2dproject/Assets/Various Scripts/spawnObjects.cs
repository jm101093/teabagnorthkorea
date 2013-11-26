using UnityEngine;
using System.Collections;

public class spawnObjects : MonoBehaviour {
	
	public GameObject spawnObject;
	public float spawnAreaWidth;
	public float spawnAreaHeight;
	public int numberOfEnemiesX;
	public int numberOfEnemiesY;
	
	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < numberOfEnemiesX; i++)
		{
			for(int j = 0; j < numberOfEnemiesY; j++)
			{
				Vector3 SpawnPosition = transform.position;
				SpawnPosition.x += i * (spawnAreaWidth/numberOfEnemiesX);
				SpawnPosition.y += j * (spawnAreaHeight/numberOfEnemiesY);
				Instantiate(spawnObject,SpawnPosition,spawnObject.transform.rotation);
			}
		}
	}
	
	void OnDrawGizmos() 
	{		
		for(int i = 0; i < numberOfEnemiesX; i++)
		{
			for(int j = 0; j < numberOfEnemiesY; j++)
			{
				Vector3 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numberOfEnemiesX);
				spawnPosition.y += j * (spawnAreaHeight/numberOfEnemiesY);
				Gizmos.DrawLine(spawnPosition + Vector3.left,spawnPosition + Vector3.right);
				Gizmos.DrawLine(spawnPosition + Vector3.up,spawnPosition + Vector3.down);
				Gizmos.DrawLine(spawnPosition + Vector3.forward,spawnPosition + Vector3.back);
			}
		}
	}
}

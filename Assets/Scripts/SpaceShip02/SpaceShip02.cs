using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip02 : MonoBehaviour
{
	public int NumOfShip = 1000 ;
	[SerializeField] private GameObject[] _prefabShips = null ;

	private int _cnt; 
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine("SpawnSpaceShip02Co");
	}

	IEnumerator SpawnSpaceShip02Co()
	{
		float t; 
		for (int i = 0; i < NumOfShip; i++)
		{
			GameObject go = Instantiate(_prefabShips[Random.Range(0,_prefabShips.Length)]);
			t = Random.Range(0f, SpaceShip.TimeDecrease ); 
			go.GetComponent<SpaceShip02Controller>().Init(t, SpaceShip.DistInitial ) ;
			_cnt = i;
			//if(Random.Range(0,5) == 0)  yield return null ;
		}

		yield return null ;
//		Debug.Break();
	}

// ちょっと重い
//	void OnGUI()
//	{
//		GUI.Label(new Rect(10, 10, 100, 20), string.Format("{0}" , _cnt));
//	}	
}

using System.Collections;
using System.Collections.Generic;
using Unity.Entities.Editor;
using UnityEngine;

public class SpaceShip01Controller : MonoBehaviour
{
	// >>>> const section >>>> 
	public static float DistInitial = 50.0f; 	// 最初の距離
	public static float TimeDecrease = 3.0f; 	// 何秒で距離を縮めてくるか
	
	// <<<< const section <<<< 
	
	[SerializeField]
	private float _speed = TimeDecrease ; 				// 1周を何秒で回るか
	private float _timeLocal = 0f ; 					//  現在の時間  
	private float _dist = 0f ; 					//  現在の距離  
	private float _loopTime = 0f ; 				//  現在の距離  
	private float _timeNext = 0f ; 				//  距離を縮める時間

	// Use this for initialization
	void Start ()
	{
	}

	/// <summary>
	/// Instanciate後に呼ぶ
	/// </summary>
	/// <param name="t"></param>
	/// <param name="dist"></param>
	public void Init(float t, float dist)
	{
		_timeLocal = t;
		_dist = dist;
		_loopTime = _speed  ;
		_timeNext = Time.time + TimeDecrease ;
		
		SetShipTrans();
		
		transform.position = transform.position.With( y : Random.Range(0f,20f));
	}
	
	void FixedUpdate()
	{
		SetShipTrans();

		
		//近づく

//		if (Time.time > _timeNext)
//		{
//			_dist = _dist - 0.1f ;
//			_loopTime = _speed  ;
//
//			// 自爆
//			if (_dist <= 0.5f)
//			{
//				Destroy(gameObject);
//			}
//		}


		_timeLocal += Time.deltaTime;
	}
	
	/// <summary>
	/// 船の座標セット
	/// </summary>
	/// <param name="t"></param>
	/// <param name="dist"></param>
	void SetShipTrans()
	{
//		Debug.LogFormat("{0:F3} {1:F3} ",_timeLocal, _loopTime);
		float t = (_timeLocal % _loopTime) / _loopTime;
		Vector2 v2 = new Vector2(Mathf.Sin((t) * Mathf.PI * 2) , Mathf.Cos((t) * Mathf.PI * 2) ) ;  

//		Debug.Log(v2);

		float rad = Mathf.Atan2(v2.x, v2.y);
				
		transform.position = transform.position.With( x : v2.x * _dist , z : v2.y * _dist) ;
		transform.rotation = transform.rotation.WithEuler( y: rad * Mathf.Rad2Deg + 90f ) ;
	}	

}

using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.Burst;
using Unity.Entities;
using Unity.Entities.Editor;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class SpaceShip02Controller : MonoBehaviour
{
	// >>>> const section >>>> 
	public static float DistInitial = 50.0f; // 最初の距離
	public static float TimeDecrease = 3.0f; // 何秒で距離を縮めてくるか

	// <<<< const section <<<< 

	[SerializeField] private float _speed = TimeDecrease; // 1周を何秒で回るか
	public float TimeOffset = 0f; //  現在の時間  
	public float Dist = 0f; //  現在の距離
	public float LoopTime = 0f; //  現在の距離  
	
	private float _timeNext = 0f; //  距離を縮める時間

	// Use this for initialization
	void Start()
	{
	}

	/// <summary>
	/// Instanciate後に呼ぶ
	/// </summary>
	/// <param name="t"></param>
	/// <param name="dist"></param>
	public void Init(float t, float dist)
	{
		TimeOffset = t;
		Dist = dist;
		LoopTime = _speed;
		
		_timeNext = Time.time + TimeDecrease;

		transform.position = transform.position.With(y: Random.Range(0f, 20f));
		//Debug.LogFormat("Init:{0} {1}" , TimeOffset, Dist); 
	}

/*
	void FixedUpdate()
	{
		SetShipTrans();

		
		//近づく

//		if (Time.time > _timeNext)
//		{
//			dist = dist - 0.1f ;
//			loopTime = _speed  ;
//
//			// 自爆
//			if (dist <= 0.5f)
//			{
//				Destroy(gameObject);
//			}
//		}


		timeLocal += Time.deltaTime;
	}
*/
}

[BurstCompile]
class SpaceShipMoveSystem : JobComponentSystem
{
	private struct Group
	{
		public readonly int Length;
		public ComponentArray<SpaceShip02Controller> ArySS02;
		public TransformAccessArray transformArray; // Transformを収集してくれる
	}
	
	[Inject] Group group;
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var job = new Job
		{
			TimeLocal = Time.time, 
			ArySS02 = group.ArySS02
		};
		return job.Schedule(group.transformArray, base.OnUpdate(inputDeps));
	} 

	/// <summary>
	/// 並列処理 Job
	/// </summary>
	struct Job : IJobParallelForTransform
	{
		public float TimeLocal ; 
		public ComponentArray<SpaceShip02Controller> ArySS02;
		
		public void Execute(int index, TransformAccess transform)
		{
			float dist = ArySS02[index].Dist ;			//  現在の距離  
			float loopTime = ArySS02[index].LoopTime ; //  現在の距離

			TimeLocal += ArySS02[index].TimeOffset; 
			
			// ArySS02[index]; // コンポーネントのデータをアクセス必要な場合
			float t = (TimeLocal % loopTime) / loopTime;

			Vector2 v2 = new Vector2(Mathf.Sin((t) * Mathf.PI * 2) , Mathf.Cos((t) * Mathf.PI * 2) ) ;  
			
			float rad = Mathf.Atan2(v2.x, v2.y);
			Vector3 rot = transform.rotation.eulerAngles;
			
			transform.position = new Vector3(v2.x * dist , transform.position.y, v2.y * dist) ;
			transform.rotation = Quaternion.Euler( rot.x, rad * Mathf.Rad2Deg + 90f, rot.z ) ;
			
			//Debug.LogFormat("Execute:{0} {1} {2} {3}",t, dist, v2, transform.position);
		}
	}	
}

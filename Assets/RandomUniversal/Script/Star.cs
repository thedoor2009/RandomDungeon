using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	#region Data Memeber
	public Transform plane;

	private int m_numOfPlanes;

	public int NumOfPlanes{
		get{
			return m_numOfPlanes;
		}
	}
	#endregion

	#region Mono Function
	private void Awake(){
		Init();
	}

	private void Start () {

	}

	private void Update () {
	
	}
	#endregion

	#region Function
	private void Init(){
		SetNumberOfPlanes();
		GeneratePlanes();
	}

	private void GeneratePlanes(){
		long x = (long)this.transform.position.x;
		long y = (long)this.transform.position.y;
		long z = (long)this.transform.position.z;
		Random.seed = (int)SeedProduce.Instance.Randomizer(x, y, x * z + x, 1000L);

		for( int i = 0; i < m_numOfPlanes; i++ ){
			Vector3 position = transform.position + new Vector3( 0.0f, 0.0f, Random.value * 30.0f);
			Transform p = GameObject.Instantiate( plane, position , Quaternion.identity ) as Transform;
			p.parent = transform;
		}
	}
	private void SetNumberOfPlanes(){
		long x = (long)this.transform.position.x;
		long y = (long)this.transform.position.y;
		long z = (long)this.transform.position.z;

		Random.seed = (int)SeedProduce.Instance.Randomizer(x, y, x * z + x, 1000L);
		this.m_numOfPlanes = (int)(Random.value * 20.0f);
	}
	#endregion
}

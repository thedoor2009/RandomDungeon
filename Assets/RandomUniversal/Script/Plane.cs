using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

	#region Data Memeber
	public Transform Center;

	private float m_degreePerSecond;
	private Vector3 m_distance;
	#endregion

	#region Mono Function
	private void Start () {
		long x = (long)this.transform.position.x;
		long y = (long)this.transform.position.y;
		long z = (long)this.transform.position.z;
		
		Random.seed = (int)SeedProduce.Instance.Randomizer(x, y, x * z + x, 1000L);
		m_degreePerSecond = (int)(Random.value * 50.0f);

		Center = transform.parent;
		m_distance = transform.position - Center.position;

	}
	

	private void Update () {
		m_distance = Quaternion.AngleAxis( m_degreePerSecond * Time.deltaTime, Vector3.up ) * m_distance;
		transform.position = Center.position + m_distance;
	}
	#endregion
}

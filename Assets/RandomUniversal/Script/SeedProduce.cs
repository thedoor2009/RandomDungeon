using UnityEngine;
using System.Collections;

public class SeedProduce:MonoBehaviour{

	private static SeedProduce m_instance;

	private long 		ulGen1;
	private long 		ulGen2;
	private long 		ulSeed;
	private long 		ulMax;

	public static SeedProduce Instance{
		get{
			if( m_instance == null ){
				m_instance = GameObject.FindObjectOfType<SeedProduce>();
				DontDestroyOnLoad(m_instance.gameObject);
			}
			return m_instance;
		}
	}

	private void Awake(){
		Init();
	}

	public long Randomizer(long Gen1, long Gen2, long Seed, long Max){

		this.ulGen1 = Gen1;
		this.ulGen2 = Gen2;
		this.ulSeed = Seed;
		this.ulMax = Max;

		long ulNewSeed;

		ulNewSeed = (this.ulGen1 * this.ulSeed ) + this.ulGen2;

		ulNewSeed = ulNewSeed % this.ulMax;

		this.ulSeed = ulNewSeed;
		return this.ulSeed;
	}

	private void Init(){
		if( m_instance == null ){
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else{
			Destroy(this.gameObject);
		}
	}
}	

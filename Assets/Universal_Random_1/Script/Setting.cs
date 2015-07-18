using UnityEngine;
using System.Collections;

public class Setting:MonoBehaviour {

	private static Setting m_instance;
	
	private long  		m_maxXBorder = 5;
	private long  		m_maxYBorder = 5;
	private long  		m_maxZBorder = 5;
	private int 		m_rootRand = -749280;
	private int 		m_maxProbability = 60;

	public static Setting Instance {
		get{
			if( m_instance == null ){
				m_instance = GameObject.FindObjectOfType<Setting>();
				DontDestroyOnLoad(m_instance.gameObject);
			}
			return m_instance;
		}
	}


	public long MAXIMUM_X_BORDER{
		get{ return m_maxXBorder;}
	}

	public long MAXIMUM_Y_BORDER{
		get{ return m_maxYBorder;}
	}

	public long MAXIMUM_Z_BORDER{
		get{ return m_maxZBorder;}
	}

	public int ROOT_RANDOM{
		get{ return m_rootRand;}
	}

	public int MAXIMUM_PROBABILITY{
		get{ return m_maxProbability;}
	}

	private void Init(){
		if( m_instance == null ){
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else{
			Destroy(this.gameObject);
		}
		m_maxProbability 		= 		60;
		m_maxXBorder 			= 		5;
		m_maxYBorder 			= 		5;
		m_maxZBorder 			= 		5;
		m_rootRand 				= 		-749280;
	}

	private void Awake(){
		Init();
	}

	private void Start(){
	
	}

	private void Update(){
	
	}
}

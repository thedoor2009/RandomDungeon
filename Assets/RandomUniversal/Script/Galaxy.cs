using UnityEngine;
using System.Collections;

public class Galaxy : MonoBehaviour {

	#region Data Memeber 
	public GameObject Star;

	private bool [,,]StarIsExisted;

	private void Awake(){

	}
	#endregion

	#region Mono Function
	private void Start () {
		Init();
	}

	private void Update () {

	}
	#endregion

	#region Function
	private void Init(){
		InitStarArray();

		for( int x = 1; x < Setting.Instance.MAXIMUM_X_BORDER; x++ ){
			for( int y = 1; y < Setting.Instance.MAXIMUM_Y_BORDER; y++ ){
				for( int z = 1; z < Setting.Instance.MAXIMUM_Z_BORDER; z++ ){
					if( StarIsExisted[x,y,z]){
						GameObject star = GameObject.Instantiate( Star, new Vector3( (int)(Random.value * 1000.0f) * x, (int)(Random.value * 1000.0f) * y, (int)(Random.value * 1000.0f) * z), Quaternion.identity) as GameObject;

						int scaleTime = (int)(Random.value * 100.0f);
						star.transform.localScale = new Vector3( scaleTime, scaleTime, scaleTime);
						star.transform.parent = transform;
					}
				}
			}
		}
	}

	private void InitStarArray(){
		StarIsExisted = new bool[Setting.Instance.MAXIMUM_X_BORDER,Setting.Instance.MAXIMUM_Y_BORDER,Setting.Instance.MAXIMUM_Z_BORDER];

		int probability = 0;
		
		Random.seed = Setting.Instance.ROOT_RANDOM;
		for( int x = 0; x < Setting.Instance.MAXIMUM_X_BORDER; x++ ){
			for( int y = 0; y < Setting.Instance.MAXIMUM_Y_BORDER; y++ ){
				for( int z = 0; z < Setting.Instance.MAXIMUM_Z_BORDER; z++ ){
					probability = (int)(Random.value * 100.0f);
					probability -= Setting.Instance.MAXIMUM_PROBABILITY;

					StarIsExisted[x,y,z] = probability < 0 ? true : false;
				}
			}
		}
	}

	private bool StarAtPositionProbability( long randRoot, int X, int Y, int Z ){
		if( X > Setting.Instance.MAXIMUM_X_BORDER ){
			Debug.LogError( "X is out of the border.");
			return false;
		}

		if( Y > Setting.Instance.MAXIMUM_Z_BORDER ){
			Debug.LogError( "Y is out of the border.");
			return false;
		}

		if( Z > Setting.Instance.MAXIMUM_Z_BORDER ){
			Debug.LogError( "Z is out of the border.");
			return false;
		}

		int probability = 0;

		Random.seed = (int)randRoot;
		for( int x = 0; x <= X; x++ ){
			for( int y = 0; y < Y; y++){
				for( int z = 0; z < Z; z++ ){
					probability = (int)(Random.value * 100.0f);
				}
			}
		}

		probability = probability - Setting.Instance.MAXIMUM_PROBABILITY;

		return probability < 0;
	}

	#endregion
}

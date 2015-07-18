using UnityEngine;
using System.Collections;

public class CommandFactory : MonoBehaviour {

	#region Data Member
	private static CommandFactory m_instance;

	public static CommandFactory Instance {
		get{
			if( m_instance == null ){
				m_instance = GameObject.FindObjectOfType<CommandFactory>();
				DontDestroyOnLoad(m_instance.gameObject);
			}
			return m_instance;
		}
	}
	#endregion

	#region Mono Function
	private void Awake(){
		Init ();
	}
	#endregion

	#region Function
	private void Init(){
		if( m_instance == null ){
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else{
			Destroy(this.gameObject);
		}
	}

	public Command CreateCommand( string i_commandName, ActionParameter i_actionParameter ){
		switch( i_commandName ){
		case "AudioTriggerCommand":
		{
			return new AudioTriggerCommand( i_actionParameter);
			break;
		}
		default:
			return null;
			break;
		}
	}
	#endregion
}

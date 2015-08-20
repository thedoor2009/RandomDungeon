using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerHandler : MonoBehaviour {

	#region Data Memeber
	public List<string> commandNames;
	private List<Command> commands = new List<Command>();
	private bool isTrigger;
	#endregion

	#region Hook
	private void Start () {
		isTrigger = false;
	}

	private void Update () {
		TriggerUpdate();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.transform.tag == "Player" && !isTrigger){
			ActionParameter actionParameter = new ActionParameter();
			actionParameter.actionParameterData.source = this.gameObject;
			actionParameter.actionParameterData.target = other.gameObject;
	
			foreach( string commandName in commandNames){
				Command command = CommandFactory.Instance.CreateCommand( commandName, actionParameter);
				commands.Add(command);
			}
			isTrigger = true;
		}
	}
	#endregion
	
	#region Trigger Update
	private void TriggerUpdate(){
		if(isTrigger){
			foreach( Command command in commands){
				if( command.isFinished){
					commands.Remove( command);
					continue;
				}
				command.excute();
			}
			if(commands.Count == 0 ){
			isTrigger = false;
			}
		}
	}
	#endregion
}

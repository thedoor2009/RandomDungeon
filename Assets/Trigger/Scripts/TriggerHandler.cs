using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerHandler : MonoBehaviour {

	#region Data Memeber
	public List<string> commandNames;
	private List<Command> commands;
	private bool isTrigger;
	#endregion

	#region Mono Function
	private void Start () {
		isTrigger = false;
	}

	private void Update () {
		if(isTrigger){
			foreach( Command command in commands){
				if( command.isFinished){
					commands.Remove( command);
					continue;
				}
				command.excute();
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		ActionParameter actionParameter = new ActionParameter();
		actionParameter.actionParameterData.source = this.gameObject;
		actionParameter.actionParameterData.target = other.gameObject;

		foreach( string commandName in commandNames){
			Command command = CommandFactory.Instance.CreateCommand( commandName, actionParameter);
			commands.Add(command);
		}

		isTrigger = true;
	}
	#endregion
}

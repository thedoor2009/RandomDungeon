using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerHandler : MonoBehaviour {

	public List<Command> commands;
	private bool isTrigger;

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

		foreach( Command command in commands){
			command.actionParamter = actionParameter;
		}

		isTrigger = true;
	}
}

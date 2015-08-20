using UnityEngine;
using System.Collections;

public class AudioTriggerCommand : Command {
	public AudioTriggerCommand(ActionParameter i_actionParamter):base(i_actionParamter){

	}
	
	public override void excute(){
		m_actionParameter.actionParameterData.target.transform.position += new Vector3(0.1f,0.01f,0.1f);
	}
}

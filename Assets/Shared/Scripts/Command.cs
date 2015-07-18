/********************************************/
//Author:Jinghui Dong
//Date: 07/18/2015
//Description: Base class for command
/********************************************/

using UnityEngine;
using System.Collections;

public class Command:MonoBehaviour
{
	#region Data Member
	
	private ActionParameter 	m_actionParameter 	= 	null;
	public ActionParameter  	actionParamter 			{get { return m_actionParameter;} set { m_actionParameter = value;}}
	public bool					isFinished			=	false;
	#endregion
	
	#region Constructor & Destructor
	
	public Command(ActionParameter i_actionParamter){
		init (i_actionParamter);
	}
	
	~Command(){
		uninit ();
	}
	
	#endregion
	
	#region Public Function
	
	public virtual void excute(){}
	
	public virtual void init(ActionParameter i_actionParamter){
		actionParamter = i_actionParamter;
	}
	
	public virtual void uninit(){
		actionParamter.uninit();
	}
	
	#endregion
}
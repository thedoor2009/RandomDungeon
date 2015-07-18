/********************************************/
//Author:Jinghui Dong
//Date: 07/18/2015
//Description: Base class for command
/********************************************/

using UnityEngine;
using System.Collections;

public class Command 
{
	#region Data Member

	public Command(){
		init ();
	}

	~Command(){
		uninit ();
	}

	#endregion

	#region Public Function

	public virtual void excute(){}

	public virtual void init(){}

	public virtual void uninit(){}

	#endregion
}

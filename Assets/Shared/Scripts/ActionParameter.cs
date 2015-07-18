/********************************************/
//Author:Jinghui Dong
//Date: 07/18/2015
//Description: Data Strcture for command parameters
/********************************************/
using UnityEngine;
using System.Collections;

public class ActionParameter:MonoBehaviour
{
	public struct Data
	{	
		public GameObject source;
		public GameObject target;
	}
	public Data actionParameterData;
	
	public void uninit(){
		actionParameterData.source = null;
		actionParameterData.target = null;
	}
}
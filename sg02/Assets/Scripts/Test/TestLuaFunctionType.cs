using UnityEngine;
using System.Collections;

using LuaInterface;

public class TestLuaFunctionType 
{
    public LuaFunction testDelegate;

    private GameObject testObj;

	public void LuaFunctionType(string methodName, GameObject args)
    {
        //Debug.Log("LuaFunctionType" + obj.GetType().Name);
        //GameObject.Find("TestLua").GetComponent<TestLua>().CallFunction(methodName, args);

        testObj = args;
    }

    public TestLuaFunctionType(GameObject testObj)
    {
        this.testObj = testObj;
    }

    public void CallDelegate()
    {
        if (testDelegate != null)
        {
            object[] rets = testDelegate.Call(testObj);
            Debug.Log(rets[0]);
        }
    }

    public void CallDelegate(LuaFunction func)
    {
        object[] rets = func.Call(testObj);
        if (rets != null && rets.Length > 0)
            Debug.Log(rets[0]);
    }
}

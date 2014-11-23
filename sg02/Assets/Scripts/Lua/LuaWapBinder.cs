using System;
public static class LuaWapBinder
{
	public static void Bind(IntPtr L)
	{
		StateManagerWrap.Register(L);
		UIManagerWrap.Register(L);
		GamePublicWrap.Register(L);
		GameStatesManagerWrap.Register(L);
		InputManagerWrap.Register(L);
		TestLuaFunctionTypeWrap.Register(L);
	}
}

module("StartMenuControl", package.seeall);

require("Lua/UI/StartMenu/StartMenuView")

function Initialize(viewPanel)

    --StartMenuView.Initialize(viewPanel)

    local func = function (gameObject)
		print("callback sucess!");
		return true;
	end
    test = TestLuaFunctionType.New(viewPanel)

    test.testDelegate = func
    test:LuaFunctionType("StartMenuView.Initialize", viewPanel)
    test:CallDelegate()

end

function UnInitialize()

    

end
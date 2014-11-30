module(..., package.seeall);

m_view = nil

--初始化函数
function Initialize(viewPanel)

    --Test(viewPanel)
    
    m_view = StartMenuView
    m_view.Initialize(viewPanel)

    InitButtonEvent()

end

--反初始化函数
function UnInitialize()

    UIManager.Instance:DestroyView(UINamesConfig.StartMenu)

end

--初始化按钮事件
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_btnStartGame, OnStartGameButton)
    InputManager.Instance:AddOnClickEvent(m_view.m_btnLoadGame, OnLoadGameButton)
    InputManager.Instance:AddOnClickEvent(m_view.m_btnSetting, OnSettingsButton)
    InputManager.Instance:AddOnClickEvent(m_view.m_btnQuit, OnQuitButton)

end

--开始按钮
function OnStartGameButton(go)

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.SelectTimesState)

end

--加载存档
function OnLoadGameButton(go)

    UnInitialize()
    UIManager.Instance:ShowView(UINamesConfig.LoadgameMenu)

end

--设置
function OnSettingsButton(go)

    print("OnSettingsButton")

end

--退出
function OnQuitButton(go)

    Application.Quit();

end

--测试
function Test(viewPanel)

    local func = function (gameObject)
		print("callback sucess!");
		return true;
	end
    test = TestLuaFunctionType.New(viewPanel)

    test.testDelegate = func
    test:LuaFunctionType("StartMenuView.Initialize", viewPanel)
    test:CallDelegate()

    test:CallDelegate(OnStartGameButton)
    
end
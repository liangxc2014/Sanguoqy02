module("StartMenuControl", package.seeall);

require("Lua/UI/StartMenu/StartMenuView")

m_view = StartMenuView
m_viewPanel = nil

--初始化函数
function Initialize(viewPanel)

    --Test(viewPanel)

    m_viewPanel = viewPanel
    m_view.Initialize(viewPanel)

    InitButtonEvent()

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

--反初始化函数
function UnInitialize()

    

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

    print("OnStartGameButton")
    GamePublic.Instance.GameStatesManager.ChangeState(GamePublic.Instance.GameStatesManager.SelectPeriodState)

end

--加载存档
function OnLoadGameButton(go)

    print("OnLoadGameButton")
    UIManager.Instance.ShowView(UINamesConfig.LoadgameMenu)

end

--设置
function OnSettingsButton(go)

    print("OnSettingsButton")

end

--退出
function OnQuitButton(go)

    print("OnQuitButton")
    Application.Quit();

end
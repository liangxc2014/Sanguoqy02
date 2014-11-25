module("StartMenuControl", package.seeall);

require("Lua/UI/StartMenu/StartMenuView")

m_view = StartMenuView
m_viewPanel = nil

--��ʼ������
function Initialize(viewPanel)

    --Test(viewPanel)

    m_viewPanel = viewPanel
    m_view.Initialize(viewPanel)

    InitButtonEvent()

end

--����
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

--����ʼ������
function UnInitialize()

    

end

--��ʼ����ť�¼�
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_btnStartGame, OnStartGameButton)
    InputManager.Instance:AddOnClickEvent(m_view.m_btnLoadGame, OnLoadGameButton)
    InputManager.Instance:AddOnClickEvent(m_view.m_btnSetting, OnSettingsButton)
    InputManager.Instance:AddOnClickEvent(m_view.m_btnQuit, OnQuitButton)

end

--��ʼ��ť
function OnStartGameButton(go)

    print("OnStartGameButton")
    GamePublic.Instance.GameStatesManager.ChangeState(GamePublic.Instance.GameStatesManager.SelectPeriodState)

end

--���ش浵
function OnLoadGameButton(go)

    print("OnLoadGameButton")
    UIManager.Instance.ShowView(UINamesConfig.LoadgameMenu)

end

--����
function OnSettingsButton(go)

    print("OnSettingsButton")

end

--�˳�
function OnQuitButton(go)

    print("OnQuitButton")
    Application.Quit();

end
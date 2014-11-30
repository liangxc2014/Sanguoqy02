module(..., package.seeall);

m_view = nil

--��ʼ������
function Initialize(viewPanel)

    --Test(viewPanel)
    
    m_view = StartMenuView
    m_view.Initialize(viewPanel)

    InitButtonEvent()

end

--����ʼ������
function UnInitialize()

    UIManager.Instance:DestroyView(UINamesConfig.StartMenu)

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

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.SelectTimesState)

end

--���ش浵
function OnLoadGameButton(go)

    UnInitialize()
    UIManager.Instance:ShowView(UINamesConfig.LoadgameMenu)

end

--����
function OnSettingsButton(go)

    print("OnSettingsButton")

end

--�˳�
function OnQuitButton(go)

    Application.Quit();

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
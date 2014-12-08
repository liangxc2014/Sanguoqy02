module(..., package.seeall);

m_view = nil

--
local m_tableTimes = {}

--��ʼ������
function Initialize(viewPanel)

    m_view = SelectTimesView
    m_view.Initialize(viewPanel)

    InitButtons()

end

--����ʼ������
function UnInitialize()

    m_tableTimes = {}

end

--��ʼ����ť�б�
function InitButtons()

    local timesList = GamePublic.Instance.TimesList
    local count = timesList.Count

    local btnPrefab = ResourcesManager.Instance:Load(UINamesConfig.FontButtonExample)

    for i=0, count - 1 do
        local go = Utility.AddChild(m_view.m_ButtonsRoot, btnPrefab)
        go.name = timesList:get_Item(i)
        go:GetComponent("UIButton"):SetText(go.name)

        go.transform.localPosition = Vector3.New(0, GlobalConfig.FontButtonsVSpace * i)

        m_tableTimes[go] = i
        InputManager.Instance:AddOnClickEvent(go, OnButtonClick)
    end

end

--������Ӧ
function OnButtonClick(go)

    local currentTimes = m_tableTimes[go]
    GamePublic.Instance.CurrentTimes = currentTimes

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.SelectKingState)

end
module(..., package.seeall);

m_view = nil

--
local m_tableTimes = {}

--初始化函数
function Initialize(viewPanel)

    m_view = SelectTimesView
    m_view.Initialize(viewPanel)

    InitButtons()

end

--反初始化函数
function UnInitialize()

    m_tableTimes = {}

end

--初始化按钮列表
function InitButtons()

    local timesList = GamePublic.Instance.TimesList
    local count = timesList.Count

    for i=0, count - 1 do
        local go = Utility.AddChildButton(m_view.m_ButtonsRoot, timesList:get_Item(i))

        go.transform.localPosition = Vector3.New(0, GlobalConfig.FontButtonsVSpace * i)

        m_tableTimes[go] = i
        InputManager.Instance:AddOnClickEvent(go, OnButtonClick)
    end

end

--按键响应
function OnButtonClick(go)

    local currentTimes = m_tableTimes[go]
    GamePublic.Instance.CurrentTimes = currentTimes

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.SelectKingState)

end
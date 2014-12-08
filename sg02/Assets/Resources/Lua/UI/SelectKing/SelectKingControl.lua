module(..., package.seeall);

--界面
m_view = nil 

--数据缓存 
local m_tableKings = {}

--是否有弹出确认框
local m_isShowButtons = false

--初始化函数
function Initialize(viewPanel)

    m_view = SelectKingView
    m_view.Initialize(viewPanel)

    InitButtons()
    InitButtonEvent()

end

--反初始化函数
function UnInitialize()

    m_tableKings = {}

end

--初始化按钮列表
function InitButtons()

    local kingData = XMLManager.Kings.Data
    
    local btnPrefab = ResourcesManager.Instance:Load(UINamesConfig.FontButtonExample)

    local i = 0
    local enumerator = kingData.Keys:GetEnumerator()
    while enumerator:MoveNext() do
        local key = enumerator.Current
        local kingData = GamePublic.Instance.DataManager:GetKingInfo(key)
        if kingData.Active then
            local go = Utility.AddChild(m_view.m_kingListRoot, btnPrefab)
            go.name = kingData.Name
            go:GetComponent("UIButton"):SetText(go.name)

            go.transform.localPosition = Vector3.New(0, GlobalConfig.FontButtonsVSpace * i)
            i = i + 1

            m_tableKings[go] = key
            InputManager.Instance:AddOnClickEvent(go, OnButtonClick)
        end 
    end

end

--初始化按钮事件
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirm, OnButtonOK)
    InputManager.Instance:AddOnClickEvent(m_view.m_buttonCancel, OnButtonCancel)

end

--按键响应
function OnButtonClick(go)

    if m_isShowButtons then 
        return
    end

    local currentKing = m_tableKings[go]
    GamePublic.Instance.CurrentKing = currentKing

    m_view.m_buttonsRoot:SetActive(true)
    m_isShowButtons = true

end

--确定按钮
function OnButtonOK(go)

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.InternalAffairsState)

end

--取消按钮
function OnButtonCancel(go)

    m_view.m_buttonsRoot:SetActive(false)
    m_isShowButtons = false

end
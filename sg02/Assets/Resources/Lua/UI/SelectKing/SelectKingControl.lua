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
    
    local btnPrefab = ResourcesManager.Instance:Load(UINamesConfig.FontButtonExample)

    local first = nil
    local i = 0
    local enumerator = XMLManager.Kings.Data.Keys:GetEnumerator()
    while enumerator:MoveNext() do
        local key = enumerator.Current
        local kingData = GamePublic.Instance.DataManager:GetKingInfo(key)
        if kingData.Active then
            local go = Utility.AddChildToggle(m_view.m_kingListRoot, true, kingData.Name)

            go.transform.localPosition = Vector3.New(0, GlobalConfig.FontButtonsVSpace * i)

            m_tableKings[go] = key
            InputManager.Instance:AddOnToggleEvent(go, OnToggle)

            if i == 0 then
                first = go
                m_isShowButtons = false
                m_view.m_buttonsRoot:SetActive(false)
            end

            i = i + 1
        end 
    end

    first:GetComponent("UIToggle"):Toggle(true)

end

--初始化按钮事件
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirm, OnButtonOK)
    InputManager.Instance:AddOnClickEvent(m_view.m_buttonCancel, OnButtonCancel)

end

--按键响应
function OnToggle(go, state)

    if state then
        m_view.m_buttonsRoot:SetActive(true)
        m_isShowButtons = true

        local currentKing = m_tableKings[go]
        GamePublic.Instance.CurrentKing = currentKing

        local king = GamePublic.Instance.DataManager:GetKingInfo(currentKing)
        local generalID = king.GeneralID
        local general = GamePublic.Instance.DataManager:GetGeneralInfo(generalID)
        general:SetFace(m_view.m_spriteFace)
    end

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
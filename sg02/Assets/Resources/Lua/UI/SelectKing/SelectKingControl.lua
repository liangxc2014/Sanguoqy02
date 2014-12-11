module(..., package.seeall);

--����
m_view = nil 

--���ݻ��� 
local m_tableKings = {}

--�Ƿ��е���ȷ�Ͽ�
local m_isShowButtons = false

--��ʼ������
function Initialize(viewPanel)

    m_view = SelectKingView
    m_view.Initialize(viewPanel)

    InitButtons()
    InitButtonEvent()

end

--����ʼ������
function UnInitialize()

    m_tableKings = {}

end

--��ʼ����ť�б�
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

--��ʼ����ť�¼�
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirm, OnButtonOK)
    InputManager.Instance:AddOnClickEvent(m_view.m_buttonCancel, OnButtonCancel)

end

--������Ӧ
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

--ȷ����ť
function OnButtonOK(go)

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.InternalAffairsState)

end

--ȡ����ť
function OnButtonCancel(go)

    m_view.m_buttonsRoot:SetActive(false)
    m_isShowButtons = false

end
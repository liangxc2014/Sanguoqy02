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

--��ʼ����ť�¼�
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirm, OnButtonOK)
    InputManager.Instance:AddOnClickEvent(m_view.m_buttonCancel, OnButtonCancel)

end

--������Ӧ
function OnButtonClick(go)

    if m_isShowButtons then 
        return
    end

    local currentKing = m_tableKings[go]
    GamePublic.Instance.CurrentKing = currentKing

    m_view.m_buttonsRoot:SetActive(true)
    m_isShowButtons = true

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
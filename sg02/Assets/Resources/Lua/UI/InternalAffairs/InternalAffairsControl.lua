module(..., package.seeall);

m_view = nil
m_menuItem = {}

m_isMenuEnable = true

--��ʼ������
function Initialize(viewPanel)

    m_view = InternalAffairsView
    m_view.Initialize(viewPanel)

    InitMenuList()
    InitButtonEvent()

    SetKingFace()

end

--����ʼ������
function UnInitialize()

    

end

function InitMenuList()

    local i = 0
    local enumerator = XMLManager.MenuItem.Data.Values:GetEnumerator()
    while enumerator:MoveNext() do
        local menuItemInfo = enumerator.Current
        if menuItemInfo.Type == Define.MenuItemType.InternalAffairs then
            local name = menuItemInfo.Name
            local go = Utility.AddChildButton(m_view.m_menuListRoot, name)

            go.transform.localPosition = Vector3.New(0, GlobalConfig.FontButtonsVSpace * i)

            m_menuItem[go] = menuItemInfo.ID
            InputManager.Instance:AddOnClickEvent(go, OnMenuItemClick)

            i = i + 1
        end
        
    end

end

--��ʼ����ť�¼�
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirmOK, OnButtonOK)
    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirmCancel, OnButtonCancel)

end

--ȷ����������
function OnButtonOK()

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.WorldMapState)

end

--ȡ��
function OnButtonCancel()

    m_isMenuEnable = true
    m_view.m_confirmBox:SetActive(false)

end

--���þ���ͷ��
function SetKingFace()

    local king = GamePublic.Instance.DataManager:GetKingInfo(GamePublic.Instance.CurrentKing)
    local general = GamePublic.Instance.DataManager:GetGeneralInfo(king.GeneralID)
    general:SetFace(m_view.m_imageFace)

end

--�˵���ѡ����Ӧ
function OnMenuItemClick(go)

    if not m_isMenuEnable then
        return
    end
    
    local ID = m_menuItem[go]
    if ID == 10 then 
        m_isMenuEnable = false
        m_view.m_confirmBox:SetActive(true)
    end
    
end
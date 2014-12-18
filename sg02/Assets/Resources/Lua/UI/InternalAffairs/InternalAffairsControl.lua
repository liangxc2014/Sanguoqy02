module(..., package.seeall);

m_view = nil
m_menuItem = {}

m_isMenuEnable = true

--初始化函数
function Initialize(viewPanel)

    m_view = InternalAffairsView
    m_view.Initialize(viewPanel)

    InitMenuList()
    InitButtonEvent()

    SetKingFace()

end

--反初始化函数
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

--初始化按钮事件
function InitButtonEvent()

    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirmOK, OnButtonOK)
    InputManager.Instance:AddOnClickEvent(m_view.m_buttonConfirmCancel, OnButtonCancel)

end

--确认内政终了
function OnButtonOK()

    GamePublic.Instance.GameStatesManager:ChangeState(GamePublic.Instance.GameStatesManager.WorldMapState)

end

--取消
function OnButtonCancel()

    m_isMenuEnable = true
    m_view.m_confirmBox:SetActive(false)

end

--设置君主头像
function SetKingFace()

    local king = GamePublic.Instance.DataManager:GetKingInfo(GamePublic.Instance.CurrentKing)
    local general = GamePublic.Instance.DataManager:GetGeneralInfo(king.GeneralID)
    general:SetFace(m_view.m_imageFace)

end

--菜单项选择响应
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
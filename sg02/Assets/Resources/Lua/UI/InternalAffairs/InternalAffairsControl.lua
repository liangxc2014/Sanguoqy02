module(..., package.seeall);

m_view = nil
m_menuItem = {}

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
            InputManager.Instance:AddOnClickEvent(go, OnButtonClick)

            i = i + 1
        end
        
    end

end

--初始化按钮事件
function InitButtonEvent()

    

end

--设置君主头像
function SetKingFace()

    local king = GamePublic.Instance.DataManager:GetKingInfo(GamePublic.Instance.CurrentKing)
    local general = GamePublic.Instance.DataManager:GetGeneralInfo(king.GeneralID)
    general:SetFace(m_view.m_imageFace)

end

--菜单项选择响应
function OnButtonClick(go)

    print(go.name)

end
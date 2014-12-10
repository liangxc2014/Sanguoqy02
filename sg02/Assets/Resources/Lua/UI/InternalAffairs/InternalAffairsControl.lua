module(..., package.seeall);


--初始化函数
function Initialize(viewPanel)

    local i = 0
    local enumerator = XMLManager.MenuItem.Data.Values:GetEnumerator()
    while enumerator:MoveNext() do
        local menuItemInfo = enumerator.Current
        if menuItemInfo.Type == MenuItemType.InternalAffairs then
            print("It is the same")
            
        end
        print(MenuItemType.InternalAffairs)
    end

end

--反初始化函数
function UnInitialize()

    

end

--初始化按钮事件
function InitButtonEvent()

    

end
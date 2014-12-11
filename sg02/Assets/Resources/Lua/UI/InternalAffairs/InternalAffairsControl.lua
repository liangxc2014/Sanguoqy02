module(..., package.seeall);


--初始化函数
function Initialize(viewPanel)

    local i = 0
    local enumerator = XMLManager.MenuItem.Data.Values:GetEnumerator()
    while enumerator:MoveNext() do
        local menuItemInfo = enumerator.Current
        if menuItemInfo.Type == MenuItemType.InternalAffairs then
            
            
        end
        
    end

end

--反初始化函数
function UnInitialize()

    

end

--初始化按钮事件
function InitButtonEvent()

    

end
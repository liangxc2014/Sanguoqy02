module(..., package.seeall);


--��ʼ������
function Initialize(viewPanel)

    local i = 0
    local enumerator = XMLManager.MenuItem.Data.Values:GetEnumerator()
    while enumerator:MoveNext() do
        local menuItemInfo = enumerator.Current
        if menuItemInfo.Type == MenuItemType.InternalAffairs then
            
            
        end
        
    end

end

--����ʼ������
function UnInitialize()

    

end

--��ʼ����ť�¼�
function InitButtonEvent()

    

end
module(..., package.seeall);

m_view = nil

--��ʼ������
function Initialize(viewPanel)

    m_view = SelectPeriodView
    m_view.Initialize(viewPanel)

    InitButtons()

end

--����ʼ������
function UnInitialize()

    

end

--��ʼ����ť�б�
function InitButtons()

    local periodsList = GamePublic.Instance.PeriodsList
    local count = periodsList.Count

    local btnPrefab = ResourcesManager.Instance:Load(UINamesConfig.FontButtonExample)

    for i=0, count - 1 do
        local go = Utility.AddChild(m_view.m_ButtonsRoot, btnPrefab)
        go.name = periodsList:get_Item(i)
        go:GetComponent("UIButton"):SetText(go.name)

        go.transform.localPosition = Vector3.New(0, GlobalConfig.FontButtonsVSpace * i)

        InputManager.Instance:AddOnClickEvent(go, OnButtonClick)
    end

end

--������Ӧ
function OnButtonClick(go)

    print(go.name)

end
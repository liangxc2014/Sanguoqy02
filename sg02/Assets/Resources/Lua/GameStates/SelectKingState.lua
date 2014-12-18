module(..., package.seeall);

function OnEnter()

    GamePublic.Instance.DataManager:InitDataManager()

    UIManager.Instance:ShowView(UINamesConfig.SelectKing)

end

function  OnExit()

    UIManager.Instance:DestroyView(UINamesConfig.SelectKing)

end

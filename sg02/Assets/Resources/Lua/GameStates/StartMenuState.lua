module(..., package.seeall);

function OnEnter()

    UIManager.Instance:ShowView(UINamesConfig.StartMenu)

end

function  OnExit()

    UIManager.Instance:DestroyView(UINamesConfig.StartMenu)

end
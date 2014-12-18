module(..., package.seeall);

function OnEnter()

    UIManager.Instance:ShowView(UINamesConfig.SelectTimes)

end

function  OnExit()

    UIManager.Instance:DestroyView(UINamesConfig.SelectTimes)

end

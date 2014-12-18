module(..., package.seeall);


function OnEnter()

    UIManager.Instance:ShowView(UINamesConfig.InternalAffairs)

end

function  OnExit()

    UIManager.Instance:DestroyView(UINamesConfig.InternalAffairs)

end

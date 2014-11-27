module(..., package.seeall);

m_ButtonsRoot = nil

function Initialize(viewPanel)

    m_ButtonsRoot = viewPanel.transform:FindChild("Frame/Buttons").gameObject

end
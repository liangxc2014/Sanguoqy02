module(..., package.seeall);

m_kingListRoot = nil

m_buttonsRoot = nil

m_buttonConfirm = nil
m_buttonCancel = nil

m_imageFace = nil

function Initialize(viewPanel)

    m_kingListRoot = viewPanel.transform:FindChild("Left Anchor/KingsList").gameObject
    m_buttonsRoot = viewPanel.transform:FindChild("Left Anchor/Buttons").gameObject

    m_buttonConfirm = viewPanel.transform:FindChild("Left Anchor/Buttons/ButtonsConfirm").gameObject
    m_buttonCancel = viewPanel.transform:FindChild("Left Anchor/Buttons/ButtonsCancel").gameObject

    m_imageFace = viewPanel.transform:FindChild("Down Anchor/Face").gameObject

end
module(..., package.seeall);

m_menuListRoot = nil
m_imageFace = nil

m_confirmBox = nil
m_buttonConfirmOK = nil
m_buttonConfirmCancel = nil

function Initialize(viewPanel)

    m_menuListRoot = viewPanel.transform:FindChild("Left Anchor/MenuList").gameObject
    m_imageFace = viewPanel.transform:FindChild("Right Anchor/Face").gameObject

    m_confirmBox = viewPanel.transform:FindChild("Left Anchor/ConfirmBox").gameObject
    m_buttonConfirmOK = viewPanel.transform:FindChild("Left Anchor/ConfirmBox/ButtonOK").gameObject
    m_buttonConfirmCancel = viewPanel.transform:FindChild("Left Anchor/ConfirmBox/ButtonCancel").gameObject


    m_confirmBox:SetActive(false)
end
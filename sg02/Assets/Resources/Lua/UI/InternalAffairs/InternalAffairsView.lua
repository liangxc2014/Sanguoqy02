module(..., package.seeall);

m_menuListRoot = nil
m_imageFace = nil

function Initialize(viewPanel)

    m_menuListRoot = viewPanel.transform:FindChild("Left Anchor/MenuList").gameObject
    m_imageFace = viewPanel.transform:FindChild("Right Anchor/Face").gameObject

end
module(..., package.seeall);

m_btnStartGame = nil
m_btnLoadGame = nil
m_btnSetting = nil
m_btnQuit = nil


function Initialize(viewPanel)

    m_btnStartGame = viewPanel.transform:FindChild("Buttons/Start_game").gameObject
    m_btnLoadGame = viewPanel.transform:FindChild("Buttons/Load_game").gameObject
    m_btnSetting = viewPanel.transform:FindChild("Buttons/Setting_game").gameObject
    m_btnQuit = viewPanel.transform:FindChild("Buttons/Quit_game").gameObject

end
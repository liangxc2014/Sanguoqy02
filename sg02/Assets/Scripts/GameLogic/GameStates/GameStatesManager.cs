using UnityEngine;
using System.Collections;

public class GameStatesManager : StateManager
{
    // 开始菜单
    private StartMenuState m_startMenuState = new StartMenuState();
    public StartMenuState StartMenuState { get { return m_startMenuState; } }

    // 选择时期
    private SelectTimesState m_selectTimesState = new SelectTimesState();
    public SelectTimesState SelectTimesState { get { return m_selectTimesState; } }

    //选择君主
    private SelectKingState m_selectKingState = new SelectKingState();
    public SelectKingState SelectKingState { get { return m_selectKingState; } }

    //内政
    private InternalAffairsState m_internalAffairsState = new InternalAffairsState();
    public InternalAffairsState InternalAffairsState { get { return m_internalAffairsState; } }

    //大地图
    private WorldMapState m_worldMapState = new WorldMapState();
    public WorldMapState WorldMapState { get { return m_worldMapState; } }

    public override void Initialize() 
    {
        AddState(m_startMenuState);
        AddState(m_selectTimesState);
        AddState(m_selectKingState);
        AddState(m_internalAffairsState);
        AddState(m_worldMapState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;
    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }

            return instance;
        }
    }

    #region Header Dungeon

    [Space(10)]
    [Header("DUNGEON")]

    #endregion
    #region Tooltip

    [Tooltip("Populate with the dungeon RoomNodeTypeListSO")]

    #endregion
    
    [ChangeColorLabel(.2f,.2f,1)]public RoomNodeTypeListSO roomNodeTypeList;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用来管理游戏资源的类
/// </summary>
public class ResourceManager : SingletonBehaviour<ResourceManager>
{
    //保存默认资源路径
    public const string RESOURCE_PREFAB_PATH = "Prefabs/";

    //private 

    private ResourceManager()
    {
        
    }
}

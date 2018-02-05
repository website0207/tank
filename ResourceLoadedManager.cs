using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源加载管理器
/// </summary>
public class ResourceLoadedManager : SingletonBehaviour<ResourceLoadedManager>
{
    //预制件和精灵有好多种
    public Dictionary<string, GameObject> dictLoadedPrefab;
    public Dictionary<string, Sprite> dictLoadedImageSprite;
    //子弹和爆炸效果有好多个
    public List<GameObject> listBullet;
    public List<GameObject> listBoomEffect;

    //资源加载管理器的私有构造函数
    private ResourceLoadedManager()
    {
        dictLoadedPrefab = new Dictionary<string, GameObject>();
        dictLoadedImageSprite = new Dictionary<string, Sprite>();
        listBullet = new List<GameObject>();
        listBoomEffect = new List<GameObject>();
    }
    /// <summary>
    /// 自定义的资源管理器添加元素函数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void Add<T, K>(Dictionary<T, K> dictionary, T key, K value) where K : Object
    {
        if (dictionary == null)
        {
            dictionary = new Dictionary<T, K>();
        }
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, value);
        }
        else
        {
            dictionary[key] = value;
        }
    }
    //对于各种类型数据缓存的各自添加数据方法
    //private void AddToLoadedPrefab(string name, GameObject gameObject)
    //{
    //    Add<string, GameObject>(dictLoadedPrefab, name, gameObject);
    //}
    //private void AddToLoadedImageSprite(string name, Sprite sprite)
    //{
    //    Add<string, Sprite>(dictLoadedImageSprite, name, sprite);
    //}
    /// <summary>
    /// 获取否则设置resources为加载对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pathname"></param>
    /// <returns></returns>
    public T GetOrSetLoadedObject<T>(string pathname = default(string)) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            if (dictLoadedPrefab == null)
            {
                dictLoadedPrefab = new Dictionary<string, GameObject>();
            }
            if (!dictLoadedPrefab.ContainsKey(pathname))
            {
                GameObject go = Resources.Load<GameObject>(pathname);
                Add<string, GameObject>(dictLoadedPrefab, pathname, go);
            }
            return dictLoadedPrefab[pathname] as T;
        }
        else if (typeof(T) == typeof(Sprite))
        {
            if (dictLoadedImageSprite == null)
            {
                dictLoadedImageSprite = new Dictionary<string, Sprite>();
            }
            if (!dictLoadedImageSprite.ContainsKey(pathname))
            {
                Sprite sprite = Resources.Load<Sprite>(pathname);
                Add<string, Sprite>(dictLoadedImageSprite, pathname, sprite);
            }
            return dictLoadedImageSprite[name] as T;
        }
        return null;
    }

    public T GetOrCreateInstance<T>(List<T> list, string pathname) where T : Object
    {
        if (list != null && list.Count > 0)
        {
            T t = list[0];
            list.RemoveAt(0);
            return t;
        }
        else
        {
            T t = GetOrSetLoadedObject<T>(pathname);

            if (typeof(T) == typeof(GameObject))//如果是预制件，直接实例化一个出来加入列表中
            {
                T t_clone = Instantiate(t);
                list.Add(t_clone);//本来没有，是不是老师忘了写
                return t_clone;
            }
            else
            {
                list.Add(t);//如果是精灵，则加入列表当中
                return t;
            }
        }
    }

    public void RecoverBullet(GameObject go)
    {
        listBullet.Add(go);
    }
    public void RecoverBoomEffect(GameObject go)
    {
        listBoomEffect.Add(go);
    }

    //public BaseMissile GetOrCreateBullet(string pathnameBullet)
    //{
    //    return GetOrCreateInstance<GameObject>(listBullet, pathnameBullet).get
    //}
}

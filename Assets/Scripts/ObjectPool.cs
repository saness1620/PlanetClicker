using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _item;
    private List<T> _pool;

    protected void InitPool(T prefab)
    {
        _item = prefab;
        _pool = new List<T>();
    }

    protected T GetItem()
    {
        var item = _pool.FirstOrDefault(i => i.gameObject.activeSelf == false);

        if (item == null)
        {
            item = Instantiate(_item);
            _pool.Add(item);
        }

        return item;
    }
}

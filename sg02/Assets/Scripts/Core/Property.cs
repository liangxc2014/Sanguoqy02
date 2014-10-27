using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region 属性类
// 属性类型
public enum PropertyType
{
    None,
    SingleValueType,        //单一值
    ListValueType,         //数组值
    DictionaryType,         //字典值
}

//属性变化的类型
public enum PropertyChangeType
{
    UPDATE, //更新
    ADD,    //增加
    REMOVE, //删除
    MOVE    //移动
}

public class PropertyChangeEventArgs : System.EventArgs
{
    public PropertyChangeType m_changeType;    //数据变化类型
    public object m_oldValue;                  //旧数值,如果是数组增加时这个值没用
    public object m_newValue;                  //新改变的数值，如果是数组减少时这个值没用
    public int m_index;                        //如果是数组类型时，改变的位置

    public PropertyChangeEventArgs(PropertyChangeType changeTpye, object oldValue, object newValue, int index)
    {
        m_changeType = changeTpye;
        m_oldValue = oldValue;
        m_newValue = newValue;
        m_index = index;
    }
}
#endregion

/// <summary>
/// 属性类
/// </summary>
public class Property<T>
{
    private PropertyType m_propertyType;        // 类型
    private T m_value;                     // 单一数值
    private List<T> m_listValue;             // 数组值
    
    
    // 属性变化回调函数类型
    public delegate void PropertyChangeDelegate<X>(Property<X> changedProperty, PropertyChangeEventArgs msg);
    // 回调函数列表
    public event PropertyChangeDelegate<T> m_changeEvent;

    /// <summary>
    /// 个数
    /// </summary>
    public int Count
    {
        get
        {
            if (m_propertyType == PropertyType.SingleValueType)
            {
                Debugging.LogError("Function:GetArrayValue, PropertyType Error! Current type is" + m_propertyType.ToString());
                return 0;
            }

            if (m_propertyType == PropertyType.ListValueType)
            {
                if (m_listValue != null)
                {
                    return m_listValue.Count;
                }
            }

            return 0;
        }
    }

    #region Public
    /// <summary>
    /// 构造函数
    /// </summary>
    public Property(PropertyType propertyType)
    {
        m_propertyType = propertyType;

        switch (m_propertyType)
        {
            case PropertyType.SingleValueType:
                m_value = default(T);
                break;
            case PropertyType.ListValueType:
                m_listValue = new List<T>();
                break;
        }
    }

    public Property(object value)
    {
        if (value is IList)
        {
            m_propertyType = PropertyType.ListValueType;

            m_listValue = (List<T>)(value);
        }
        else
        {
            m_propertyType = PropertyType.SingleValueType;
            m_value = (T)(value);
        }
    }

    /// <summary>
    /// 增加一个事件回调函数
    /// </summary>
    public void AddValueChangeEvent(PropertyChangeDelegate<T> callback)
    {
        m_changeEvent += callback;
    }

    /// <summary>
    /// 移除一个事件回调函数
    /// </summary>
    public void RemoveValueChangeEvent(PropertyChangeDelegate<T> callback)
    {
        m_changeEvent -= callback;
    }

    #endregion

    #region 单一值属性

    /// <summary>
    /// 重载赋值运算符
    /// </summary>
    public static implicit operator Property<T>(T str)  
    {
        return new Property<T>(str);  
    }
    public static implicit operator T(Property<T> mystr)  
    {
        return mystr.Value;  
    } 


    public T Value
    {
        get
        {
            if (m_propertyType != PropertyType.SingleValueType)
            {
                Debugging.LogError("Function:GetValue, PropertyType Error! Current type is" + m_propertyType.ToString());
                return default(T);
            }

            return m_value;
        }

        set
        {
            if (m_propertyType != PropertyType.SingleValueType)
            {
                Debugging.LogError("Function:SetValue, PropertyType Error! Current type is" + m_propertyType.ToString());
            }

            PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.UPDATE, m_value, value, -1);

            m_value = value;

            TriggerChangeEvent(msg);
        }
    }

    #endregion 单一值属性

    #region 列表值属性

    public T this[int index]
    {
        get
        {
            if (m_propertyType != PropertyType.ListValueType)
            {
                Debugging.LogError("Function:GetArrayValue, PropertyType Error! Current type is" + m_propertyType.ToString());
                return default(T);
            }

            if (m_listValue == null || (index < 0) || (index >= m_listValue.Count))
            {
                Debugging.LogError("Function:GetArrayValue, ArgumentOutOfRangeException!");
                return default(T);
            }

            return m_listValue[index];
        }
        set
        {
            if (m_propertyType != PropertyType.ListValueType)
            {
                Debugging.LogError("Function:SetArrayValue, PropertyType Error! Current type is" + m_propertyType.ToString());
            }

            if (m_listValue == null)
            {
                Debugging.LogError("Function:SetArrayValue, array is empty!");
                return;
            }

            if (index < 0 || index >= m_listValue.Count)
            {
                Debugging.LogError("Function:SetArrayValue, ArgumentOutOfRangeException!");
                return;
            }

            PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.UPDATE, m_listValue[index], value, index);

            m_listValue[index] = value;

            TriggerChangeEvent(msg);
        }
    }

    public void Add(T arrayValue)
    {
        if (m_propertyType != PropertyType.ListValueType)
        {
            Debugging.LogError("Function:Add, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.ADD, null, arrayValue, this.Count);

        m_listValue.Add(arrayValue);

        TriggerChangeEvent(msg);
    }

    public void Insert(int index, T arrayValue)
    {
        if (m_propertyType != PropertyType.ListValueType)
        {
            Debugging.LogError("Function:Add, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        if (index < 0 || (index > this.Count))
        {
            Debugging.LogError("Function:Remove, index input ERROR!");
            return;
        }

        PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.ADD, null, arrayValue, index);

        m_listValue.Insert(index, arrayValue);

        TriggerChangeEvent(msg);
    }

    public void Remove(T obj)
    {
        if (m_propertyType != PropertyType.ListValueType)
        {
            Debugging.LogError("Function:Remove, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        if (m_listValue == null)
        {
            Debugging.LogError("Function:Remove, Array is empty!");
            return;
        }

        int index = m_listValue.IndexOf(obj);

        if (index < 0 || index >= m_listValue.Count)
        {
            Debugging.LogError("Function:Remove, index input ERROR!");
            return;
        }

        PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.REMOVE, m_listValue[index], null, index);

        m_listValue.RemoveAt(index);

        TriggerChangeEvent(msg);
    }

    public void RemoveAt(int index)
    {
        if (m_propertyType != PropertyType.ListValueType)
        {
            Debugging.LogError("Function:RemoveAt, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        if ((m_listValue == null) || (index < 0 || index >= m_listValue.Count))
        {
            Debugging.LogError("Function:RemoveAt, index input ERROR!");
            return;
        }

        PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.REMOVE, m_listValue[index], null, index);

        m_listValue.RemoveAt(index);

        TriggerChangeEvent(msg);
    }

    public bool Contains(T value)
    {
        if (m_propertyType != PropertyType.ListValueType)
        {
            Debugging.LogError("Function:Contains, PropertyType Error! Current type is" + m_propertyType.ToString());
            return false;
        }

        return m_listValue.Contains(value);
    }

    public int IndexOf(T value)
    {
        if (m_propertyType != PropertyType.ListValueType)
        {
            Debugging.LogError("Function:IndexOf, PropertyType Error! Current type is" + m_propertyType.ToString());
            return -1;
        }
        
        return m_listValue.IndexOf(value);
    }
    
    public void Clear()
    {
        if (m_propertyType == PropertyType.SingleValueType)
        {
            Debugging.LogError("Function:Clear, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        if (m_propertyType == PropertyType.ListValueType)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                RemoveAt(i);
            }
        }
    }

    #endregion 列表值属性

    private void TriggerChangeEvent(PropertyChangeEventArgs msg)
    {
        if (m_changeEvent != null)
            m_changeEvent(this, msg);
    }
}

public class Property<T, U>
{
    private PropertyType m_propertyType;        // 类型
    private Dictionary<object, object> m_dictValue; //字典值

    // 属性变化回调函数类型
    public delegate void PropertyChangeDelegate<X, Y>(Property<X, Y> changedProperty, PropertyChangeEventArgs msg);
    // 回调函数列表
    public event PropertyChangeDelegate<T, U> m_changeEvent;

    /// <summary>
    /// 个数
    /// </summary>
    public int Count
    {
        get
        {
            if (m_propertyType == PropertyType.DictionaryType)
            {
                if (m_dictValue != null)
                {
                    return m_dictValue.Count;
                }
            }

            return 0;
        }
    }

    #region Public

    /// <summary>
    /// 构造函数
    /// </summary>
    public Property(PropertyType propertyType)
    {
        m_propertyType = propertyType;

        m_dictValue = new Dictionary<object, object>();
    }

    /// <summary>
    /// 增加一个事件回调函数
    /// </summary>
    public void AddValueChangeEvent(PropertyChangeDelegate<T, U> callback)
    {
        m_changeEvent += callback;
    }

    /// <summary>
    /// 移除一个事件回调函数
    /// </summary>
    public void RemoveValueChangeEvent(PropertyChangeDelegate<T, U> callback)
    {
        m_changeEvent -= callback;
    }
    #endregion

    #region 字典值属性

    public U this[T key]
    {
        get
        {
            if (m_propertyType != PropertyType.DictionaryType)
            {
                Debugging.LogError("Function:GetDictionaryValue, PropertyType Error! Current type is" + m_propertyType.ToString());
                return default(U);
            }

            if (m_dictValue == null || !m_dictValue.ContainsKey(key))
            {
                Debugging.LogError("Function:GetDictionaryValue, is not contain key!");
                return default(U);
            }

            return (U)m_dictValue[key];
        }
        set
        {
            if (m_propertyType != PropertyType.DictionaryType)
            {
                Debugging.LogError("Function:SetDictionaryValue, PropertyType Error! Current type is" + m_propertyType.ToString());
            }

            if (m_dictValue == null)
            {
                Debugging.LogError("Function:SetDictionaryValue, Dictionary is empty!");
                return;
            }

            if (!m_dictValue.ContainsKey(key))
            {
                Debugging.LogError("Function:SetDictionaryValue, is not contain key!");
                return;
            }

            PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.UPDATE, m_dictValue[key], value, -1);

            m_dictValue[key] = value;

            TriggerChangeEvent(msg);
        }
    }

    public void Add(T key, U valueOf)
    {
        if (m_propertyType != PropertyType.DictionaryType)
        {
            Debugging.LogError("Function:Add, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.ADD, null, valueOf, -1);

        m_dictValue.Add(key, valueOf);

        TriggerChangeEvent(msg);
    }

    public void Remove(T key)
    {
        if (m_propertyType != PropertyType.DictionaryType)
        {
            Debugging.LogError("Function:Remove, PropertyType Error! Current type is" + m_propertyType.ToString());
            return;
        }

        if (m_dictValue == null)
        {
            Debugging.LogError("Function:Remove, Dictionary is empty!");
            return;
        }

        if (!m_dictValue.ContainsKey(key))
        {
            Debugging.LogError("Function:Remove, is not contains key!");
            return;
        }

        PropertyChangeEventArgs msg = new PropertyChangeEventArgs(PropertyChangeType.REMOVE, m_dictValue[key], null, -1);

        m_dictValue.Remove(key);

        TriggerChangeEvent(msg);
    }

    public bool ContainsKey(T key)
    {
        if (m_propertyType != PropertyType.DictionaryType)
        {
            Debugging.LogError("Function:Contains, PropertyType Error! Current type is" + m_propertyType.ToString());
            return false;
        }

        return m_dictValue.ContainsKey(key);
    }

    public void Clear()
    {
        if (m_propertyType == PropertyType.DictionaryType)
        {
            IEnumerator keyEnumerator = m_dictValue.Keys.GetEnumerator();
            while (keyEnumerator.MoveNext())
            {
                Remove((T)keyEnumerator.Current);
            }
        }
    }
    #endregion 字典值属性

    private void TriggerChangeEvent(PropertyChangeEventArgs msg)
    {
        if (m_changeEvent != null)
            m_changeEvent(this, msg);
    }
}
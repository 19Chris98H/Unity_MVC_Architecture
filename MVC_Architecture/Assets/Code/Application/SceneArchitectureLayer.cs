using System.Linq;
using System;
using UnityEngine;

public class SceneArchitectureLayer<T> : GameElement
{
    void Awake()
    {
        SetPropertyTo(this);
    }

    void OnDestroy()
    {
        if (App == null) return;
        SetPropertyTo(null);
    }

    void SetPropertyTo(SceneArchitectureLayer<T> sceneController)
    {
        var layerType = typeof(T);
        try
        {
            var propertyInfo = layerType.GetProperties().ToList().First(info => info.PropertyType == GetType());
            switch (layerType)
            {
                case Type t when t == typeof(ApplicationController) : propertyInfo.SetValue(App.Controller, sceneController); break;
                case Type t when t == typeof(ApplicationView) : propertyInfo.SetValue(App.View, sceneController); break;
                case Type t when t == typeof(ApplicationModel) : propertyInfo.SetValue(App.Model, sceneController); break;
            }
        }
        catch (Exception)
        {
            Debug.LogError("Property of type " + GetType() + " not found in " + layerType);
        }
    }
}

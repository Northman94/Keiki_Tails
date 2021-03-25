using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPhoneXSafeArea : MonoBehaviour
{
    public delegate void SafeAreaChanged (Rect safeArea);
    public static event SafeAreaChanged OnSafeAreaChanged;


    private Rect _safeArea;


    private void Awake()
    {
        _safeArea = Screen.safeArea;
    }

    //Update safeArea due to device orientation
    private void Update()
    {
        if (_safeArea != Screen.safeArea)
        {
            _safeArea = Screen.safeArea;

            OnSafeAreaChanged?.Invoke(_safeArea);
        }
    }
}
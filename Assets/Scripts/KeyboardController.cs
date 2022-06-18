using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �o�C���h�Ǘ��N���X
/// </summary>
public static class KeyboardController
{
    public static KeyCode LEFTFRIP { get; private set; } = KeyCode.LeftArrow;
    public static KeyCode RIGHTFRIP { get; private set; } = KeyCode.RightArrow;
    public static KeyCode BOTHFLIP { get; private set; } = KeyCode.DownArrow;

    // �L�[�{�[�h�o�C���h
    // �����Ȃ��Ńf�t�H���g
    public static void BindForKeyboard( KeyCode _left = KeyCode.LeftArrow, 
                                        KeyCode _right= KeyCode.RightArrow, 
                                        KeyCode _all=KeyCode.DownArrow)
    {
        LEFTFRIP = _left;
        RIGHTFRIP = _right;
        BOTHFLIP = _all;
    }

    }
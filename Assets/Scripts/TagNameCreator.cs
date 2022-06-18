using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// �^�O���萔�Ǘ��X�N���v�g �쐬�N���X
/// <URL>https://baba-s.hatenablog.com/entry/2014/02/25/000000</URL>
/// </summary>

public static class TagNameCreator
{
    // ����������ꗗ
    // �^�O���Ɏg�p�ł��Ȃ�
    private static readonly string[] INVALID_CHARS =
    {
        " ", "!", "\"", "#", "$",
        "%", "&", "\'", "(", ")",
        "-", "=", "^",  "~", "\\",
        "|", "[", "{",  "@", "`",
        "]", "}", ":",  "*", ";",
        "+", "/", "?",  ".", ">",
        ",", "<"
    };

    // Unity �R�}���h��
    private const string ITEM_NAME = "Tools/Create/Tag Name";
    // �t�@�C���p�X
    private const string PATH = "Assets/TagName.cs";
    // �t�@�C����(�g���q����)
    private static readonly string FILENAME = Path.GetFileName(PATH);
    // �t�@�C����(�g���q�Ȃ�)
    private static readonly string FILENAME_WITHOUT_EXTENSION = Path.GetFileNameWithoutExtension(PATH);

    /// <summary>
    /// �^�O����萔�Ǘ�����N���X�̍쐬
    /// </summary>
    [MenuItem(ITEM_NAME)]
    public static void Create()
    {
        if (!CanCreate())
        {
            return;
        }

        CreateScript();

        EditorUtility.DisplayDialog(FILENAME, "�쐬���������܂���", "OK");
    }
    /// <summary>
    /// �X�N���v�g�̍쐬
    /// </summary>
    private static void CreateScript()
    {
        var builder = new StringBuilder();

        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// �^�O����萔�ŊǗ�����N���X");
        builder.AppendLine("/// </summary>");
        builder.AppendFormat("public static class {0}", FILENAME_WITHOUT_EXTENSION).AppendLine();
        builder.AppendLine("{");

        // �^�O���ꗗ�擾���ď�������
        foreach(var n in InternalEditorUtility.tags.Select(c=> new { var=RemoveInvalidChars(c), val = c }))
        {
            builder.Append("\t").AppendFormat(@"public const string {0} = ""{1}"";", n.var,n.val).AppendLine();
        }

        builder.AppendLine("}");

        // �f�B���N�g���쐬
        var directoryname = Path.GetDirectoryName(PATH);
        if (!Directory.Exists(directoryname))
        {
            Directory.CreateDirectory(directoryname);
        }

        // �t�@�C���ۑ�
        File.WriteAllText(PATH, builder.ToString(),Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);

    }
    /// <summary>
    /// �^�O���萔�Ǘ��N���X���쐬�ł��邩�`�F�b�N
    /// </summary>
    private static bool CanCreate()
    {
        return !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;
    }

    /// <summary>
    /// ����������̍폜
    /// </summary>
    /// <param name="str"></param>
    private static object RemoveInvalidChars(string str)
    {
        Array.ForEach(INVALID_CHARS, c => str = str.Replace(c, string.Empty));
        return str;
    }

}

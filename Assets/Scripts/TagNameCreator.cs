using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// タグ名定数管理スクリプト 作成クラス
/// <URL>https://baba-s.hatenablog.com/entry/2014/02/25/000000</URL>
/// </summary>

public static class TagNameCreator
{
    // 無効文字列一覧
    // タグ名に使用できない
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

    // Unity コマンド名
    private const string ITEM_NAME = "Tools/Create/Tag Name";
    // ファイルパス
    private const string PATH = "Assets/TagName.cs";
    // ファイル名(拡張子あり)
    private static readonly string FILENAME = Path.GetFileName(PATH);
    // ファイル名(拡張子なし)
    private static readonly string FILENAME_WITHOUT_EXTENSION = Path.GetFileNameWithoutExtension(PATH);

    /// <summary>
    /// タグ名を定数管理するクラスの作成
    /// </summary>
    [MenuItem(ITEM_NAME)]
    public static void Create()
    {
        if (!CanCreate())
        {
            return;
        }

        CreateScript();

        EditorUtility.DisplayDialog(FILENAME, "作成が完了しました", "OK");
    }
    /// <summary>
    /// スクリプトの作成
    /// </summary>
    private static void CreateScript()
    {
        var builder = new StringBuilder();

        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// タグ名を定数で管理するクラス");
        builder.AppendLine("/// </summary>");
        builder.AppendFormat("public static class {0}", FILENAME_WITHOUT_EXTENSION).AppendLine();
        builder.AppendLine("{");

        // タグ名一覧取得して書き込み
        foreach(var n in InternalEditorUtility.tags.Select(c=> new { var=RemoveInvalidChars(c), val = c }))
        {
            builder.Append("\t").AppendFormat(@"public const string {0} = ""{1}"";", n.var,n.val).AppendLine();
        }

        builder.AppendLine("}");

        // ディレクトリ作成
        var directoryname = Path.GetDirectoryName(PATH);
        if (!Directory.Exists(directoryname))
        {
            Directory.CreateDirectory(directoryname);
        }

        // ファイル保存
        File.WriteAllText(PATH, builder.ToString(),Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);

    }
    /// <summary>
    /// タグ名定数管理クラスが作成できるかチェック
    /// </summary>
    private static bool CanCreate()
    {
        return !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;
    }

    /// <summary>
    /// 無効文字列の削除
    /// </summary>
    /// <param name="str"></param>
    private static object RemoveInvalidChars(string str)
    {
        Array.ForEach(INVALID_CHARS, c => str = str.Replace(c, string.Empty));
        return str;
    }

}

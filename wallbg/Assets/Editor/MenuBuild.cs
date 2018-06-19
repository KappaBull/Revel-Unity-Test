using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.SceneManagement;

public class MenuBuild {
 	[MenuItem("RevelOutPut/build")]
	public static void build() {
		string webGLexportPath = ReturnFolder(Application.dataPath, 1) + "public";
		string fixPath = webGLexportPath + "/unity3d/";

		string errorMsg = BuildPipeline.BuildPlayer(GetScenes(), webGLexportPath, BuildTarget.WebGL, BuildOptions.None);
		if(string.IsNullOrEmpty(errorMsg) == false) {
		 	Debug.LogWarning("BuildError:" + errorMsg);
		}
		FileUtil.DeleteFileOrDirectory(webGLexportPath + "/index.html");
		Directory.Delete(fixPath, true);
		Directory.Move(webGLexportPath + "/Build/", fixPath);

		// string loadjs = string.Empty;

		// System.IO.StreamReader sr = new System.IO.StreamReader(webGLexportPath + "UnityLoader.js", System.Text.Encoding.GetEncoding("utf-8"));
		// loadjs = sr.ReadToEnd();
		// sr.Close();

		// loadjs.Replace("UnityLoader.SystemInfo.hasWebGL?UnityLoader.SystemInfo.mobile?e.popup(\"Please note that Unity WebGL is not currently supported on mobiles. Press OK if you wish to continue anyway.\",[{text:\"OK\",callback:t}]):[\"Firefox\",\"Chrome\",\"Safari\"].indexOf(UnityLoader.SystemInfo.browser)==-1?e.popup(\"Please note that your browser is not currently supported for this Unity WebGL content. Press OK if you wish to continue anyway.\",[{text:\"OK\",callback:t}]):t():e.popup(\"Your browser does not support WebGL\",[{text:\"OK\",callback:r}])", "t();");

		// System.IO.StreamWriter sw = new System.IO.StreamWriter(webGLexportPath + "UnityLoader.js", false, System.Text.Encoding.GetEncoding("utf-8"));
		// sw.Write(loadjs);
		// sw.Close();
	}

	public static string[] GetScenes() {
        ArrayList levels = new ArrayList();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
            if (scene.enabled) {
				levels.Add(scene.path);
            }
        }
        return (string[])levels.ToArray(typeof(string));
    }

	private static string ReturnFolder(string path_, int returnCount_) {
		string path = path_;
		for (int i = 0; i < returnCount_ + 1; i++) {
			path = path.Substring(0, path.LastIndexOf('/'));
		}
		return path + "/";
	}
}

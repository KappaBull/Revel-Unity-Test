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

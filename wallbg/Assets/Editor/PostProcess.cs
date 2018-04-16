using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.SceneManagement;

public class PostProcess  {
 	[MenuItem("public/build")]
	public static void build() {
		string path2 = Application.dataPath.Substring( 0, Application.dataPath.LastIndexOf( @"\" ) + 1 );
		Debug.Log(path2);
		//string errorMsg = BuildPipeline.BuildPlayer(GetScenes(), Application.dataPath, BuildTarget.WebGL, BuildOptions.None);
		// if(string.IsNullOrEmpty(errorMsg) == false) {
		// 	Debug.LogWarning("BuildError:" + errorMsg);
		// }
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

}

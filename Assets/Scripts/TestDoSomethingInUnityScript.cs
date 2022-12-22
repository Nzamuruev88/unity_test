using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGS.Story.Build.Validation {
    public class TestDoSomethingInUnityScript  {
        public static void ValidateCommandLine() {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            Validate(commandLineArgs);
        }

        private static void Validate(string[] commandLineArgs) {
            Debug.Log($"Validating with parameters {string.Join(",", commandLineArgs)}");

            BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;
            Debug.Log($"Active build target '{activeBuildTarget}', group '{EditorUserBuildSettings.selectedBuildTargetGroup},{BuildPipeline.GetBuildTargetGroup(activeBuildTarget)}'");

            try {
                TestPrepareAssets();
                TestValidateAssets();
            }
            catch (Exception ex) {
                Debug.LogError(ex.ToString());
                throw;
            }

            Debug.Log($"Validation complete for platform '{activeBuildTarget}'");
            if (Application.isBatchMode) {
                EditorApplication.Exit(0);
            }
        }

        private static void TestValidateAssets() {
            Debug.Log("Validate");
        }

        private static void TestPrepareAssets() {
            Debug.Log("Prepare");
        }
    }
}

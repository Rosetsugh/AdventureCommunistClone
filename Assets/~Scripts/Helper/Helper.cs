using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Helper
{
	public static float ClampAngle(float angle, float minAngle, float maxAngle)
	{
		do
		{
			// Keep the angle between -/+360 so if the angle is 900, it will return 180
			// The code should at least run this part once (i.e. first), hence the do, while loop
			if (angle < -360)
				angle += 360;

			if (angle > 360)
				angle -= 360;

		} while (angle < -360 || angle > 360);

		return Mathf.Clamp(angle, minAngle, maxAngle);
	}

	public static Vector3 CreatePositionVector(float rotationX, float rotationY, float distance)
	{
		//Create a new vector3 with minus distance because we want the camera behind the character
		Vector3 cameraPosition = new Vector3(0, 0, -distance);

		//Create a new quaternion called rotation. We do not need the Z position because we are not rolling
		//the camera
		Quaternion cameraRotation = Quaternion.Euler(rotationX, rotationY, 0);

		//Add the vector (rotation * direction) to the TargetLookAtTransform position
		return (cameraRotation * cameraPosition);
	}

	public static int GetCurrentLevelNumber()
	{
		var levelName = SceneManager.GetActiveScene().name;
		Debug.Log(levelName);
		int.TryParse(new string(levelName.Where(char.IsDigit).ToArray()), out int currentLevelNumber);

		return currentLevelNumber;
	}

	public static int GetNextLevelNumber()
	{
		var levelName = SceneManager.GetActiveScene().name;
		int.TryParse(new string (levelName.Where(char.IsDigit).ToArray()), out int currentLevelNumber);

		return currentLevelNumber + 1;
	}

	public static int GetPreviousLevelNumber()
	{
		var levelName = SceneManager.GetActiveScene().name;
		int.TryParse(new string(levelName.Where(char.IsDigit).ToArray()), out int currentLevelNumber);

		return currentLevelNumber - 1;
	}

	// Return the number of scenes in the Build Settings with the name 'Level'
	public static int GetLevelsFromSceneFolder()
	{
		int totalLevels = 0;

		DirectoryInfo pathToSceneFiles = new DirectoryInfo(Application.dataPath + @"/_Scenes");
		var sceneFiles = pathToSceneFiles.GetFiles("*.unity");

		foreach (var scene in sceneFiles)
		{
			// Only count the scenes that have 'Level' in their name
			if (scene.Name.Contains("Level"))
				totalLevels++;
		}

		return totalLevels;
	}
}
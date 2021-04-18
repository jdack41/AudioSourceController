using UnityEngine;

namespace AudioSourceController.Constants
{
    public static class PathConstants
    {
        public static readonly string SEPARATOR = System.IO.Path.DirectorySeparatorChar.ToString();
        public static readonly string APPLICATION_ROOT_DIR = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + SEPARATOR + "Temp";
        public static readonly string MP3_DATA_DIRECTORY = APPLICATION_ROOT_DIR + SEPARATOR + "MP3";
        public static readonly string TRACK_DETAILS_DATA_DIRECTORY = Application.persistentDataPath + SEPARATOR + "TrackData";
    }
}
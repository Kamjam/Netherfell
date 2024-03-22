using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //allows use the systems serialization
using System.IO; //allows us to read + write to the computer or mobile devices

public class SaveLoad : MonoBehaviour
{
    //saving variables
    public string saveName = "SavedGame";
    public string directoryName = "Netherfell_Saves";
    public SaveGameData data;

    //function for saving games
    public void SaveFile()
    {
        //Create the save directory if it doesn't exists
        if(!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        //Formatter to convert unity data into bin file
        BinaryFormatter form = new BinaryFormatter();

        //Choose save location
        FileStream saveFile = File.Create(directoryName + "/" + saveName + " .bin");

        //write c# unity game data into a bin file
        form.Serialize(saveFile, data);

        //close the file
        saveFile.Close();
    }
}

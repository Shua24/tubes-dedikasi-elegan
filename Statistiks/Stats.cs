using System;

public class Stats
{
    private string filepath; // folder yang isinya csv
    public Stats(string filepath)
    {
        this.filepath = filepath;
    }
    public string GetFilePath()
    {
        return filepath;
    }

    public static bool ExtCheck(string filepath)
    {
        string ext = Path.GetExtension(filepath);
        return ext == ".csv";
    }
}

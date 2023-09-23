using System;
using System.Collections.Generic;
using System.IO;
class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear(); // Clear existing entries

        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                Entry entry = null;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Date: "))
                    {
                        entry = new Entry("", "");
                        entry.Date = line.Substring("Date: ".Length);
                    }
                    else if (line.StartsWith("Prompt: "))
                    {
                        entry.Prompt = line.Substring("Prompt: ".Length);
                    }
                    else if (line.StartsWith("Response: "))
                    {
                        entry.Response = line.Substring("Response: ".Length);
                        entries.Add(entry);
                    }
                }
            }
        }
    }
}
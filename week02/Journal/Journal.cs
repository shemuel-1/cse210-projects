using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date} - Prompt: {entry._entryText}");
        }
    }

    public void SaveToFile(string file)
    {
        Console.WriteLine("Saving to file...");
        using (StreamWriter journalFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                journalFile.WriteLine($"{entry._date}~~{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries = [];
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~~");

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._entryText = parts[1];
            _entries.Add(entry);
        }
    }
}
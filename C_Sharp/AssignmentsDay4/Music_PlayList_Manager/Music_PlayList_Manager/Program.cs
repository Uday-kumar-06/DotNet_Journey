using Music_PlayList_Manager;

class Program
{
    public static void Main(string[] args)
    {
        LinkedList<string> playlist = new LinkedList<string>();
        SortedList<int, string> songsByRating = new SortedList<int, string>();
        SortedDictionary<string, string> songsByArtist = new SortedDictionary<string, string>();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Enter Song Name:");
            string songName = Console.ReadLine();

            Console.WriteLine("Enter Song Rating:");
            int songRating = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Artist Name:");
            string artistName = Console.ReadLine();

            new Songs(songName, songRating, artistName);

            playlist.AddLast(songName);
            int ratingKey = songRating;
            while (songsByRating.ContainsKey(ratingKey))
                ratingKey++;
            songsByRating.Add(ratingKey, songName);
            if (songsByArtist.ContainsKey(artistName))
                songsByArtist[artistName] += ", " + songName;
            else
                songsByArtist.Add(artistName, songName);
        }
        Console.WriteLine("\nPlaylist (in order added):");
        int count = 1;
        foreach (string song in playlist)
        {
            Console.WriteLine(count + ". " + song);
            count++;
        }
        Console.WriteLine("\nEnter song name to remove:");
        string removeSong = Console.ReadLine();
        if (playlist.Contains(removeSong))
        {
            playlist.Remove(removeSong);
            Console.WriteLine(removeSong + " removed.");
        }
        else
        {
            Console.WriteLine("Song not found.");
        }

        Console.WriteLine("\nUpdated Playlist:");
        count = 1;
        foreach (string song in playlist)
        {
            Console.WriteLine(count + ". " + song);
            count++;
        }
        Console.WriteLine("\nSongs by Rating:");
        foreach (var entry in songsByRating)
        {
            Console.WriteLine("Rating " + entry.Key + " : " + entry.Value);
        }
        Console.WriteLine("\nSongs by Artist:");
        foreach (var entry in songsByArtist)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }
    }
}
using Publisher_Subcriber_EventDelegation_Youtube;

class Program
{
    public static void Main(string[] args)
    {
        YouTubeChannel channel = new YouTubeChannel("Tech Guru");
        Subsricbe subscriber1 = new Subsricbe("Alice");
        Subsricbe subscriber2 = new Subsricbe("Bob");
        Subsricbe subscriber3 = new Subsricbe("Charlie");

        // Subscribe to the event

        channel.OnVideoUploaded += subscriber1.WatchVideo;
        channel.OnVideoUploaded += subscriber2.WatchVideo;
        channel.OnVideoUploaded += subscriber3.WatchVideo;

        // Upload a video
        channel.UploadVideo("Introduction to C# Events");
    }
}

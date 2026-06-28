namespace FileAssistant1.Services.Chat
{
    public interface IChatService
    {
        Task<string> AskAsync(string question);

    }
}

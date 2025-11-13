public class PromptGenerator
{
    public List<string> _prompts;

    public string GetRandomPrompt()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did God touch my life today?",
            "What was the strongest emotion I felt today?",
            "If I could one thing over again, what would it be?",
            "What made you smile today?",
            "What challenge did you overcome today?"
        };

        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);

        return _prompts[index] ;
    }
}
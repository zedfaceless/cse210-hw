using System;
using System.Collections.Generic;

static class PromptManager
{
    private static List<string> reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
        // Add more prompts as needed
    };

    private static Random random = new Random();

    public static string GetRandomReflectionPrompt()
    {
        int index = random.Next(reflectionPrompts.Count);
        return reflectionPrompts[index];
    }
}

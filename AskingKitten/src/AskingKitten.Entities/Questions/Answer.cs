using System;
using System.Collections.Generic;

namespace AskingKitten.Entities.Questions;

public class Answer
{
    // public Answer(Guid userId, string text, Question question)
    // {
    //     UserId = userId; 
    //     Text = text;
    //     Question = question;
    // } 
    
    public required Guid Id { get; set; }
    
    public required Guid UserId { get; set; }
    
    public required string Text { get; set; }
    
    public required Question Question { get; set; }
    
    public List<Guid> Comments { get; set; } = [];
}
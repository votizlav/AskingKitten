using System;
using System.Collections.Generic;

namespace AskingKitten.Entities.Comments;

public class Comment
{
    public Guid Id { get; set; }

    public required Guid UserId { get; set; }

    public Comment? ParentComment { get; set; }

    public required Guid EntityId { get; set; }

    public List<Comment> ChildComments { get; set; } = [];
}
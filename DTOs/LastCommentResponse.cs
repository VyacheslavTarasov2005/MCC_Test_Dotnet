using System;

namespace Blog.DTOs;

public record LastCommentResponse(
    DateTime CreatedDate,
    string Text
    );
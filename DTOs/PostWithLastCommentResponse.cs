using System;

namespace Blog.DTOs;

public record PostWithLastCommentResponse(
    string PostTitle,
    LastCommentResponse? LastComment
    );
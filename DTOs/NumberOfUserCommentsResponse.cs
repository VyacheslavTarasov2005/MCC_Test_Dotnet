namespace Blog.DTOs;

public record NumberOfUserCommentsResponse(
    string Username,
    int NumberOfComments
    );
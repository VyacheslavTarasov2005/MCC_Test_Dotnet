using System;
using System.Collections.Generic;
using System.Linq;
using Blog.DTOs;

namespace Blog.services;

public class BlogService
{
    public static List<NumberOfUserCommentsResponse> NumberOfCommentsPerUser(MyDbContext context)
    {
        var response = context.BlogComments
            .GroupBy(comment => comment.UserName)
            .Select(group => new NumberOfUserCommentsResponse(
                group.Key, 
                group.Count()
                )
            )
            .ToList();
        
        return response;
    }

    public static List<PostWithLastCommentResponse> PostsOrderedByLastCommentDate(MyDbContext context)
    {
        var response = context.BlogPosts
            .Select(post => new PostWithLastCommentResponse(
                    post.Title,
                    post.Comments
                        .OrderByDescending(comment => comment.CreatedDate)
                        .Select(comment => new LastCommentResponse(
                                comment.CreatedDate,
                                comment.Text
                            )
                        )
                        .FirstOrDefault()
                )
            )
            .ToList()
            .OrderByDescending(post => post.LastComment?.CreatedDate)
            .ToList();
        
        return response;
    }
}
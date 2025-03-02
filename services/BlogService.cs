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
                group.Count())
            )
            .ToList();
        
        return response;
    }
}
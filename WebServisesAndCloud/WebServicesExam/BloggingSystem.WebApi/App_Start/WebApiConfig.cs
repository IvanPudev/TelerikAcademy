using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BloggingSystem.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ThreadsPosts",
                routeTemplate: "api/threads/{threadId}/posts",
                defaults: new
                {
                    controller = "threads",
                    action = "posts"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsVoteApi",
                routeTemplate: "api/posts/{postId}/vote",
                defaults: new
                {
                    controller = "posts",
                    action = "vote"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsCommentApi",
                routeTemplate: "api/posts/{postId}/comment",
                defaults: new
                {
                    controller = "posts",
                    action = "comment"
                }
            );

            config.Routes.MapHttpRoute(
                name: "ThreadsCreateApi",
                routeTemplate: "api/threads/create",
                defaults: new
                {
                    controller = "threads",
                    action = "create"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApi",
                routeTemplate: "api/posts",
                defaults: new
                {
                    controller = "posts"
                    
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "ThreadsApi",
                routeTemplate: "api/threads/",
                defaults: new
                {
                    controller = "threads"
                }
            );

            config.Routes.MapHttpRoute(
                name: "CategoriesApi",
                routeTemplate: "api/categories/",
                defaults: new
                {
                    controller = "categories"
                }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}

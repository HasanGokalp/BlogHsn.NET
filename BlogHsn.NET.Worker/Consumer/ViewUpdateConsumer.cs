using BlogHsn.NET.API.Contexts;
using BlogHsn.NET.API.Entities;
using MassTransit;

namespace BlogHsn.NET.Worker.Consumer
{
    public class ViewUpdateConsumer : IConsumer<Post>
    {
        public async Task Consume(ConsumeContext<Post> context)
        {
            var ctx = new BlogHsnCtx();
            var post = ctx.Posts.Find(context.Message.Id);
            post.Viewed++;
            await ctx.SaveChangesAsync();
            ctx.Dispose();
        }
    }
}

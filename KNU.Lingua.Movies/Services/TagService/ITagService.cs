using KNU.Lingua.Movies.Models.Tag;
using System.Collections.Generic;

namespace KNU.Lingua.Movies.Services.TagService
{
    public interface ITagService
    {
        List<Tag> GetTopTagsForNewsItem(string text);
    }
}
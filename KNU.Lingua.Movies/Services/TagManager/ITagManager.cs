using KNU.Lingua.Movies.Models.Tag;
using System.Collections.Generic;

namespace KNU.Lingua.Movies.Services.TagManager
{
    public interface ITagManager
    {
        List<Tag> GetProcessedTags(string text);
    }
}
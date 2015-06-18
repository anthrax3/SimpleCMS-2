using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data
{
    public interface ITagRepository
    {
        IEnumerable<string> GetAll ();
        bool Exists (string tag);

        void Edit (string oldTag, string newTag);

        void Delete (string tag);
    }
}

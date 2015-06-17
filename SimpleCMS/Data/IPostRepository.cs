using SimpleCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data
{
    interface IPostRepository
    {
        Post Get (string id);
    }
}

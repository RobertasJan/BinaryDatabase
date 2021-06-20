using BinaryDatabase.Structures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDatabase.ExampleWeb.Models
{
    public static class SongTreeRepository
    {
        public static BinaryTree<string, Song> SongTree { get; set; }
    }
}

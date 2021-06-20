using BinaryDatabase.ExampleWeb.Models;
using BinaryDatabase.Serialization.Binary;
using BinaryDatabase.Structures.Trees;
using System;

namespace BinaryDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var songTree = new BinaryTree<string, Song>();
            songTree.Insert("Satellite", new Song() { 
                Id = 1,
                AlbumName = "My cassette player",
                Author = "Lena",
                Length = 152,
                Name = "Satellite",
                ReleaseDate = new DateTime(2010, 05, 03)
            });
            songTree.Insert("Running Scared", new Song()
            {
                Id = 2,
                AlbumName = "Play with me (Nigar Jamal's album)",
                Author = "Eldar & Nigar",
                Length = 131,
                Name = "Running Scared",
                ReleaseDate = new DateTime(2011, 05, 03)
            });
            songTree.Insert("Euphoria", new Song()
            {
                Id = 3,
                AlbumName = "Heal",
                Author = "Loreen",
                Length = 172,
                Name = "Euphoria",
                ReleaseDate = new DateTime(2012, 05, 03)
            });
            songTree.Insert("Only Teardrops", new Song()
            {
                Id = 4,
                AlbumName = "Only Teardrops",
                Author = "Emmelie de Forest",
                Length = 201,
                Name = "Only Teardrops",
                ReleaseDate = new DateTime(2013, 05, 03)
            });
            songTree.Insert("Rise Like a Phoenix", new Song()
            {
                Id = 5,
                AlbumName = "Conchita",
                Author = "Conchita Wurst",
                Length = 131,
                Name = "Rise Like a Phoenix",
                ReleaseDate = new DateTime(2014, 05, 03)
            });
            songTree.Insert("Heroes", new Song()
            {
                Id = 6,
                AlbumName = "Perfectly Damaged",
                Author = "Måns Zelmerlöw",
                Length = 152,
                Name = "Heroes",
                ReleaseDate = new DateTime(2015, 05, 03)
            });
            songTree.Insert("1944", new Song()
            {
                Id = 7,
                AlbumName = "1944",
                Author = "Jamala",
                Length = 152,
                Name = "1944",
                ReleaseDate = new DateTime(2016, 05, 03)
            });
            songTree.Insert("Amar pelos dois", new Song()
            {
                Id = 8,
                AlbumName = "",
                Author = "Salvador Sobral",
                Length = 153,
                Name = "Amar pelos dois",
                ReleaseDate = new DateTime(2017, 05, 03)
            });
            songTree.Insert("Toy", new Song()
            {
                Id = 9,
                AlbumName = "Goody Bag",
                Author = "Netta",
                Length = 142,
                Name = "Toy",
                ReleaseDate = new DateTime(2018, 05, 03)
            });
            songTree.Insert("Arcade", new Song()
            {
                Id = 10,
                AlbumName = "Worlds on Fire and Small Town Boy",
                Author = "Duncan Laurence",
                Length = 167,
                Name = "Arcade",
                ReleaseDate = new DateTime(2019, 05, 03)
            });
            songTree.Insert("Zitti e buoni", new Song()
            {
                Id = 11,
                AlbumName = "Teatro d'ira: Vol. 1",
                Author = "Måneskin",
                Length = 170,
                Name = "Zitti e buoni",
                ReleaseDate = new DateTime(2021, 05, 03)
            });
            var binSerializer = new BinarySerializer();
            binSerializer.Serialize(songTree, "DataObj.data");

            var treeObj = (BinaryTree<string, Song>)binSerializer.Deserialize("DataObj.data");

            foreach (var value in treeObj.AsEnumerable())
            {
                Console.WriteLine(value.Item1);
            }
            foreach (var value in songTree.AsEnumerable())
            {
                Console.WriteLine(value.Item1);
            }
        }
    }
}

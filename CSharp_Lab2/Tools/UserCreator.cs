using CSharp_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2.Tools
{
    class UserCreator
    {
        public static List<UserDto> getUsers()
        {
            List<UserDto> list = new List<UserDto>
            {
                new UserDto("Michael"  , "Brown"   , "michael.brown@gmail.com", new DateTime(1980, 12, 5)),
                new UserDto("Jessica"  , "Wilson"  , "jessica.wilson@gmail.com", new DateTime(1995, 2, 18)),
                new UserDto("David"    , "Taylor"  , "david.taylor@gmail.com", new DateTime(1983, 9, 30)),
                new UserDto("Sarah"    , "Anderson", "sarah.anderson@gmail.com", new DateTime(1979, 7, 25)),
                new UserDto("Matthew"  , "Thomas"  , "matthew.thomas@gmail.com", new DateTime(1990, 4, 3)),
                new UserDto("Emily"    , "Martinez", "emily.martinez@gmail.com", new DateTime(1973, 6, 17)),
                new UserDto("Daniel"   , "Hernandez", "daniel.hernandez@gmail.com", new DateTime(1998, 10, 12)),
                new UserDto("Ashley"   , "Young"   , "ashley.young@gmail.com", new DateTime(1989, 8, 29)),
                new UserDto("Christopher", "King" , "christopher.king@gmail.com", new DateTime(2000, 1, 7)),
                new UserDto("Amanda"   , "Scott"   , "amanda.scott@gmail.com", new DateTime(1970, 5, 24)),
                new UserDto("James"    , "Lopez"   , "james.lopez@gmail.com", new DateTime(1993, 2, 14)),
                new UserDto("Megan"    , "Green"   , "megan.green@gmail.com", new DateTime(1982, 11, 11)),
                new UserDto("Ryan"     , "Adams"   , "ryan.adams@gmail.com", new DateTime(1977, 10, 19)),
                new UserDto("Jennifer" , "Campbell", "jennifer.campbell@gmail.com", new DateTime(1992, 6, 8)),
                new UserDto("Justin"   , "Evans"   , "justin.evans@gmail.com", new DateTime(1976, 4, 2)),
                new UserDto("Nicole"   , "Garcia"  , "nicole.garcia@gmail.com", new DateTime(1984, 9, 28)),
                new UserDto("Andrew"   , "Nelson"  , "andrew.nelson@gmail.com", new DateTime(1997, 3, 23)),
                new UserDto("Lauren"   , "Hill"    , "lauren.hill@gmail.com", new DateTime(1986, 12, 20)),
                new UserDto("Brandon"  , "Ramirez" , "brandon.ramirez@gmail.com", new DateTime(1974, 7, 15)),
                new UserDto("Elizabeth", "Carter"  , "elizabeth.carter@gmail.com", new DateTime(1994, 5, 3)),
                new UserDto("Joshua"   , "Wright"  , "joshua.wright@gmail.com", new DateTime(1978, 1, 1)),
                new UserDto("Samantha" , "Perez"   , "samantha.perez@gmail.com", new DateTime(1981, 10, 27)),
                new UserDto("Kevin"    , "Hall"    , "kevin.hall@gmail.com", new DateTime(1996, 8, 14)),
                new UserDto("Hannah"   , "Turner"  , "hannah.turner@gmail.com", new DateTime(1971, 4, 9)),
                new UserDto("Tyler"    , "Morris"  , "tyler.morris@gmail.com", new DateTime(1988, 2, 22)),
                new UserDto("Kayla"    , "Watson"  , "kayla.watson@gmail.com", new DateTime(1999, 11, 16)),
                new UserDto("Alexander", "Brooks"  , "alexander.brooks@gmail.com", new DateTime(1972, 9, 13)),
                new UserDto("Emma"     , "Russell" , "emma.russell@gmail.com", new DateTime(1991, 7, 5)),
                new UserDto("Zachary"  , "Dunn"    , "zachary.dunn@gmail.com", new DateTime(1973, 6, 4)),
                new UserDto("Victoria" , "Gordon"  , "victoria.gordon@gmail.com", new DateTime(1987, 4, 28)),
                new UserDto("Kyle"     , "Kelley"  , "kyle.kelley@gmail.com", new DateTime(1995, 3, 19)),
                new UserDto("Alexis"   , "Baker"   , "alexis.baker@gmail.com", new DateTime(1980, 12, 12)),
                new UserDto("Nathan"   , "Rivera"  , "nathan.rivera@gmail.com", new DateTime(1975, 10, 31)),
                new UserDto("Madison"  , "Mitchell", "madison.mitchell@gmail.com", new DateTime(1992, 8, 25)),
                new UserDto("Olivia"   , "Ward"    , "olivia.ward@gmail.com", new DateTime(1978, 7, 18)),
                new UserDto("Ethan"    , "Lynch"   , "ethan.lynch@gmail.com", new DateTime(1986, 6, 7)),
                new UserDto("Grace"    , "Harrison", "grace.harrison@gmail.com", new DateTime(1997, 4, 1)),
                new UserDto("Logan"    , "Ferguson", "logan.ferguson@gmail.com", new DateTime(1979, 2, 23)),
                new UserDto("Alyssa"   , "Murray"  , "alyssa.murray@gmail.com", new DateTime(1989, 12, 17)),
                new UserDto("Cody"     , "Olson"   , "cody.olson@gmail.com", new DateTime(1994, 11, 9)),
                new UserDto("Julia"    , "Kim"     , "julia.kim@gmail.com", new DateTime(1983, 10, 5)),
                new UserDto("Aaron"    , "Austin"  , "aaron.austin@gmail.com", new DateTime(1990, 9, 2)),
                new UserDto("Hailey"   , "Parker"  , "hailey.parker@gmail.com", new DateTime(1976, 8, 26)),
                new UserDto("Christian", "Hudson"  , "christian.hudson@gmail.com", new DateTime(1981, 7, 21)),
                new UserDto("Lily"     , "Griffin" , "lily.griffin@gmail.com", new DateTime(1993, 6, 15)),
                new UserDto("Gavin"    , "Gomez"   , "gavin.gomez@gmail.com", new DateTime(1974, 5, 7)),
                new UserDto("Sydney"   , "Wallace" , "sydney.wallace@gmail.com", new DateTime(1985, 4, 3)),
                new UserDto("Brianna"  , "Coleman" , "brianna.coleman@gmail.com", new DateTime(1996, 3, 28)),
                new UserDto("Marcus"   , "Woods"   , "marcus.woods@gmail.com", new DateTime(1977, 2, 19)),
                new UserDto("Mia"      , "Grant"   , "mia.grant@gmail.com", new DateTime(1982, 1, 13)),
                new UserDto("Zoe"      , "Wagner"  , "zoe.wagner@gmail.com", new DateTime(1999, 12, 8))
            };
            return list;
        }
    }
}

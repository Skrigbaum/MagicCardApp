﻿using System.Collections.Generic;

namespace MagicApp.Domain
{
    class CardListOfNull
    {
        private static List<Cards> listofnames = new List<Cards>();

        public static List<Cards> LoadList()
        {
            using (var ctx = new CardContext())
            {
                var templistofNames = ctx.Cards.SqlQuery("select * from Cards where MultiverseId is null order by name;");

                foreach (var x in templistofNames)
                {
                    listofnames.Add(x);
                }
            }

            return listofnames;
            
        }

        public static List<Cards> LoadZeroList()
        {
            using (var ctx = new CardContext())
            {
                var templistofNames = ctx.Cards.SqlQuery("select * from Cards where MultiverseId = 0 order by name;");

                foreach (var x in templistofNames)
                {
                    listofnames.Add(x);
                }
            }

            return listofnames;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdventureWorks.Domain;
using AdventureWorks.Persistence.Models;
using Newtonsoft.Json;
using AdventureWorks.Common.Models;

namespace AdventureWorks.Persistence
{
    public class AdventureWorksSeeder
    {
        private readonly IAdventureWorksContext _context;
        protected const string InitialUserId = "some-user-id";

        public AdventureWorksSeeder(IAdventureWorksContext context)
        {
            _context = context;
        }



        public virtual void Seed(SeedType seedType)
        {
            try
            {


                //if (!_context.Countries.Any())
                //{
                //    _context.Countries.Add(
                //        new Country()
                //        {
                //            Id = c.Id,
                //            Name = c.Name
                //        });
                //    _context.SaveChanges();
                //}
            }
            catch (AmbiguousMatchException aex)
            {
                Console.WriteLine(aex);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
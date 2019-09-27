using AuthenticationUser.Shared.Entities;
using Flunt.Validations;
using System.Collections;
using System.Collections.Generic;

namespace AuthenticationUser.Domain.Entities
{
    public class Category : Entity
    {
        public Category(string title)
        {
            Title = title;            
        }

        public string Title { get; private set; }
        public IEnumerable<Product> products { get; set; }
    }
}

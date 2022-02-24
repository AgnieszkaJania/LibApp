using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetMembershipTypes();
        MembershipType Get(int id);
        void Add(MembershipType membershipType);
        void Remove(int id);
        void Update(MembershipType membershipType);
        void Save();
    }
}
